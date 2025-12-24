using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PointixApp.DataLayer;
using PointixApp.DataLayer.Entities;
using PointixApp.Factories;
using PointixApp.Handlers;
using PointixApp.Managers;
using PointixApp.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.Services
{
    public class InventoryService : Observer, IInventoryService
    {
        private AppDbContext context;
        private AuthModel authmodel;
        private INotificationService notificationService;
        public InventoryService(AppDbContext _context, AuthModel _authmodel)
        {
            this.context = _context;
            this.authmodel = _authmodel;
            this.notificationService = new NotificationService(context);
        }
        public Exception AddProduct(AuthModel authmodel, string Name, int quantity, int muinquantity, double price, DateOnly date, string Notes)
        {
            try
            {
                CheckDataValidty(Name, quantity, muinquantity, price, date);

                var existingProduct = context.Products
                    .FirstOrDefault(p => p.ProductName.ToLower() == Name.ToLower() && !p.IsDeleted);

                if (existingProduct != null)
                {
                    if (ManageLanguages.Language == "en")
                        throw new InvalidOperationException($"Product with name '{Name}' already exists");
                    else
                        throw new ArgumentException($"اسم المنتج {Name} موجود بالفعل !");
                }

                var product = new ProductFactory()
                    .CreateProduct(Name, quantity, muinquantity, price, date, Notes);

                context.Products.Add(product);
                context.SaveChanges();

                RegisterInventoryLog(authmodel, product.ProductId, "Add");
                AppCache.ClearProductsCache();

                return null!;
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("adding product", ex);
                return ex;
            }
        }

        private static void CheckDataValidty(string Name, int quantity, int muinquantity, double price, DateOnly date)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                if (ManageLanguages.Language == "en")
                    throw new ArgumentException("Product name cannot be empty");
                else
                    throw new ArgumentException("من فضلك ادخل اسم المنتج!");
            }
            if (quantity < 0)
            {
                if (ManageLanguages.Language == "en")
                    throw new ArgumentException("Quantity cannot be negative");
                else
                    throw new ArgumentException("الكمية يجب ان تكون اكبر من صفر!");
            }

            if (muinquantity < 0)
            {
                if (ManageLanguages.Language == "en")
                    throw new ArgumentException("Minimum quantity cannot be negative");
                else
                    throw new ArgumentException("أقل كمية يجب ان تكون اكبر من الصفر!");
            }

            if (muinquantity > quantity)
            {
                if (ManageLanguages.Language == "en")
                    throw new ArgumentException("Minimum quantity cannot be Greater than Quantity");
                else
                    throw new ArgumentException("أقل كمية لا يجب ان تتكوون اكبر من الكمية !");
            }

            if (price < 0)
            {
                if (ManageLanguages.Language == "en")
                    throw new ArgumentException("Price cannot be negative");
                else
                    throw new ArgumentException("يجب ان يكون السعر اكبر من صفر!");
            }

            if (date < DateOnly.FromDateTime(DateTime.Now.AddDays(-30)))
            {
                if (ManageLanguages.Language == "en")
                    throw new ArgumentException("Expire date cannot be too far in the past");
                else
                    throw new ArgumentException("تاريخ الانتهاء لا يجب ان يكون انتهي!");
            }
        }

        private void RegisterInventoryLog(AuthModel authmodel, int proid, string type)
        {
            context?.InventoryLogs
                .Add(new InventoryLogFactory()
                .CreateInventoryLog(authmodel, proid, type));

            context?.SaveChanges();
        }
        public Exception EditProduct(AuthModel authmodel, int proid, string Name, int quantity, int minquantity, double price, DateOnly date, string Notes)
        {
            try
            {
                CheckDataValidty(Name, quantity, minquantity, price, date);

                var product = context.Products
                    .FirstOrDefault(x => x.ProductId == proid && !x.IsDeleted);

                if (product == null)
                    throw new InvalidOperationException($"Product with ID {proid} not found or has been deleted");

                var existingProduct = context.Products
                    .FirstOrDefault(p => p.ProductName.ToLower() == Name.ToLower()
                                    && p.ProductId != proid && !p.IsDeleted);

                if (existingProduct != null)
                    throw new InvalidOperationException($"Another product with name '{Name}' already exists");

                EditData(Name, quantity, minquantity, price, date, Notes, product);

                context.SaveChanges();
                RegisterInventoryLog(authmodel, proid, "Edit");
                AppCache.ClearProductsCache();

                return null!;
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("editing product", ex);
                return ex;
            }
        }
        private static void EditData(string name, int quantity, int minquantity, double price, DateOnly date, string Notes, Product product)
        {
            product.ProductName = name;
            product.ExpireDate = date;
            product.Price = price;
            product.Quantity = quantity;
            product.MinmumQuantity = minquantity;
            product.Notes = Notes == "" ? null : Notes;
        }
        public IQueryable<Product> SearchForProduct(string productname)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(productname))
                    return Enumerable.Empty<Product>().AsQueryable();

                IQueryable<Product> products = null;
                if (AppCache.CachedProducts == null)
                {
                    products = context.Products
                                .AsNoTracking()
                                .Where(p => p.ProductName.Contains(productname) && p.IsDeleted == false);
                }
                else
                {
                    products = AppCache.CachedProducts
                        .Where(p => p.ProductName.Contains(productname) && p.IsDeleted == false);
                }

                return products;
            }
            catch (Exception)
            {
                return Enumerable.Empty<Product>().AsQueryable();
            }
        }
        public IQueryable<Product> GetProducts()
        {
            try
            {
                if (AppCache.CachedProducts == null)
                {
                    AppCache.CachedProducts = context.Products
                        .AsNoTracking()
                        .Where(p => p.IsDeleted == false);
                }

                return AppCache.CachedProducts;
            }
            catch (Exception)
            {
                return Enumerable.Empty<Product>().AsQueryable();
            }
        }
        public Exception RemoveProduct(AuthModel authmodel, int productid)
        {
            try
            {
                var product = context.Products
                    .FirstOrDefault(x => x.ProductId == productid && !x.IsDeleted);

                if (product == null)
                    throw new InvalidOperationException($"Product with ID {productid} not found or already deleted");

                product.IsDeleted = true;

                context.SaveChanges();
                RegisterInventoryLog(authmodel, productid, "Remove");
                AppCache.ClearProductsCache();

                return null!;
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("removing product", ex);
                return null;
            }
        }
        public Exception IncreaseProduct(int proid, int quantity)
        {
            try
            {
                if (quantity <= 0)
                    throw new ArgumentException("Quantity to increase must be positive");

                var product = context.Products
                    .FirstOrDefault(x => x.ProductId == proid && !x.IsDeleted);

                if (product == null)
                    throw new InvalidOperationException($"Product with ID {proid} not found or has been deleted");

                if (product.Quantity + quantity > int.MaxValue - 1000)
                    throw new OverflowException("Resulting quantity would exceed maximum allowed value");

                product.Quantity += quantity;

                context.SaveChanges();
                RegisterInventoryLog(authmodel, proid, "Increase");
                AppCache.ClearProductsCache();

                return null!;
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("increasing product quantity", ex);
                return null;
            }
        }
        public Exception DecreaseProduct(int proid, int quantity)
        {
            try
            {
                if (proid <= 0)
                    throw new ArgumentException("Invalid product ID", nameof(proid));

                if (quantity <= 0)
                    throw new ArgumentException("Quantity to decrease must be positive", nameof(quantity));

                var product = context.Products
                    .FirstOrDefault(x => x.ProductId == proid && !x.IsDeleted);

                if (product == null)
                    throw new InvalidOperationException($"Product with ID {proid} not found or has been deleted");

                if (product.Quantity < quantity)
                    throw new InvalidOperationException($"Cannot decrease quantity by {quantity}. Current quantity is {product.Quantity}");

                product.Quantity -= quantity;

                context.SaveChanges();
                RegisterInventoryLog(authmodel, proid, "Decrease");

                product.observer = this;

                product.ChackQuantity();

                AppCache.ClearProductsCache();

                return null!;
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("decreasing product quantity", ex);
                return null;
            }
        }
        public override void NotifDecreseProducts(Subject subject)
           => notificationService.NotifDecreseProducts((Product)subject);

        public override void NotifEndProducts(Subject subject)
           => notificationService.NotifEndProducts((Product)subject);
    }
}

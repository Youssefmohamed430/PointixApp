using FuzzySharp;
using Microsoft.EntityFrameworkCore;
using PointixApp.DataLayer;
using PointixApp.DataLayer.DTOs;
using PointixApp.DataLayer.Entities;
using PointixApp.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.Services
{
    internal class SaleService : ISaleService
    {
        private readonly AppDbContext _context; 
        private readonly IInventoryService inventoryservice;
        private readonly AuthModel authModel;
        public SaleService(AppDbContext context,AuthModel _authmodel)
        {
            _context = context;
            this.authModel = _authmodel;
            this.inventoryservice = new InventoryService(_context, authModel) ;
        }
        public async Task<Exception> AddSale(string customername,string customerphone , int sellerid, Dictionary<Product, int> saleitems, decimal totalamount,decimal paidamouunt,string Notes)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(customername))
                    throw new ArgumentException("Customer name cannot be empty.", nameof(customername));

                if (string.IsNullOrWhiteSpace(customerphone))
                    throw new ArgumentException("Customer phone cannot be empty.", nameof(customerphone));

                if (saleitems == null || !saleitems.Any())
                    throw new ArgumentException("Sale items cannot be empty.", nameof(saleitems));

                if (totalamount < 0 || paidamouunt < 0)
                    throw new ArgumentException("Total amount and paid amount cannot be negative.", nameof(totalamount));

                var sale = new SaleFactory().CreateSale(customername,customerphone, sellerid, totalamount, paidamouunt,Notes);
                _context.Sales.Add(sale);
                await _context.SaveChangesAsync();

                RegisterSaleItem(saleitems, sale.SaleId);

                AppCache.ClearSalesCache();

                return null!;
            }
            catch (Exception ex)
            {
                 ExceptionHandler.ShowError("An unexpected error occurred while processing the sale. Contact support with error details.", ex);
                return ex;
            }
        }
        private void RegisterSaleItem(Dictionary<Product, int> saleitems, int saleid)
        {
            try
            {
                if (saleitems == null)
                    throw new ArgumentNullException(nameof(saleitems), "Sale items dictionary cannot be null.");

                foreach (var item in saleitems)
                {
                    if (item.Key == null)
                        throw new ArgumentException("Product cannot be null.", nameof(item.Key));

                    if (item.Value <= 0)
                        throw new ArgumentException($"Invalid quantity for product {item.Key.ProductName}. Quantity must be positive.", nameof(item.Value));

                    _context?.SaleItems.Add(new SaleItemFactory()
                        .CreateSaleItem(item.Key, saleid, item.Value));

                    _context?.SaveChanges();

                    inventoryservice.DecreaseProduct(item.Key.ProductId, item.Value);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("An unexpected error occurred while registering sale items. Contact support with error details.", ex);
            }
        }
        public IQueryable<SaleDTO> GetAllSales()
        {
            try
            {
                if (AppCache.CachedSales == null)
                {
                    AppCache.CachedSales = _context.Sales
                        .AsNoTracking()
                        .Include(x => x.saleItem)
                        .ThenInclude(x => x.product)
                        .Include(s => s.Seller)
                        .Select(SaleDTOFactory.Expression);
                }
                return AppCache.CachedSales;
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("Failed to retrieve sales data. Please try again or contact support.", ex);
                return null;
            }
        }
        public IQueryable<SaleDTO> FilterSale(DateTime StartDate, DateTime EndDate)
        {
            try
            {
                if (StartDate > EndDate)
                    throw new ArgumentException("Start date cannot be after end date.", nameof(StartDate));

                IQueryable<SaleDTO> sales;
                if (AppCache.CachedSearchedSales == null && AppCache.CachedSales == null)
                {
                    sales = _context.Sales
                        .AsNoTracking()
                        .Include(x => x.saleItem)
                        .ThenInclude(x => x.product)
                        .Include(s => s.Seller)
                        .Where(s => s.SaleDate.Date >= StartDate.Date && s.SaleDate.Date <= EndDate.Date)
                        .OrderByDescending(s => s.SaleDate)
                        .Select(SaleDTOFactory.Expression);
                     AppCache.CachedFilterdSales = sales;
                }
                else if(AppCache.CachedSearchedSales != null)
                {
                    sales = AppCache.CachedSearchedSales
                        .Where(s => s.SaleDate.Date >= StartDate.Date && s.SaleDate.Date <= EndDate.Date)
                        .OrderByDescending(s => s.SaleDate);
                }
                else
                {
                    sales = AppCache.CachedSales
                        .Where(s => s.SaleDate.Date >= StartDate.Date && s.SaleDate.Date <= EndDate.Date)
                        .OrderByDescending(s => s.SaleDate);
                    AppCache.CachedFilterdSales = sales;
                }
                return sales;
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("Failed to filter sales data. Please try again or contact support.", ex);
                return null;
            }
        }
        public IQueryable<SaleDTO> SearchForSale(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("Search term cannot be empty.", nameof(name));

                IQueryable<SaleDTO> sales;
                if (AppCache.CachedFilterdSales == null && AppCache.CachedSales == null)
                {
                    sales = _context.Sales
                        .Include(x => x.saleItem)
                        .ThenInclude(x => x.product)
                        .Include(s => s.Seller)
                        .Where(s =>  s.CustomerName.Contains(name) || s.Seller.Name.Contains(name))
                        .OrderByDescending(s => s.SaleDate)
                        .Select(SaleDTOFactory.Expression);

                    AppCache.CachedSearchedSales = sales;
                }
                else if (AppCache.CachedFilterdSales != null)
                {
                    sales = AppCache.CachedFilterdSales
                        .Where(s => s.CustomerName.Contains(name) || s.SellerName.Contains(name))
                        .OrderByDescending(s => s.SaleDate);
                }
                else
                {
                    sales = AppCache.CachedSales
                        .Where(s => s.CustomerName.Contains(name) || s.SellerName.Contains(name))
                        .OrderByDescending(s => s.SaleDate);
                    AppCache.CachedSearchedSales = sales;
                }
                return sales;
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("Failed to search sales data.", ex);
                return null;
            }

        }
        public IQueryable<SaleDTO> GetRemainingAmountSales()
        {
            try
            {
                IQueryable<SaleDTO> sales;
                if (AppCache.CachedSales == null)
                {
                    sales = _context.Sales
                        .AsNoTracking()
                        .Include(x => x.saleItem)
                        .ThenInclude(x => x.product)
                        .Include(s => s.Seller)
                        .Where(s => s.RemainingAmount > 0)
                        .OrderByDescending(s => s.SaleDate)
                        .Select(SaleDTOFactory.Expression);
                }
                else
                {
                    sales = AppCache.CachedSales
                        .Where(s => s.RemainingAmount > 0)
                        .OrderByDescending(s => s.SaleDate);
                }
                return sales;
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("Failed to retrieve sales with remaining amounts", ex);
                return null;
            }
        }
        public void EditRemainingValue(int id,decimal remaining)
        {
            try
            {
                if (remaining < 0)
                    throw new ArgumentException("Remaining amount cannot be negative.", nameof(remaining));

                var sale = _context.Sales
                    .FirstOrDefault(s => s.SaleId == id);

                if (sale == null)
                    throw new ArgumentException($"Sale with ID {id} not found.", nameof(id));

                if (remaining > sale.SaleAmount)
                    throw new ArgumentException("Remaining amount cannot be greater than Total Amount.", nameof(remaining));

                sale.PaidAmount = sale.SaleAmount - remaining;
                sale.RemainingAmount = remaining;

                _context.Sales.Update(sale);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("An unexpected error occurred while updating the remaining amount. Contact support with error details.", ex);
            }
        }
        public List<SaleItem> GetSaleItemsForSale(int id)
        {
            try
            {
                var sale = _context.Sales
                    .AsNoTracking()
                    .Include(x => x.saleItem)
                    .ThenInclude(x => x.product)
                    .FirstOrDefault(s => s.SaleId == id);

                if (sale == null)
                    throw new ArgumentException($"Sale with ID {id} not found.", nameof(id));

                return sale.saleItem.ToList();
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowError("Failed to retrieve sale items.", ex);
                return null;
            }

        }
    }
}

using PointixApp.DataLayer;
using PointixApp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.Services
{
    public interface IInventoryService
    {
        IQueryable<Product> GetProducts();
        Exception AddProduct(AuthModel authmodel, string Name, int quantity, int muinquantity, double price, DateOnly date, string Notes);
        Exception EditProduct(AuthModel authmodel, int proid, string Name, int quantity, int minquantity, double price, DateOnly date, string Notes);
        Exception RemoveProduct(AuthModel authmodel, int productid);
        IQueryable<Product> SearchForProduct(string productname);
        Exception IncreaseProduct(int proid, int quantity);
        Exception DecreaseProduct(int proid, int quantity);
    }
}

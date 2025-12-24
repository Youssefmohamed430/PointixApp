using Microsoft.EntityFrameworkCore.Storage.Json;
using PointixApp.DataLayer.DTOs;
using PointixApp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.Services
{
    public interface ISaleService 
    {
        IQueryable<SaleDTO> GetAllSales();
        Task<Exception> AddSale(string customername, string customerphone, int sellerid, Dictionary<Product, int> saleitems, decimal totalamount, decimal paidamouunt,string Notes);
        IQueryable<SaleDTO> FilterSale(DateTime StartDate,DateTime EndDate);
        IQueryable<SaleDTO> SearchForSale(string name);
        public IQueryable<SaleDTO> GetRemainingAmountSales();
        public void EditRemainingValue(int id, decimal remaining);
        public List<SaleItem> GetSaleItemsForSale(int id);

    }
}

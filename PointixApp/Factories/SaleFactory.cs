using PointixApp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.Factories
{
    internal class SaleFactory
    {
        public Sale CreateSale(string customername,string Custphone, int sellerid, decimal saleamount,decimal paidAmount,string Notes)
            => new Sale()
            {
                CustomerName = customername,
                CustomerPhone = Custphone,
                SaleAmount = saleamount,
                SaleDate = DateTime.Now,
                SellerId = sellerid,
                PaidAmount = paidAmount,
                RemainingAmount = saleamount - paidAmount,
                Notes = Notes == "" ? null : Notes,
            };
    }
}

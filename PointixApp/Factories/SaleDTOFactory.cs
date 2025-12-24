using PointixApp.DataLayer.DTOs;
using PointixApp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.Factories
{
    internal class SaleDTOFactory
    {
        public SaleDTO CreateSaleDTO(Sale sale)
        {
            return new SaleDTO
            {
                SaleId = sale.SaleId,
                SaleDate = sale.SaleDate,
                CustomerName = sale.CustomerName,
                CustomerPhone = sale.CustomerPhone,
                SaleAmount = sale.SaleAmount,
                PaidAmount = sale.PaidAmount,
                RemainingAmount = sale.RemainingAmount,
                SellerName = sale.Seller.Name,
                Notes = sale.Notes,
                saleItemsName = sale.saleItem.Select(item => item.product.ProductName).ToList()
            };
        }
        public static Expression<Func<Sale, SaleDTO>> Expression => sale => new SaleDTO
        {
            SaleId = sale.SaleId,
            SaleDate = sale.SaleDate,
            CustomerName = sale.CustomerName,
            CustomerPhone = sale.CustomerPhone,
            SaleAmount = sale.SaleAmount,
            PaidAmount = sale.PaidAmount,
            RemainingAmount = sale.RemainingAmount,
            SellerName = sale.Seller.Name,
            Notes = sale.Notes,
            saleItemsName = sale.saleItem.Select(item => item.product.ProductName).ToList()
        };

    }
}

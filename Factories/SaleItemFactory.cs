using PointixApp.DataLayer;
using PointixApp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.Factories
{
    public class SaleItemFactory
    {
        public SaleItem CreateSaleItem(Product product,int saleid,int quantity)
        =>  new SaleItem()
            {
                ProductId = Convert.ToInt32(product.ProductId),
                SaleId = Convert.ToInt32(saleid),
                Quantity = Convert.ToInt32(quantity),
            };
    }
}

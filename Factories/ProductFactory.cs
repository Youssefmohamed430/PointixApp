using PointixApp.DataLayer.Entities;
using PointixApp.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.Factories
{
    internal class ProductFactory
    {
        public Product CreateProduct(string name,int quantity,int minquantity,double price,DateOnly expdate,string Notes )
            => new Product()
            {
                ProductName = name,
                Quantity = quantity,
                MinmumQuantity = minquantity,
                Price = price,
                ExpireDate = expdate,
                Notes = Notes == "" ? null : Notes, 
            };
    }
}

using PointixApp.DataLayer.Config;
using PointixApp.Patterns;
using PointixApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.DataLayer.Entities
{
    public class Product : Subject
    {

        public int ProductId { get; set; }  
        public string ProductName { get; set; }
        public DateOnly ExpireDate { get; set; }
        public int Quantity { get; set; }
        public int MinmumQuantity { get; set; }
        public double Price { get; set; }
        public string? Notes { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<SaleItem> saleItem { get; set; }
        public List<InventoryLog> inventoryLog { get; set; }


        public override void ChackQuantity()
        {
            if (this?.Quantity == 0)
                Notify(this,"Problem");
            else if(this?.Quantity < this?.MinmumQuantity)
                Notify(this, "Warning");
        }
    }
}

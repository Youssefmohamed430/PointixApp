using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.DataLayer.Entities
{
    public class Product
    {
        public int ProductId { get; set; }  
        public string ProductName { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<SaleItem> saleItem { get; set; }
        public List<InventoryLog> inventoryLog { get; set; }
    }
}

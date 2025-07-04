using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.DataLayer.Entities
{
    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public string CustomerName { get; set; }
        public int SaleAmount { get; set; }
        public int SellerId { get; set; }
        public User Seller { get; set; }
        public List<SaleItem> saleItem { get; set; }

    }
}

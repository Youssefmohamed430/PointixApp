using PointixApp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.DataLayer.DTOs
{
    public class SaleDTO
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public decimal SaleAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public string SellerName { get; set; }
        public string Notes { get; set; }
        public List<string> saleItemsName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.DataLayer.Entities
{
    public class InventoryLog
    {
        public int LogId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public ChangeType changeType { get; set; }
        public DateTime ChangeDate { get; set; }
        public User user { get; set; }
        public Product product { get; set; }
    }
    public enum ChangeType { Add , Edit , Remove }
}
    
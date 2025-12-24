using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.Patterns
{
    [NotMapped]
    public abstract class Observer
    {
        public Subject subject { get; set; }
        public abstract void NotifDecreseProducts(Subject subject);
        public abstract void NotifEndProducts(Subject subject);
    }
}

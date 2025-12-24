using Microsoft.EntityFrameworkCore.Storage;
using PointixApp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.Patterns
{
    [NotMapped]
    public abstract class Subject
    {
        public Observer observer { get; set; }

        public abstract void ChackQuantity();

        public void Notify(Subject subject,string Type )
        {
            if(Type == "Warning")
                observer.NotifDecreseProducts(subject);
            else if (Type == "Problem")
                observer.NotifEndProducts(subject);
        }
    }
}

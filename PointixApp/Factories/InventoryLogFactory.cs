using PointixApp.DataLayer;
using PointixApp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PointixApp.Factories
{
    internal class InventoryLogFactory
    {
        public InventoryLog CreateInventoryLog(AuthModel authmodel,int id,string changetype)
            => new InventoryLog()
            {
                UserId = authmodel.Id,
                ProductId = Convert.ToInt32(id),
                changeType = changetype,
                ChangeDate = DateTime.Now,
            };
    }
}

using PointixApp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.Services
{
    public interface IInventorLogService
    {
        IQueryable<InventoryLog> GetAllLoogs();
        IQueryable<InventoryLog> GetSearchedLogs(string name);
        IQueryable<InventoryLog> FilterLogs(DateTime StartDate, DateTime EndDate);
    }
}

using Microsoft.EntityFrameworkCore;
using PointixApp.DataLayer;
using PointixApp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.Services
{
    internal class InventoryLogService : IInventorLogService
    {
        private readonly AppDbContext context;

        public InventoryLogService (AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<InventoryLog> GetAllLoogs() => context.InventoryLogs
            .AsNoTracking()
            .Include(l => l.user)
            .Include(l => l.product);

        public IQueryable<InventoryLog> GetSearchedLogs(string name)
        => context.InventoryLogs
            .AsNoTracking()
            .Include(l => l.user)
            .Include(l => l.product)
            .Where(l => l.product.ProductName == name || l.user.Name == name || l.user.UserName == name)
            .OrderByDescending(l => l.ChangeDate);

        public IQueryable<InventoryLog> FilterLogs(DateTime StartDate, DateTime EndDate)
        => context.InventoryLogs
            .AsNoTracking()
            .Include(l => l.user)
            .Include(l => l.product)
            .Where(l => l.ChangeDate >= StartDate && l.ChangeDate <= EndDate)
            .OrderByDescending(l => l.ChangeDate);
    }
}

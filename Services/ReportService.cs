using Microsoft.EntityFrameworkCore;
using PointixApp.DataLayer;
using PointixApp.DataLayer.DTOs;
using PointixApp.DataLayer.Entities;
using PointixApp.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.Services
{
    internal class ReportService : IReportService
    {
        private AppDbContext context;
        public ReportService(AppDbContext _context)
        {
            context = _context;
        }

        public void GeneratePdfReport()
        {
            throw new NotImplementedException();
        }

        public Dictionary<IQueryable<SaleDTO>,decimal> GetSales(DateTime StartDate, DateTime EndDate)
        {
            IQueryable<SaleDTO> Sales = null;
            if (AppCache.CachedSales == null)
            {
                Sales = context.Sales.AsNoTracking()
                    .Include(s => s.Seller)
                    .Where(s => s.SaleDate >= StartDate && s.SaleDate < EndDate)
                    .Select(SaleDTOFactory.Expression);
            }
            else
            {
                Sales = AppCache.CachedSales
                    .Where(s => s.SaleDate >= StartDate && s.SaleDate < EndDate);
            }

            var totalsales = Sales.Select(s => s.SaleAmount).Sum();

            return new Dictionary<IQueryable<SaleDTO>, decimal>{{Sales, totalsales }};
        }
    }
}

using PointixApp.DataLayer;
using PointixApp.DataLayer.DTOs;
using PointixApp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.Services
{
    public interface IReportService
    {
        void GeneratePdfReport();
        Dictionary<IQueryable<SaleDTO>,decimal> GetSales(DateTime StartDate, DateTime EndDate);
    }
}

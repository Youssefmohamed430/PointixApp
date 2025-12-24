using PointixApp.Controller;
using PointixApp.DataLayer;
using PointixApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.Patterns
{
    public class Mediator
    {
        public IAuthService authService;
        public ISaleService SaleService;
        public IInventorLogService InventorLogService;
        public IInventoryService InventoryService;
        public INotificationService NotificationService;
        public IUserManagementService UserManagementService;
        public IReportService ReportService;

        public Mediator(AppDbContext appDbContext,AuthModel authmodel)
        {
            authService = new AuthService(appDbContext);
            InventoryService = new InventoryService(appDbContext, authmodel);
            InventorLogService = new InventoryLogService(appDbContext);
            NotificationService = new NotificationService(appDbContext);
            SaleService = new SaleService(appDbContext, authmodel);
            UserManagementService = new UserManagementService(appDbContext);
            ReportService = new ReportService(appDbContext);
        }
        public Mediator(AppDbContext appDbContext)
        {
            authService = new AuthService(appDbContext);
            InventorLogService = new InventoryLogService(appDbContext);
            NotificationService = new NotificationService(appDbContext);
            UserManagementService = new UserManagementService(appDbContext);
            ReportService = new ReportService(appDbContext);
        }
    }
}

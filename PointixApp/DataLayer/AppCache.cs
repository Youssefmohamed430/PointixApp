using PointixApp.DataLayer.DTOs;
using PointixApp.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointixApp.DataLayer
{
    public static class AppCache
    {
        public static IQueryable<Product> CachedProducts { get; set; }
        public static IQueryable<SaleDTO> CachedSales { get; set; }
        public static IQueryable<User> CachedUsers { get; set; }
        public static IQueryable<UserNotification> CachedNotifications { get; set; }
        public static IQueryable<SaleDTO> CachedSearchedSales { get; set; }
        public static IQueryable<SaleDTO> CachedFilterdSales { get; set; }

        //public static IQueryable<Customer> CachedCustomers { get; set; }

        public static void ClearProductsCache()
        {
            CachedProducts = null;
        }
        public static void ClearSalesCache()
        {
            CachedSales = null;
        }
        public static void ClearUserCache()
        {
            CachedUsers = null;
        }
        public static void ClearNotifcationCache()
        {
            CachedNotifications = null;
        } 
        public static void ClearCachedSearchedSales()
        {
            CachedSearchedSales = null;
        }
        public static void ClearCachedFilterdSales()
        {
            CachedFilterdSales = null;
        }
        //public static void ClearCustomerCache()
        //{
        //    CachedCustomers = null;
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Raunstrup_Webapplication.Models;

namespace Raunstrup_Webapplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Raunstrup_Webapplication.Models.CustomerModel> CustomerModel { get; set; }
        public DbSet<Raunstrup_Webapplication.Models.EmployeeModel> EmployeeModel { get; set; }
        public DbSet<Raunstrup_Webapplication.Models.OfferModel> OfferModel { get; set; }
        public DbSet<Raunstrup_Webapplication.Models.EmployeeOfferModel> EmployeeOfferModel { get; set; }
        public DbSet<Raunstrup_Webapplication.Models.EmployeeVehicleModel> EmployeeVehicleModel { get; set; }
        public DbSet<Raunstrup_Webapplication.Models.ResourceModel> ResourceModel { get; set; }
        public DbSet<Raunstrup_Webapplication.Models.OrderModel> OrderModel { get; set; }
        public DbSet<Raunstrup_Webapplication.Models.ServiceModel> ServiceModel { get; set; }
        public DbSet<Raunstrup_Webapplication.Models.ServiceLineModel> ServiceLineModel { get; set; }
    }
}

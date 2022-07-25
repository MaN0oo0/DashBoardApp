
using PortalDAL.Extend;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PortalDAL.Database
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationContext(DbContextOptions <ApplicationContext> opt):base(opt)
        {

        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Distric> Distric { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=MOHAMMED\\SQLEXPRESS;database=PortalDB;Integrated Security=True;");
        //}
    }
}

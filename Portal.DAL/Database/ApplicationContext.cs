﻿using Microsoft.EntityFrameworkCore;
using PortalDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDAL.Database
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Department> Department { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MOHAMMED\\SQLEXPRESS;database=PortalDB;Integrated Security=True;");
        }
    }
}

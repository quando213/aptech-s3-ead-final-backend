using EadFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EadFinal.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=ConnectionString1")
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
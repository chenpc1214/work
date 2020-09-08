using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; 
using Entity_Framework_practice.Models;

namespace Entity_Framework_practice.Models
{
    public class CmsContext:DbContext
    {
        public CmsContext() : base("CmsDbConnection") { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Register> Registers { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class MyContextDb:DbContext
    {
        public MyContextDb() : base("MyContextDb")
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<tSupplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<tbRole> tbRoles { get; set; }
    }
}
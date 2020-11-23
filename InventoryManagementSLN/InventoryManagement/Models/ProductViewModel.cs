using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public System.DateTime ProductExpDate { get; set; }
        public bool IsDeleted { get; set; }
        public int tSupplierID { get; set; }
        public string CompanyName { get; set; }
       
    }
}
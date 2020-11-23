using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class tSupplier
    {
       
        public tSupplier()
        {
            this.tblProducts = new HashSet<Product>();
        }
        [Key]
        public int tSupplierID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string MobileNO { get; set; }
        public virtual ICollection<Product> tblProducts { get; set; }
    }
}
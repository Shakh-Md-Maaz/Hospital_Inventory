using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class tbRole
    {
        public tbRole()
        {

        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        public int UserId { get; set; }

        public virtual User tblUser { get; set; }
    }
}
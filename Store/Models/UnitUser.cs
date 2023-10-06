using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class UnitUser
    {
        [Key]
        public int UnitId { get; set; }
        [Required]
        public string UnitName { get; set; }
    }
}
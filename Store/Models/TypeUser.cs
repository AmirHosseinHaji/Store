using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class TypeUser
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
}
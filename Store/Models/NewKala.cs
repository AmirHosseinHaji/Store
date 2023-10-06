using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class NewKala
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Typekala { get; set; }
        [Required]
        public string Unit { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int QuantityInStock { get; set; }
        public string Description { get; set; }
    }
}
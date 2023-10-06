using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class Kala
    {
        public Kala()
        {
            Item = new Item();
            ItemId = Item.Id;
            orderDetail=new List<OrderDetail>();
        }
        [Key]
        public int KalaId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "نوع کالا خالی است")]
        public string Typekala { get; set; }
        [Required(ErrorMessage = "واحد اندازه گیری کالا خالی است")]
        public string Unit { get; set; }
        [Required]
		public int Count { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        [Required]
		public decimal Price { get; set; }
        [Required]
        public string NameBuyer { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
		[Column(TypeName = "decimal(18,4)")]
		public decimal Discount { get; set; }
        public string Description { get; set; }
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Item Item { get; set; }
		public List<OrderDetail> orderDetail { get; set; }

    }
}
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models
{
	public class Item
	{
		public Item()
		{
			Kala = new Kala();
		}
		public int Id { get; set; }
		[Column(TypeName = "decimal(18,4)")]
		public decimal Price { get; set; }
		public int QuantityInStock { get; set; }
		public Kala Kala { get; set; }
	}
}

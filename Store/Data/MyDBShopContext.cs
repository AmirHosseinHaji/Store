using Microsoft.EntityFrameworkCore;
using Store.Models;

namespace Store.Data
{
	public class MyDBShopContext:DbContext
	{
		public MyDBShopContext(DbContextOptions<MyDBShopContext> option) : base(option)
		{
		}
		public DbSet<Kala> Kala { get; set; }
		public DbSet<NewKala> UserKala { get; set; }
		public DbSet<User> User { get; set; }
		public DbSet<Item> Item { get; set; }
		public DbSet<FactorForoosh> FactorForoosh { get; set; }
		public DbSet<Order> Order { get; set; }
		public DbSet<OrderDetail> OrderDetail { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Item>().HasData(
				new Item()
				{
					Id = 1,
					Price = 854.0M,
					QuantityInStock = 5
				},
			new Item()
			{
				Id = 2,
				Price = 3302.0M,
				QuantityInStock = 8
			},
			new Item()
			{
				Id = 3,
				Price = 2500,
				QuantityInStock = 3
			});
			modelBuilder.Entity<Order>().HasOne(c => c.User);
			base.OnModelCreating(modelBuilder);
		}
	}
}

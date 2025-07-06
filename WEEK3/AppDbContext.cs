using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext {
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer("Server=BT-22053513\\SQLEXPRESS;Database=RetailInventoryDb;Trusted_Connection=True;");
    }
}

using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;
using RetailInventory.Data;

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        // Ensure database and tables are created
        await context.Database.MigrateAsync();

        // Seed Data
        if (!await context.Categories.AnyAsync())
        {
            var electronics = new Category { Name = "Electronics" };
            var groceries = new Category { Name = "Groceries" };

            await context.Categories.AddRangeAsync(electronics, groceries);

            var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
            var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

            await context.Products.AddRangeAsync(product1, product2);
            await context.SaveChangesAsync();

            Console.WriteLine("Sample data inserted.");
        }

        // Fetch and display products
        var products = await context.Products.Include(p => p.Category).ToListAsync();
        Console.WriteLine("\nAvailable Products:");
        foreach (var p in products)
        {
            Console.WriteLine($"- {p.Name} (₹{p.Price}) - {p.Category?.Name}");
        }

        // FirstOrDefault example
        var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
        Console.WriteLine($"\nMost Expensive: {expensive?.Name}");
    }
}

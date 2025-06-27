using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
}

class RankedProduct
{
    public Product Product { get; set; }
    public int RowNumber { get; set; }
    public int Rank { get; set; }
    public int DenseRank { get; set; }
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product { Name = "Apple Macbook", Category = "Electronics", Price = 1200 },
            new Product { Name = "Dell Vostro", Category = "Electronics", Price = 1100 },
            new Product { Name = "Bravia XD", Category = "Electronics", Price = 1100 },
            new Product { Name = "Apple iPhone XS", Category = "Electronics", Price = 1000 },
            new Product { Name = "Gucci A", Category = "Fashion", Price = 200 },
            new Product { Name = "Bata B", Category = "Fashion", Price = 180 },
            new Product { Name = "Puma A", Category = "Fashion", Price = 180 },
            new Product { Name = "Adidas A", Category = "Fashion", Price = 100 }
        };

        var rankedProducts = products
            .GroupBy(p => p.Category)
            .SelectMany(group =>
            {
                var sorted = group.OrderByDescending(p => p.Price).ToList();
                var result = new List<RankedProduct>();

                int rowNumber = 1;
                int rank = 1;
                int denseRank = 1;
                decimal? previousPrice = null;

                for (int i = 0; i < sorted.Count; i++)
                {
                    var current = sorted[i];

                    // Rank & Dense Rank logic
                    if (previousPrice != null && current.Price != previousPrice)
                    {
                        denseRank++;
                        rank = rowNumber;
                    }

                    result.Add(new RankedProduct
                    {
                        Product = current,
                        RowNumber = rowNumber,
                        Rank = rank,
                        DenseRank = denseRank
                    });

                    previousPrice = current.Price;
                    rowNumber++;
                }

                // Return top 3 by ROW_NUMBER per category
                return result.Where(rp => rp.RowNumber <= 3);
            });

        // Print the ranked results
        foreach (var rp in rankedProducts)
        {
            Console.WriteLine($"Category: {rp.Product.Category}, Name: {rp.Product.Name}, Price: {rp.Product.Price}, " +
                              $"ROW_NUMBER: {rp.RowNumber}, RANK: {rp.Rank}, DENSE_RANK: {rp.DenseRank}");
        }
    }
}

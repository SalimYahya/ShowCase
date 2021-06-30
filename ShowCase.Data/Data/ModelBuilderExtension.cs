using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShowCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Data
{
    public static class ModelBuilderExtension
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {

            // Seed Product Table
            Random random = new Random();

            var products = new List<Product>();
            for (int i = 1; i <= 1000; i++)
            {
                products.Add(new Product {
                    Id = i,
                    Name = "Item " + Convert.ToString(i),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2, MidpointRounding.AwayFromZero),
                });
            }

            modelBuilder.Entity<Product>().HasData(products);
        }

        public static double RandomPriceGenerator(Random random, double minValue, double maxValue)
        {
            return random.NextDouble() * ((maxValue - minValue) + minValue);
        }
    }
}

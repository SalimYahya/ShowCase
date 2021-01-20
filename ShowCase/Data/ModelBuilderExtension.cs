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

            Random random = new Random();

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Item " + Convert.ToString(1),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },
                new Product
                {
                    Id = 2,
                    Name = "Item " + Convert.ToString(2),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },

                new Product
                {
                    Id = 3,
                    Name = "Item " + Convert.ToString(3),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },

                new Product
                {
                    Id = 4,
                    Name = "Item " + Convert.ToString(4),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2)
                },

                new Product
                {
                    Id = 5,
                    Name = "Item " + Convert.ToString(5),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },

                new Product
                {
                    Id = 6,
                    Name = "Item " + Convert.ToString(6),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },

                new Product
                {
                    Id = 7,
                    Name = "Item " + Convert.ToString(7),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },

                new Product
                {
                    Id = 8,
                    Name = "Item " + Convert.ToString(8),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },

                new Product
                {
                    Id = 9,
                    Name = "Item " + Convert.ToString(9),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },

                new Product
                {
                    Id = 10,
                    Name = "Item " + Convert.ToString(10),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },

                new Product
                {
                    Id = 11,
                    Name = "Item " + Convert.ToString(11),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },
                new Product
                {
                    Id = 12,
                    Name = "Item " + Convert.ToString(2),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },

                new Product
                {
                    Id = 13,
                    Name = "Item " + Convert.ToString(13),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },
                new Product
                {
                    Id = 14,
                    Name = "Item " + Convert.ToString(14),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },

                new Product
                {
                    Id = 15,
                    Name = "Item " + Convert.ToString(15),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },

                new Product
                {
                    Id = 16,
                    Name = "Item " + Convert.ToString(16),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },

                new Product
                {
                    Id = 17,
                    Name = "Item " + Convert.ToString(17),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },

                new Product
                {
                    Id = 18,
                    Name = "Item " + Convert.ToString(18),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },

                new Product
                {
                    Id = 19,
                    Name = "Item " + Convert.ToString(19),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },

                new Product
                {
                    Id = 20,
                    Name = "Item " + Convert.ToString(20),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },

                new Product
                {
                    Id = 21,
                    Name = "Item " + Convert.ToString(21),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },

                new Product
                {
                    Id = 22,
                    Name = "Item " + Convert.ToString(22),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },

                new Product
                {
                    Id = 23,
                    Name = "Item " + Convert.ToString(23),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },

                new Product
                {
                    Id = 24,
                    Name = "Item " + Convert.ToString(24),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                },

                new Product
                {
                    Id = 25,
                    Name = "Item " + Convert.ToString(25),
                    Description = "Lorem Ipsum is simply dummy text",
                    Price = Math.Round(RandomPriceGenerator(random, 50, 1000), 2),
                });
        }

        public static double RandomPriceGenerator(Random random, double minValue, double maxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}

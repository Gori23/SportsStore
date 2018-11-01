using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SportsStore1.Models;
using System.Linq;

namespace SportsStore1.Tests
{
    public class CartTest
    {
        [Fact]
        public void Add_New_Lines()
        {
            //Arrange

            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            Cart target = new Cart();

            //ACt

            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            CartLine[] result = target.lines.ToArray();

            //ASSerts

            Assert.Equal(2, result.Length);
            Assert.Equal(p1, result[0].Product);
            Assert.Equal(p2, result[1].Product);

        }
        [Fact]
        public void Can_Add_Quanity_For_Existing_Lines()
        {
            //Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            // Przygotowanie — utworzenie nowego koszyka.
            Cart target = new Cart();

            //ACT

            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 10);
            CartLine[] results = target.lines.OrderBy(c => c.Product.ProductID).ToArray();

            // Asercje.
            Assert.Equal(2, results.Length);
            Assert.Equal(11, results[0].Quanity);
            Assert.Equal(1, results[1].Quanity );
        }
        [Fact]
        public void Can_Remove_Line()
        {
            //Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Cart target = new Cart();

            //ACT
            target.AddItem(p1, 2);
            target.RemoveLine(p1);

            //Arrange
            Assert.Equal(0, target.lines.Where(c => c.Product == p1).Count());
        }
        [Fact]
        public void Can_Count_Something()
        {
            //Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1",Price=200M};
            Product p2 = new Product { ProductID = 2, Name = "P2",Price = 100M };
            Cart target = new Cart();

            //Act
            target.AddItem(p1, 2);
            target.AddItem(p2, 4);
            decimal result = target.ComputeTotalValue();

            //Assert
            Assert.Equal(800M, result);
        }
        [Fact]
        public void IsBasketClear()
        {
            //Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 200M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 100M };
            Cart target = new Cart();

            //Act
            target.AddItem(p1, 2);
            target.AddItem(p2, 4);
            target.RemoveLine(p1);
            target.RemoveLine(p2);

            //Assert
            Assert.Equal(0, target.lines.Count());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore1.Components.Navigation_Menu;
using SportsStore1.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace SportsStore1.Tests
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void Can_Select_Categories()
        {
            //Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductID = 1, Name = "P1", Category = "Jabłka"},
                new Product {ProductID = 2, Name = "P2", Category = "Jabłka"},
                new Product {ProductID = 3, Name = "P3", Category = "Śliwki"},
                new Product {ProductID = 4, Name = "P4",
                Category = "Pomarańcze"},
            }).AsQueryable<Product>());

            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);

            //Act pobieranie zbioru kategorii
            string[] results = ((IEnumerable<string>)(target.Invoke() as ViewComponentResult).ViewData.Model).ToArray();

            //Asserts

            Assert.True(Enumerable.SequenceEqual(new string[] { "Jabłka", "Pomarańcze", "Śliwki" }, results));

        }
        [Fact]
        public void Indicates_Selected_Category()
        {
            //Arrange
            string categoryToSelect = "Jabłka";
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]{
                new Product { ProductID = 1, Name = "P1", Category = "Jabłka" },
                new Product { ProductID = 4, Name = "P2", Category = "Pomarańcze" },
            }).AsQueryable<Product>());

            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);
            target.ViewComponentContext = new ViewComponentContext
            {
                ViewContext = new ViewContext
                {
                    RouteData = new RouteData()
                }
            };

            target.RouteData.Values["category"] = categoryToSelect;

            //ACT

            string result = (string)(target.Invoke() as ViewViewComponentResult).ViewData["SelectedCategory"];

            //ASssert

            Assert.Equal(categoryToSelect, result);
        }
    }
}

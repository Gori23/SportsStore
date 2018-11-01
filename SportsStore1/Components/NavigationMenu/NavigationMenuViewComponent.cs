using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStore1.Models; 

namespace SportsStore1.Components.Navigation_Menu
{
    public class NavigationMenuViewComponent:ViewComponent
    {
        private IProductRepository repository;
        public NavigationMenuViewComponent(IProductRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x));
        }
    }
}

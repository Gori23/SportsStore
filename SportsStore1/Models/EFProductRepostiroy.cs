using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore1.Models
{
    public class EFProductRepostiroy : IProductRepository
    {
        private ApplicationDbContext context;
        public EFProductRepostiroy(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Product> Products => context.Products;
    }
}

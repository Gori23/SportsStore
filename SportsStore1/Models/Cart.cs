using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore1.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(Product product, int quanity)
        {
            CartLine line = lineCollection.
                Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quanity = quanity
                });
            }
            else
            {
                line.Quanity += quanity;
            }
        }
        public virtual void RemoveLine(Product product) => lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        public virtual decimal ComputeTotalValue() => lineCollection.Sum(e => e.Product.Price * e.Quanity);
        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> lines => lineCollection;
    }
}

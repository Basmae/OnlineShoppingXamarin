using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingXamarin.Model
{
    public class Product
    {
        public Guid ID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    }
}

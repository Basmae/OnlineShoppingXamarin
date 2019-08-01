using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingXamarin.Model
{
    public class Cart
    {
        public Guid ID { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }

        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public bool IsSubmitted { get; set; }
        public string ProductName { get; set; }
    }
}

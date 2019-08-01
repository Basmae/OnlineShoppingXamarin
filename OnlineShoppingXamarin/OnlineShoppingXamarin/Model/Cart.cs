using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingXamarin.Model
{
    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public bool IsSubmitted { get; set; }
    }
}

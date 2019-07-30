using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingXamarin.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CartId { get; set; }
        public int UserId { get; set; }
    }
}

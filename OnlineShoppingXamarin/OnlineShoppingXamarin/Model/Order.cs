using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingXamarin.Model
{
    public class Order
    {
        public Guid ID { get; set; }
        public Guid CartId { get; set; }
        public Guid UserId { get; set; }
    }
}

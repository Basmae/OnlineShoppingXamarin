using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingXamarin.Model
{
    public class Image
    {
        public Guid ID { get; set; }
        public string ImageUrl { get; set; }
        public Guid ProductId { get; set; }
    }
}

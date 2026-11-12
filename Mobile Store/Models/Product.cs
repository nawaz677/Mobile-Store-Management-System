using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Product
    {
        public int product_id {  get; set; }
        public string company {  get; set; }
        public string series { get; set; }
        public string model { get; set; }
        public int stock_quantity { get; set; }
        public decimal current_price { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class OrderDetails
    {
        public int Order_Details_Id { get; set; }
        public int Order_Id { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public decimal Unit_Price { get; set; }

    }
}

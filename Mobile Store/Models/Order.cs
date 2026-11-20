using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Order
    {
        public int Order_Id { get; set; }
        public int Customer_Id { get; set; }
        public decimal Total_Amount { get; set; }
        public DateTime Order_Date { get; set; }
        public List<OrderDetails> order_details = new List<OrderDetails>();

    }
}

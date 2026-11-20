using System;
using System.Collections.Generic;
using System.Text;
using Data_Access_Layer;
using Models;

namespace Business_Logic_Layer
{
    public class OrderBLL
    {
       
        public bool ValidateOrderInProcess(OrderDetails od, int available_quantity)
        {
            if (od.Quantity > available_quantity)
            {
                return false;
            }

            return true;
        }

        public bool AddOrderInDatabase(Order order, Decimal grand_total)
        {
            OrderDAL dal = new OrderDAL();
            return dal.AddOrderInDatabase(order, grand_total);

        }


        public List<Order> GetOrdersList()
        {
            OrderDAL dal = new OrderDAL();
            return dal.GetOrdersList();
        }

    }
}

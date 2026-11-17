using System;
using System.Collections.Generic;
using System.Text;
using Data_Access_Layer;
using Models;

namespace Business_Logic_Layer
{
    public class OrderBLL
    {
        public string ValidateOrder(Product prd, Customer cust, Order o, OrderDetails od)
        {
            if (o.Total_Amount <=0)
            {
                return "Error".ToLower();
            }

            else
            {
                OrderDAL dal = new OrderDAL();
                int rows = dal.AddOrderInDatabase(prd, cust, o, od);
                if (rows > 0)
                {
                    return "Added".ToLower();
                }

                else
                {
                    return "Error".ToLower();
                }

            }
            

        }


        public List<Order> GetOrdersList()
        {
            OrderDAL dal = new OrderDAL();
            return dal.GetOrdersList();
        }

    }
}

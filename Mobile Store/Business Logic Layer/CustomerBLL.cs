using System;
using System.Collections.Generic;
using System.Text;
using Data_Access_Layer;
using Models;

namespace Business_Logic_Layer
{
    public class CustomerBLL
    {
        public List<Customer> GetCustomersList()
        {
            CustomerDAL cust = new CustomerDAL();
            return cust.GetCustomersList();
        }

        public int AddCustomer(Customer cust)
        {
            CustomerDAL dal = new CustomerDAL();
            return dal.AddCustomer(cust);
        }

        public Customer ValidateCustomer(Customer cust, string msg)
        {
            List<Customer> customers = GetCustomersList();
            
            foreach (Customer customer in customers)
            {
                if (customer.First_Name == cust.First_Name && customer.Last_Name == cust.Last_Name && customer.Phone_Number == cust.Phone_Number)
                {
                    if (msg.ToLower() == "delete")
                    {
                        CustomerDAL dal = new CustomerDAL();
                        int rows = dal.DeleteCustomer(customer);
                        if (rows == 1)
                        {
                            // not a good practice to return customer here, just doing to avoid using an extra function
                            return customer;
                        }
                    }

                    else if (msg.ToLower() == "update")
                    {
                        return customer;                    
                    }
                    
                }
            }

            return null;
        }
 
        public int UpdateCustomerDetails(Customer customer)
        {
            CustomerDAL dal = new CustomerDAL();
            return dal.UpdateCustomerDetails(customer);
        }


    }
}

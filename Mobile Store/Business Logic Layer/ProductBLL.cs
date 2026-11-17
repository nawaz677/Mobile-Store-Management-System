using System;
using System.Collections.Generic;
using System.Text;
using Data_Access_Layer;
using Models;

namespace Business_Logic_Layer
{
    public class ProductBLL
    {
        // Below method is required for Viewing Products
        public List<Product> GetProductsList()
        {
            ProductDAL prd = new ProductDAL();
            return prd.GetProductsList();
        }

        public bool ValidateUserEnteredProduct(Product prd)
        {
            if(prd.Stock_Quantity < 0)
            {
                return false;
            }

            if (prd.Current_Price < 15000)
            {
                return false;
            }

            return true;
        }

        public int FurtherPassValidatedProduct(Product prd, string msg)
        {
            ProductDAL product = new ProductDAL();
            int rows; 

            if (msg == "add")
            {
                rows = product.AddProductInDatabase(prd);
                return rows;
            }

            else if (msg == "update")
            {
                rows = product.UpdateProductInDatabase(prd);
                return rows;
            }

            else if (msg == "delete")
            {
                rows = product.RemoveProductFromDatabase(prd);
                return rows;
            }

            return 0;
            
        }

        public Product ValidateStringCredentials(List<Product> products, Product prd)
        {
            foreach (Product product in products)
            {
                if (prd.Company == product.Company && prd.Series == product.Series && prd.Model == product.Model)
                {
                    return product;
                }
            }
            return null;
        }
    }
}

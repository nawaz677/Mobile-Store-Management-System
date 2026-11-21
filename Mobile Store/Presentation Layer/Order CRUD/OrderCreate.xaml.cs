using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Business_Logic_Layer;
using Data_Access_Layer;
using Models;

namespace Presentation_Layer.Order_CRUD
{
    /// <summary>
    /// Interaction logic for OrderCreate.xaml
    /// </summary>
    public partial class OrderCreate : Window
    {
        private Order order = new Order();
        private decimal grand_total = 0;
        private OrderBLL bll = new OrderBLL();
        List<Product> added_products = new List<Product>(); // This list contains those products which are added in an order

        public OrderCreate()
        {
            InitializeComponent();
            // Giving 'Products_ComboBox' values
            ProductBLL prd_bll = new ProductBLL();
            List<Product> products = prd_bll.GetProductsList();
            Products_ComboBox.ItemsSource = products;
            Products_ComboBox.DisplayMemberPath = "Products";
            Products_ComboBox.SelectedValuePath = "Product_Id";

            // Giving 'Customers_ComboBox' values
            CustomerBLL cust_bll = new CustomerBLL();
            List<Customer> customers = cust_bll.GetCustomersList();
            Customers_ComboBox.ItemsSource = customers;
            Customers_ComboBox.DisplayMemberPath = "Customers";
            Customers_ComboBox.SelectedValuePath = "Customer_Id";
            
        }

        private void Place_Order_Button_Click(object sender, RoutedEventArgs e)
        {
            if (added_products.Count() > 0)
            {
                bool result = bll.AddOrderInDatabase(order, added_products, grand_total);

                if (result)
                {
                    MessageBox.Show("Order Placed Successfully!");
                }
                this.Close();
            }

            else
            {
                MessageBox.Show("Error! No product added in the cart");
            }

        }

        private void Quantity_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calculate_Total_Amount();
        }

        private void Unit_Price_TextChanged(object sender, TextChangedEventArgs e)
        {
            Calculate_Total_Amount();
        }

        private void Calculate_Total_Amount()
        {
            if ( int.TryParse(Quantity_Textbox.Text, out int qty) && decimal.TryParse(Unit_Price_Textbox.Text, out decimal unit_price) )
            {
                decimal total_amount = qty * unit_price;
                Total_Amount_Textbox.Text = total_amount.ToString();
            }

            else
            {
                Total_Amount_Textbox.Text = "";
            }
        }

        private void Products_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product prd = (Product)Products_ComboBox.SelectedItem;
            Unit_Price_Textbox.Text = prd.Current_Price.ToString();
            Available_Quantity_Textbox.Text = prd.Stock_Quantity.ToString();

        }


        private int count = 0; // This variable will check how many times the below function has run. It will be crucial in locking a customer in the ComboBox if that customer has added a product, i-e started an order.
        private void Add_Product_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer c = (Customer)Customers_ComboBox.SelectedItem;
                order.Customer_Id = c.Customer_Id;
                OrderDetails od = new OrderDetails();
                Product p = (Product)Products_ComboBox.SelectedItem;
                od.Product_Id = p.Product_Id;
                od.Quantity = Convert.ToInt32(Quantity_Textbox.Text);
                od.Unit_Price = Convert.ToDecimal(Unit_Price_Textbox.Text);

                // The object is created above as an attribute...
                bool result = bll.ValidateOrderInProcess(od, Convert.ToInt32(Available_Quantity_Textbox.Text));

                if (!result)
                {
                    MessageBox.Show("Error! Invalid Quantity of Product Selected");
                }

                else
                {
                    grand_total += Convert.ToInt32(Total_Amount_Textbox.Text);
                    order.order_details.Add(od); // Adding 'order_details' of each product in the list

                    p.Stock_Quantity -= od.Quantity;
                    added_products.Add(p); // Adding the product in the list

                    MessageBox.Show("Product Added Successfully in the order!");
                    Quantity_Textbox.Clear();
                    Unit_Price_Textbox.Clear();
                    Total_Amount_Textbox.Clear();
                    Available_Quantity_Textbox.Clear();

                    count += 1;
                    Customers_ComboBox.IsEnabled = false; // Disabling ComboBox so an order gets placed by only one customer
                }
            }

            catch
            {
                MessageBox.Show("Please select customer and add a product in the cart to proceed!");
                
            }
            
        }

        
    }
}

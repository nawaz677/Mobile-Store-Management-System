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
        public OrderCreate()
        {
            InitializeComponent();
            ProductBLL prd_bll = new ProductBLL();
            List<Product> products = prd_bll.GetProductsList();
            Products_ComboBox.ItemsSource = products;
            Products_ComboBox.DisplayMemberPath = "Products";
            Products_ComboBox.SelectedValuePath = "Product_Id";

            CustomerBLL cust_bll = new CustomerBLL();
            List<Customer> customers = cust_bll.GetCustomersList();
            Customers_ComboBox.ItemsSource = customers;
            Customers_ComboBox.DisplayMemberPath = "Customers";
            Customers_ComboBox.SelectedValuePath = "Customer_Id";
            
        }

        private void Place_Order_Button_Click(object sender, RoutedEventArgs e)
        {
            Product product = (Product)Products_ComboBox.SelectedItem;
            Customer customer = (Customer)Customers_ComboBox.SelectedItem;
            Order o = new Order();
            OrderDetails od = new OrderDetails();
            od.Quantity = Convert.ToInt32(Quantity_Textbox.Text);
             od.Unit_Price = Convert.ToDecimal(Unit_Price_Textbox.Text);
            o.Total_Amount = Convert.ToDecimal(Total_Amount_Textbox.Text);

            OrderBLL bll = new OrderBLL();
            string order = bll.ValidateOrder(product, customer, o, od);

            if (order == "Error".ToLower())
            {
                MessageBox.Show("Error! can not place Order");
            }

            else
            {
                MessageBox.Show("Success! Order placed");
                this.Close();
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
        }


    }
}

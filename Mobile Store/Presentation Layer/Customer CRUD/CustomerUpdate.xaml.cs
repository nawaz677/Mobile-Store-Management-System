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
using Models;

namespace Presentation_Layer.Customer_CRUD
{
    /// <summary>
    /// Interaction logic for CustomerUpdate.xaml
    /// </summary>
    public partial class CustomerUpdate : Window
    {
        public CustomerUpdate()
        {
            InitializeComponent();
        }

        private void click_to_proceed_Button_Click(object sender, RoutedEventArgs e)
        {
            Customer cust = new Customer();
            cust.first_name = first_name_Textbox.Text;
            cust.last_name = last_name_Textbox.Text;
            cust.phone_number = phone_number_Textbox.Text;

            CustomerBLL bll = new CustomerBLL();
            Customer customer = bll.ValidateCustomer(cust, "update");

            if (customer != null)
            {
                MessageBox.Show("Customer exists, you can continue!");
                CustomerUpdateDetails cud = new CustomerUpdateDetails(customer);
                cud.Owner = this;
                cud.Show();
            }

            else
            {
                MessageBox.Show("Error! customer does not exist");
                this.Close();
            }
        }
    }
}

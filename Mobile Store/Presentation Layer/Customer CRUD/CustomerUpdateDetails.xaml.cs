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
    /// Interaction logic for CustomerUpdateDetails.xaml
    /// </summary>
    public partial class CustomerUpdateDetails : Window
    {
        private Customer cust;
        public CustomerUpdateDetails(Customer customer)
        {
            InitializeComponent();
            cust = customer;
        }

        private void click_to_update_Button_Click(object sender, RoutedEventArgs e)
        {
            cust.first_name = first_name_Textbox.Text;
            cust.last_name = last_name_Textbox.Text;
            cust.age = Convert.ToInt32(age_Textbox.Text);
            cust.phone_number = phone_number_Textbox.Text;
            cust.address = address_Textbox.Text;

            CustomerBLL bll = new CustomerBLL();
            int rows = bll.UpdateCustomerDetails(cust);

            if (rows == 1)
            {
                MessageBox.Show("Customer Updated Successfully!");
                this.Close();
            }

        }
    }
}

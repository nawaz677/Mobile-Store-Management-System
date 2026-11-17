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
    /// Interaction logic for CustomerAdd.xaml
    /// </summary>
    public partial class CustomerAdd : Window
    {
        public CustomerAdd()
        {
            InitializeComponent();
        }

        private void click_here_to_add_Button_Click(object sender, RoutedEventArgs e)
        {
            Customer cust = new Customer();
            cust.First_Name = first_name_Textbox.Text;
            cust.Last_Name = last_name_Textbox.Text;
            cust.Age = Convert.ToInt32(age_Textbox.Text);
            cust.Phone_Number = phone_number_Textbox.Text;
            cust.Address = address_Textbox.Text;

            CustomerBLL bll = new CustomerBLL();
            int rows = bll.AddCustomer(cust);

            if(rows == 1)
            {
                MessageBox.Show("Customer Added Successfully!");
            }

            this.Close();
        }
    }
}

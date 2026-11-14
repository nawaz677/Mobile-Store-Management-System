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

namespace Presentation_Layer.Customer_CRUD
{
    /// <summary>
    /// Interaction logic for CustomersMainWindow.xaml
    /// </summary>
    public partial class CustomersMainWindow : Window
    {
        public CustomersMainWindow()
        {
            InitializeComponent();
        }

        private void View_Customers_Button_Click(object sender, RoutedEventArgs e)
        {
            CustomerView cust_view = new CustomerView();
            cust_view.Owner = this;
            cust_view.Show();

        }

        private void Add_Customer_Button_Click(object sender, RoutedEventArgs e)
        {
            CustomerAdd add_customer = new CustomerAdd();
            add_customer.Owner = this;
            add_customer.Show();
        }

        private void delete_customer_button_Click(object sender, RoutedEventArgs e)
        {
            CustomerDelete dlt = new CustomerDelete();
            dlt.Owner = this;
            dlt.Show();
        }

        private void Update_Customer_Button_Click(object sender, RoutedEventArgs e)
        {
            CustomerUpdate cust_update = new CustomerUpdate();
            cust_update.Owner = this;
            cust_update.Show();
        }
    }
}

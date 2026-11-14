using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;
using Business_Logic_Layer;
using Models;
using Presentation_Layer.Customer_CRUD;

namespace Presentation_Layer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Products_Main_Button_Click(object sender, RoutedEventArgs e)
        {
            ProductsMainPage products_main_page = new ProductsMainPage();
            products_main_page.Owner = this;
            products_main_page.Show();
        }

        private void Customers_Button_Click(object sender, RoutedEventArgs e)
        {
            CustomersMainWindow cust_main = new CustomersMainWindow();
            cust_main.Owner = this;
            cust_main.Show();
        }
    }
}
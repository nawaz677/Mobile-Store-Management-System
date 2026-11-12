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

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductAdd add_product = new ProductAdd();
            add_product.Owner = this;
            add_product.ShowDialog();
        }

        private void ViewProducts_Button_Click(object sender, RoutedEventArgs e)
        {
            ProductView view_product = new ProductView();
            view_product.Owner = this;
            view_product.ShowDialog();
        }


        private void Update_Product_Button_Click(object sender, RoutedEventArgs e)
        {
            ProductUpdate update_product = new ProductUpdate();
            update_product.Owner = this;
            update_product.ShowDialog();
        }

        private void Delete_Product_Button_Click(object sender, RoutedEventArgs e)
        {
            ProductDelete delete_product = new ProductDelete();
            delete_product.Owner = this;
            delete_product.ShowDialog();
        }

        
    }
}
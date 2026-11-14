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

namespace Presentation_Layer
{
    /// <summary>
    /// Interaction logic for ProductsMainPage.xaml
    /// </summary>
    public partial class ProductsMainPage : Window
    {
        public ProductsMainPage()
        {
            InitializeComponent();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductAdd add_product = new ProductAdd();
            add_product.Owner = Window.GetWindow(this);
            add_product.ShowDialog();
        }

        private void ViewProducts_Button_Click(object sender, RoutedEventArgs e)
        {
            ProductView view_product = new ProductView();
            view_product.Owner = Window.GetWindow(this);
            view_product.ShowDialog();
        }

        private void Update_Product_Button_Click(object sender, RoutedEventArgs e)
        {
            ProductUpdate update_product = new ProductUpdate();
            update_product.Owner = Window.GetWindow(this);
            update_product.ShowDialog();
        }

        private void Delete_Product_Button_Click(object sender, RoutedEventArgs e)
        {
            ProductDelete delete_product = new ProductDelete();
            delete_product.Owner = Window.GetWindow(this);
            delete_product.ShowDialog();
        }


    }
}

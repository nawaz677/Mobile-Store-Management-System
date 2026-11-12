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
using Models;
using Business_Logic_Layer;

namespace Presentation_Layer
{
    /// <summary>
    /// Interaction logic for ProductUpdate2.xaml
    /// </summary>
    public partial class ProductUpdate2 : Window
    {
        private Product _product;
        public ProductUpdate2(Product product)
        {
            InitializeComponent();

            _product = product;
        }

        //public Product GetProductFromUpdate1(Product product)
        //{
        //    return product;
        //}

        private void Click_to_Update_2_Button_Click(object sender, RoutedEventArgs e)
        {
            _product.stock_quantity = Convert.ToInt32(Stock_Quantity_Textbox.Text);
            _product.current_price = Convert.ToDecimal(Current_Price_Textbox.Text);

            ProductBLL bll = new ProductBLL();
            bool result = bll.ValidateUserEnteredProduct(_product);

            if (result == false)
            {
                MessageBox.Show("Invalid value(s) entered!");
            }

            int rows = bll.FurtherPassValidatedProduct(_product, "update");

            if (rows > 0)
            {
                MessageBox.Show("Product Updated Successfully!");
                this.Close();
            }
        }
    }
}

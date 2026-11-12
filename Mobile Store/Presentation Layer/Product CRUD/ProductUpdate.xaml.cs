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
    /// Interaction logic for ProductUpdate.xaml
    /// </summary>
    public partial class ProductUpdate : Window
    {
        public ProductUpdate()
        {
            InitializeComponent();
        }

        private void Click_to_Update_Button_Click(object sender, RoutedEventArgs e)
        {
            Product prd = new Product();
            prd.company = Company_Textbox.Text;
            prd.series = Series_Textbox.Text;
            prd.model = Model_Textbox.Text;
            // prd.stock_quantity = Convert.ToInt32(Stock_Quantity_Textbox.Text);
            // prd.current_price = Convert.ToDecimal(Current_Price_Textbox.Text);
            
            ProductBLL bll = new ProductBLL();
            List<Product> products = bll.GetProductsList();

            Product verified_product = bll.ValidateStringCredentials(products, prd);
            if (verified_product != null)
            {
                MessageBox.Show("Your desired product exists, you can continue!");
                ProductUpdate2 update_product = new ProductUpdate2(verified_product);
                update_product.Owner = this;
                update_product.ShowDialog();
                this.Close();
            }

            else
            {
                MessageBox.Show("Invalid product entered!");
            }

        }
    }
}

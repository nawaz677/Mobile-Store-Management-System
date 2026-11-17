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
    /// Interaction logic for ProductDelete.xaml
    /// </summary>
    public partial class ProductDelete : Window
    {
        public ProductDelete()
        {
            InitializeComponent();
        }

        private void Click_to_Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            Product prd = new Product();
            prd.Company = Company_Textbox.Text;
            prd.Series = Series_Textbox.Text;
            prd.Model = Model_Textbox.Text;

            ProductBLL bll = new ProductBLL();
            List<Product> products = bll.GetProductsList();

            Product product = bll.ValidateStringCredentials(products, prd);

            if (product == null)
            {
                MessageBox.Show("Error! product does not exist");
            }

            else
            {
                int rows = bll.FurtherPassValidatedProduct(product, "delete");

                if (rows == 1)
                {
                    MessageBox.Show("Product Successfully Deleted!");
                }
            }

            this.Close();
        }

    }
}

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
    /// Interaction logic for ProductAdd.xaml
    /// </summary>
    public partial class ProductAdd : Window
    {
        public ProductAdd()
        {
            InitializeComponent();
        }

        private void Click_to_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Product prd = new Product();
            prd.company = Company_TextBox.Text;
            prd.series = Series_Textbox.Text;
            prd.model = Model_Textbox.Text;
            prd.stock_quantity = Convert.ToInt32(Stock_Quantity_Textbox.Text);
            prd.current_price = Convert.ToDecimal(Current_Price_Textbox.Text);
            ProductBLL bll = new ProductBLL();
            bool result = bll.ValidateUserEnteredProduct(prd);

            if (result == false)
            {
                MessageBox.Show("Validation Error!");
            }

            int rows = bll.FurtherPassValidatedProduct(prd, "add");

            if (rows > 0)
            {
                MessageBox.Show("Product Added Successfully!");
            }

            // Closes the dialog and returns true to ShowDialog()
            // could also use 'this.Close();'
            this.DialogResult = true;
        }
  
    }
}

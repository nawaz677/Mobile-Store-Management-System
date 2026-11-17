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

namespace Presentation_Layer.Order_CRUD
{
    /// <summary>
    /// Interaction logic for OrdersMainWindow.xaml
    /// </summary>
    public partial class OrdersMainWindow : Window
    {
        public OrdersMainWindow()
        {
            InitializeComponent();
        }

        private void Create_Order_Button_Click(object sender, RoutedEventArgs e)
        {
            OrderCreate ord_create = new OrderCreate();
            ord_create.Owner = this;
            ord_create.Show();
        }

        private void View_Orders_Button_Click(object sender, RoutedEventArgs e)
        {
            OrderView ord_view = new OrderView();
            ord_view.Owner = this;
            ord_view.Show();
        }
    }
}

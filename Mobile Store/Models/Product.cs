using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Product
    {
        public int Product_Id {  get; set; }
        public string Company {  get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public int Stock_Quantity { get; set; }
        public decimal Current_Price { get; set; }

        // Using a compound property for ComboBox.DispalyMemeberPath
        public string Products => $"{Company} {Series} {Model}";

    }
}

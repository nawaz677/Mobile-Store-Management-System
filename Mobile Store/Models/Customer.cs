using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Customer
    {
        public int Customer_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }   
        public int Age { get; set; }
        public string Phone_Number { get; set; }
        public string Address { get; set; }

        // Using a compound property for ComboBox.DispalyMemeberPath
        public string Customers => $"{First_Name} {Last_Name} {Phone_Number}";

    }
}

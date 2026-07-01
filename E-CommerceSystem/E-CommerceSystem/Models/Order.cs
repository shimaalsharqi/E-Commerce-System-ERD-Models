using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Models
{
    public class Order
    {
        public int orderId { get; set; }//System Genrated
        public int userId { get; set; }//From List ,foreign key
        public DateTime orderDate { get; set; }//System Genrated
        public string status { get; set; }//User input
        public string shippingAddress { get; set; }//User input
        public decimal totalAmount { get; set; }//Calculated
        public int paymentMethod { get; set; }//User input
    }
}

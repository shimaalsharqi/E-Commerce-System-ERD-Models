using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Models
{
    public class Product
    {
        public int productId { get; set; }//System Genrated
        public int categoryId { get; set; }//From List ,foreign key
        public string productName { get; set; }//User input
        public string description { get; set; }//User input
        public decimal price { get; set; }//User input
        public int stockQuantity { get; set; }//User input
        public string imageUrl { get; set; }//User input
        public string address { get; set; }//User input
        public DateTime createdAt { get; set; }//System Genrated
        public bool isAvailable { get; set; } = true; //Defult Value
    }
}

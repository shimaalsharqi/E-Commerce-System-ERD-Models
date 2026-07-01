using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Models
{
    [Table("Product")]

    public class Product
    {
        [Key]
        [Required]
        //unique
        public int productId { get; set; }//System Genrated
        [Required]
        [MaxLength(150)]
        public string? productName { get; set; }//User input
        [Required]
        [ForeignKey("Category")] 
        public int categoryId { get; set; }//From List ,foreign key
        //Optional
        [MaxLength(1000)]
        public string description { get; set; }//User input
        [Required]
        [Range(0.01,double.MaxValue)]
        public decimal price { get; set; } = 0;//User input
        [Required]
        [Range(0.0, double.MaxValue)]
        public int stockQuantity { get; set; }//User input
        //Optional
        [MaxLength(300)]
        public string imageUrl { get; set; }//User input
        [Required]
        public DateTime createdAt { get; set; }//System Genrated
        public bool isAvailable { get; set; } = true; //Defult Value


        // RELATIONSHIPS
        public List<Order> Orders { get; set; }// Navigation property 
        public List<Review> Reviews { get; set; }// // Navigation property 
        public Category Category { get; set; }// Navigation property 
    }
}

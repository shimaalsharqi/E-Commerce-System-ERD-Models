using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderId { get; set; }//System Genrated
        [Required]
        [ForeignKey("User")]
        public int userId { get; set; }//From List ,foreign key
        [Required]
        public DateTime orderDate { get; set; }//System Genrated
        [Required]
        [MaxLength(30)]
        public string status { get; set; } = "Pending";//Defult Value
        [Required]
        [MaxLength(30)]
        public string shippingAddress { get; set; }//User input
        [Range(0.0, double.MaxValue)]
        [Column(TypeName = "decimal(10,2)")]
        [Required]
        public decimal totalAmount { get; set; }//Calculated
        [Required]
        [MaxLength(50)]
        public string paymentMethod { get; set; }//User input

        // RELATIONSHIPS
        public virtual User User { get; set; }// Navigation property 
        public virtual List<OrderItem> OrderItem { get; set; }// Navigation property 
    }
}

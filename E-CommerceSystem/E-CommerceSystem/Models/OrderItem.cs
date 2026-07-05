using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderItemId { get; set; }              // system generated

        [Required]
        [Range(1, 999)]
        public int quantity { get; set; } // user input


        [Required]
        [ForeignKey("Order")]
        public int orderId { get; set; }//From List ,foreign key
        public Order Order { get; set; }


        [Required]
        [ForeignKey("Product")]
        public int productId { get; set; }//From List ,foreign key
        public Product Product { get; set; }
    }
}

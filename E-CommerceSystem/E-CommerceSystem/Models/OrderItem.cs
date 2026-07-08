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
        public virtual Order Order { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal unitPrice { get; set; }//User Input


        [Required]
        [ForeignKey("Product")]
        public int productId { get; set; }//From List ,foreign key
        public virtual Product Product { get; set; }
    }
}

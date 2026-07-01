using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Models
{
    [Table("Review")]
    public class Review
    {
        [Key]
        [Required]
        //unique
        public int reviewId { get; set; }//System Genrated
        [Required]
        [ForeignKey("User")]
        public int userId { get; set; }//From List ,foreign key
        [Required]
        [ForeignKey("Product")]
        public int productId { get; set; }//From List ,foreign key
        [Required]
        [Range(1,5)]
        public int rating { get; set; }//From List ,foreign key
        [Required]
        public DateTime reviewDate { get; set; }//System Genrated
        //Optional
        [MaxLength(1000)]
        public string comment { get; set; }//User input

        // RELATIONSHIPS
        public User User { get; set; }// Navigation property 
        public Product Product { get; set; }// Navigation property 
    }
}

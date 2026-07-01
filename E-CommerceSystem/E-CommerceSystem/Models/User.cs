using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [Required]
        public int userId { get; set; }//System Genrated
        [Required]
        [MaxLength(50)]
        //unique
        public string username { get; set; }//User input
        [Required]
        [MaxLength(150)]
        //unique
        public string email { get; set; }//User input
        [Required]
        [MaxLength(256)]
        public string passwordHash { get; set; }//User input
        [Required]
        [MaxLength(100)]
        public string fullName { get; set; }//User input
        //Optional
        [MaxLength(20)]
        public string? phoneNumber { get; set; }//User input
        //Optional
        [MaxLength(300)]
        public string? address { get; set; }//User input
        [Required]
        public DateTime registrationDate { get; set; }//System Genrated
        public bool isActive { get; set; } = true; //Defult Value


        // RELATIONSHIPS
        public List<Order> Orders { get; set; }// // Navigation property 
        public List<Review> Reviews { get; set; }// // Navigation property 
    }
}

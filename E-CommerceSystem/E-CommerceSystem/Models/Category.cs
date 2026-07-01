using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [Required]
        //unique
        public int categoryId { get; set; }//System Genrated
        [Required]
        [MaxLength(100)]
        //unique
        public string categoryName { get; set; }//User input
        //Optional
        [MaxLength(500)]
        public string? description { get; set; }//User input
        //Optional
        [MaxLength(300)]
        public string? imageUrl { get; set; }//User input
    }
}

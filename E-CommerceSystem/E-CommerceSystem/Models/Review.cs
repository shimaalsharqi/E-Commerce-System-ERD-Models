using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Models
{
    public class Review
    {
        public int reviewId { get; set; }//System Genrated
        public int userId { get; set; }//From List ,foreign key
        public int productId { get; set; }//From List ,foreign key
        public int rating { get; set; }//From List ,foreign key
        public DateTime reviewDate { get; set; }//System Genrated
        public string comment { get; set; }//User input
    }
}

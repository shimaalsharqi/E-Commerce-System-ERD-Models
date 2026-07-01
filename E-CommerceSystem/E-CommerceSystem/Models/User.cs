using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Models
{
    public class User
    {
        public int userId { get; set; }//System Genrated
        public string username { get; set; }//User input
        public string email { get; set; }//User input
        public string passwordHash { get; set; }//User input
        public string fullName { get; set; }//User input
        public string phoneNumber { get; set; }//User input
        public string address { get; set; }//User input
        public DateTime registrationDate { get; set; }//System Genrated
        public bool isActive { get; set; } = true; //Defult Value
    }
}

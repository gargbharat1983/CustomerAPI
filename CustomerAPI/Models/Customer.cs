using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required,MaxLength(50)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required,MinLength(10),MaxLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}

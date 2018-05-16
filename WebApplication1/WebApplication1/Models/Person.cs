using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Person
    {
        [DisplayName("Primary Key")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Range(0,200)]
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
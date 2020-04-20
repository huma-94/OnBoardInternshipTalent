using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace OnboardInternship.Models
{
    public class CustomerModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
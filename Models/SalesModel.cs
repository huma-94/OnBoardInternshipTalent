using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnboardInternship.Models
{
    public class SalesModel
    {
        [Key]
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string CustomerId { get; set; }

        public string StoreId { get; set; }
        public DateTime? DateSold { get; set; }
    }
}
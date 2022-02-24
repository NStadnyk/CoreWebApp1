using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp1.Models
{
    public class Book
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public string PublishingHouse { get; set; }

        [Required]
        public DateTime Year { get; set; }

        [Required]
        public double Price { get; set; }
    }
}

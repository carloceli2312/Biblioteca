using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = "Default";

        [Required]
        public string Author { get; set; } = "Default";
        
        public int PublicationYear { get; set; }
        
        public bool IsAvailable { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Book
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Author { get; set; }
        
        [StringLength(13)]
        public string ISBN { get; set; }
        
        public int PublicationYear { get; set; }
        
        public bool IsAvailable { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Loan
    {
        public int Id { get; set; }
        
        public int BookId { get; set; }
        public Book Book { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
        
        [Required]
        public DateTime LoanDate { get; set; }
        
        [Required]
        public DateTime DueDate { get; set; }
        
        public DateTime? ReturnDate { get; set; }
    }
}
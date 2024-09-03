using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class User
        {
            public int Id { get; set; }
            
            [Required]
            [StringLength(50)]
            public string Name { get; set; }
            
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            
            public List<Loan> Loans { get; set; }
        }
}
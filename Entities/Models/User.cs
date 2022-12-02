using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class User
    {
        [Column("UserId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "User name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is a required field.")]
        [MaxLength(250, ErrorMessage = "Maximum length for the Email is 250 characters.")]
        public string Email { get; set; }

        [Required]
        public decimal Balance { get; set; }

        public string? Address { get; set; }
        
        public DateTime? Birthday { get; set; }
    }
}

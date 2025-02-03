using System.ComponentModel.DataAnnotations;

namespace Programacion3Template.Models
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;

        public virtual Token? Token { get; set; }
    }
}

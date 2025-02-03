using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Programacion3Template.Models
{
    public class Token
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Value { get; set; } = string.Empty;

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Usuario Usuario { get; set; } = null!;
    }
}

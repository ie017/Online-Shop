using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartService.Models{
    [Table("Bill")]
    public class Bill{
        [Key]
        public string? billingId{get; set;}
        [Required]
        public DateTime issueDate{get; set;}
        [Required]
        public DateTime dueDate{get; set;}
        [Required]
        public double sum{get; set;}
    }
}
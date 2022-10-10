using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartService.Models{
    public class Bill{
        public string? billingId{get; set;}
        public DateTime issueDate{get; set;}
        public DateTime dueDate{get; set;}
        public double sum{get; set;}
    }
}
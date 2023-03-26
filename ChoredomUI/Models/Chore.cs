using System.ComponentModel.DataAnnotations;

namespace ChoredomUI.Models
{
    public class Chore
    {
        public int ChoreId { get; set; }
        [Required]
        public string ChoreName { get; set; } = string.Empty;
        [Required]
    }
}

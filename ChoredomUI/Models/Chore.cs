using System.ComponentModel.DataAnnotations;

namespace ChoredomUI.Models
{
    public class Chore
    {
        [Required]
        public int ChoreId { get; set; }
        [Required]
        public string ChoreName { get; set; } = string.Empty;
    }
}

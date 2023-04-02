using System.ComponentModel.DataAnnotations;

namespace ChoredomUI.Models
{
    public class Person
    {
        [Required]
        public int PersonId { get; set; }
        [Required]
        public string PersonFirstName { get; set; } = string.Empty;
        [Required]
        public string PersonLastName { get; set; } = string.Empty;

    }
}

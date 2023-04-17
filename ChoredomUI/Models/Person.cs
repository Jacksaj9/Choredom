using System.ComponentModel.DataAnnotations;

namespace ChoredomUI.Models
{
    public class Person
    {
        [Required]
        public int PersonId { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public object PersonBio { get; internal set; }
    }
}

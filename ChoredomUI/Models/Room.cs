using System.ComponentModel.DataAnnotations;

namespace ChoredomUI.Models
{
    public class Room
    {
        [Required]
        public int RoomId { get; set; }
        [Required]
        public string RoomName { get; set; } = string.Empty;

    }
}

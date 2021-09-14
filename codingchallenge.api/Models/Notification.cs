using System.ComponentModel.DataAnnotations;

namespace codingchallenge.api.Models
{
    public class Notification
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string Email { get; set; }

        public string NotificationType { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string Supervisor { get; set; }
    }
}
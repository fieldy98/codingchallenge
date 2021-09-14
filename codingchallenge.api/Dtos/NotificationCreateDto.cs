using System.ComponentModel.DataAnnotations;

namespace codingchallenge.api.Dtos
{
    public class NotificationCreateDto
    {
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
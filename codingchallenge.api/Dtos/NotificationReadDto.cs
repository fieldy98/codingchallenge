namespace codingchallenge.api.Dtos
{
    public class NotificationReadDto
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string NotificationType { get; set; }
        public string PhoneNumber { get; set; }
        public string Supervisor { get; set; }
    }
}
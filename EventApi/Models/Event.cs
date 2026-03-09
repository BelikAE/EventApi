namespace EventApi.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartAt { get; set; } = DateTime.UtcNow;
        public DateTime EndAt { get; set; }
    }
}

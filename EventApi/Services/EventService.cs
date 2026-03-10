using EventApi.Interfaces;
using EventApi.Models;

namespace EventApi.Services
{
    public class EventService : IEventService
    {
        // Коллекция для манипуляции номерами зданий

        private readonly List<Event> _events = new List<Event>
        {
            new Event
            {
                Id = 1,
                Title = "Конференция",
                Description = "Ежегодная конференция",
                StartAt = DateTime.UtcNow.AddDays(10),
                EndAt = DateTime.UtcNow.AddDays(10).AddHours(5)
            },
            new Event
            {
                Id = 2,
                Title = "Хакатон",
                Description = "Соревнование по  чему-то",
                StartAt = DateTime.UtcNow.AddDays(20),
                EndAt = DateTime.UtcNow.AddDays(20).AddHours(8)
            },
            new Event
            {
                Id = 3,
                Title = "Встреча сообщества",
                Description = "Встреча неполнятных людей",
                StartAt = DateTime.UtcNow.AddDays(5),
                EndAt = DateTime.UtcNow.AddDays(5).AddHours(2)
            }
        };


        public Event GetById(int id)
        {
           return _events.FirstOrDefault(e => e.Id == id);

        }

        public IEnumerable<Event> GetAll()
        {
            return _events;
        }

        public Event CreateEvent(Event newEvent)
        {
            newEvent.Id = _events.Any() ? _events.Max(o => o.Id) + 1 : 1;

            _events.Add(newEvent);
            return newEvent;
        }

        public bool Update(int id, Event updatedEvent)
        {
            var existing = GetById(id);
            if (existing is null) return false;

            existing.Title = updatedEvent.Title;
            existing.Description = updatedEvent.Description;
            existing.StartAt = updatedEvent.StartAt;
            existing.EndAt = updatedEvent.EndAt;

            return true;

        }

        public bool Delete(int id)
        {
            var ev = GetById(id);
            if (ev is null) return false;

            _events.Remove(ev);
            return true;
        }

      
    }
}

using EventApi.Models;

namespace EventApi.Interfaces
{
    public interface IEventService
    {
        Event GetById(int id);
        IEnumerable<Event> GetAll();
        Event CreateEvent(Event items);
        bool Update(int id, Event items);
        bool Delete(int id);
    }
}

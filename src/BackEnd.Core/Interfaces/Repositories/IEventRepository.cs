using BackEnd.Models;

namespace BackEnd.Core.Interfaces.Repositories
{
    public interface IEventRepository
    {
        Task CreateEvent(Event data);

        Task<Guid> CreateCalendar(string name, Guid UserId);

        Task<Dictionary<Guid, string>> GetAllCalendars(Guid UserId);

        Task<List<Event>> GetAllEvents();

        Task UpdateEvents(Event event1);
        Task DeleteEvent(Guid IdGuid);
    }
}

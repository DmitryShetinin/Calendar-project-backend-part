using BackEnd.Models;
using BackEnd.Core.Interfaces.Repositories;


namespace BackEnd.Application.Services
{
    public class EventService : IEventRepository
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task CreateEvent(Event data)
        {
            await _eventRepository.CreateEvent(data);
        }
        public async Task<Guid> CreateCalendar(string name, Guid userId)
        {
            return await _eventRepository.CreateCalendar(name, userId);
        }
        public async Task<Dictionary<Guid, string>> GetAllCalendars(Guid userId)
        {
            return await _eventRepository.GetAllCalendars(userId);
        }


        public async Task<List<Event>> GetAllEvents()
        {
            return await _eventRepository.GetAllEvents();
        }


        public async Task UpdateEvents(Event event1)
        {
            await _eventRepository.UpdateEvents(event1);
        }


        public async Task DeleteEvent(Guid IdEvent)
        {
            await _eventRepository.DeleteEvent(IdEvent);
        }
    }
}

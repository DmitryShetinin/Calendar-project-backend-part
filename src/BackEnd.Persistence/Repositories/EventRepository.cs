using AutoMapper;
using BackEnd.Core.Interfaces.Repositories;
using BackEnd.Models;
using BackEnd.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Persistence.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly UwrmdxbzContext _context;
        private readonly IMapper _mapper;


        public EventRepository(UwrmdxbzContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Guid> CreateCalendar(string name, Guid UserId)
        {
            Guid guid = Guid.NewGuid();
            var CalendarEntity = new CalendarEntity()
            {
                Calendarid = guid,
                Name = name,
                Userid = UserId
            };
            try
            {
                await _context.Calendars.AddAsync(CalendarEntity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return guid;
        }

        public async Task CreateEvent(Event data)
        {
            var EventEntity = new EventEntity()
            {
                Allday = data.Allday,
                Event1 = data.Event1,
                Calendarid = data.Calendarid,
                Userid = data.Userid,
                Discriotion = data.Discriotion,
                Name = data.Name,
                Participants = data.Participants,
                Startdate = data.Startdate,
                Enddate = data.Enddate,
                Reminder = data.Reminder,

            };

            try
            {
                await _context.Events.AddAsync(EventEntity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Task DeleteEvent(Guid IdGuid)
        {
            throw new NotImplementedException();
        }

        public async Task<Dictionary<Guid, string>> GetAllCalendars(Guid UserId)
        {
            return await _context.Calendars
             .Where(e => e.Userid == UserId)
             .Select(calendar => new { calendar.Calendarid, calendar.Name })
             .ToDictionaryAsync(calendar => calendar.Calendarid, calendar => calendar.Name);
        }

        public async Task<List<Event>> GetAllEvents()
        {
            return await _context.Events.Select(e => _mapper.Map<Event>(e)).ToListAsync();
        }

        public async Task UpdateEvents(Event updatedEvent)
        {
            var userEntity = await _context.Events.FirstOrDefaultAsync(e => e.Event1 == updatedEvent.Event1);
            if (userEntity == null)
            {
                throw new Exception("Error");
            }

            userEntity.Startdate = updatedEvent.Startdate;
            userEntity.Enddate = updatedEvent.Enddate;
            userEntity.Participants = updatedEvent.Participants;
            userEntity.Name = updatedEvent.Name;
            userEntity.Discriotion = updatedEvent.Discriotion;
            await _context.SaveChangesAsync();
        }
    }
}

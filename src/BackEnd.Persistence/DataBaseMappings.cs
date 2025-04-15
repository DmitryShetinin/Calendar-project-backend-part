using AutoMapper;
using BackEnd.Models;
using BackEnd.Persistence.Entities;


namespace BackEnd.Persistence;
public class DataBaseMappings : Profile
{
    public DataBaseMappings()
    {
        CreateMap<UserEntity, User>();
        CreateMap<CalendarEntity, Calendar>();
        CreateMap<EventEntity, Event>();
    }
}
namespace BackEnd.Persistence.Entities;

public partial class CalendarEntity
{
    public Guid Calendarid { get; set; }

    public string Name { get; set; } = null!;

    public Guid? Userid { get; set; }
}

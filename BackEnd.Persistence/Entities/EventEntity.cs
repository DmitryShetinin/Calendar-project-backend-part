 

namespace BackEnd.Persistence.Entities;

public partial class EventEntity
{
    public Guid? Userid { get; set; }

    public Guid? Event1 { get; set; }

    public Guid? Calendarid { get; set; }

    public string Name { get; set; } = null!;

    public string Discriotion { get; set; } = null!;

    public bool? Allday { get; set; }

    public string Startdate { get; set; } = null!;

    public string Enddate { get; set; } = null!;

    public List<string> Participants { get; set; } = null!;

    public string Reminder { get; set; } = null!;
}

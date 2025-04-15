namespace BackEnd.Models;

public partial class Calendar
{
    public Guid Calendarid { get; set; }

    public string Name { get; set; } = null!;

    public Guid? Userid { get; set; }
}

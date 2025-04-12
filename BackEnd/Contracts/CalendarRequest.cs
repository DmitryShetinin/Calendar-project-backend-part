using System.ComponentModel.DataAnnotations;

namespace BackEnd.Contracts;

public record CalendarRequest(
    [Required] string Name,
    [Required] Guid UserId);

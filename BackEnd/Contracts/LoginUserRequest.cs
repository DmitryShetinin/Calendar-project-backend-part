using System.ComponentModel.DataAnnotations;

namespace BackEnd.Interfaces.Auth;

public record LoginUserRequest(
    [Required] string Email,
    [Required] string Password);
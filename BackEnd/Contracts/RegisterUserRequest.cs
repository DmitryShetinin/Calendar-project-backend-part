using System.ComponentModel.DataAnnotations;

namespace BackEnd.Interfaces.Auth;

public record RegisterUserRequest(
    [Required] string UserName,
    [Required] string Password,
    [Required] string Email);
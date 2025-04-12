namespace BackEnd.Persistence.Entities;

public partial class UserEntity
{
    public string Username { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public Guid Id { get; set; }
}

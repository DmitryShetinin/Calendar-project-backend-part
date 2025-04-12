namespace BackEnd.API.Contracts;

public record ErrorResponse(
    int Status,
    string Message);
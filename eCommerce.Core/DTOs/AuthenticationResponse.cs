namespace eCommerce.Core.DTOs;

public record AuthenticationResponse(Guid UserId, 
    string? PersonName, 
    string? Email, 
    string? Gender, 
    string? Token, 
    bool Success);
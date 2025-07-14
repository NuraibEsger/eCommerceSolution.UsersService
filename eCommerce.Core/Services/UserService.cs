using eCommerce.Core.DTOs;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UserService(IUsersRepository usersRepository) : IUsersService
{
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
       ApplicationUser? user = await usersRepository.GetUserByEmailAndPassword(
           loginRequest.Email, loginRequest.Password);
       
       if (user is null)
           return null;
       
       return new AuthenticationResponse(
           user.UserId, 
           user.Email, 
           user.PersonName, 
           user.Gender, 
           "token",
           Success: true);
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        ApplicationUser user = new ApplicationUser()
        {
            Email = registerRequest.Email,
            PersonName = registerRequest.PersonName,
            Password = registerRequest.Password,
            Gender = registerRequest.Gender.ToString(),
        };
        ApplicationUser? registeredUser = await usersRepository.AddUser(user);
        
        if (registeredUser is null)
            return null;
        
        return new AuthenticationResponse(
            registeredUser.UserId, 
            registeredUser.Email,
            registeredUser.PersonName,
            registeredUser.Gender,
            "token",
            Success: true);
    }
}
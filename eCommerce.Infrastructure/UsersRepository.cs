using eCommerce.Core.DTOs;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;

namespace eCommerce.Infrastructure;

internal class UsersRepository : IUsersRepository
{
    public async Task<ApplicationUser> AddUser(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();
        
        return await Task.FromResult(user);
    }

    public async Task<ApplicationUser> GetUserByEmailAndPassword(string? email, string? password)
    {
        return new ApplicationUser()
        {
            Email = email,
            Password = password,
            UserId = Guid.NewGuid(),
            PersonName = "PersonName",
            Gender = nameof(GenderOption.Male)
        };
    }
}
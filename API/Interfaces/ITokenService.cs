using API.Entities;

namespace PetSitting.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
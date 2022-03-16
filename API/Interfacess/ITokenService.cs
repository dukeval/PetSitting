using PetSitting.Models;

namespace PetSitting.Interfaces
{
    public interface ITokenService
    {
        string createToken(UserCredential user);
    }
}
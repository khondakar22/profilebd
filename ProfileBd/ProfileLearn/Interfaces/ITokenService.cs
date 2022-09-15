using ProfileLearn.Entities;

namespace ProfileLearn.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}

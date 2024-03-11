namespace Travelblog.Core.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(string username);
    }
}

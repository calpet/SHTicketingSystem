using Shts.Dal.DTOs;

namespace Shts_BusinessLogic.Collection_Interfaces
{
    public interface IAccountManager
    {
        UserDto CreateAccount(User user);
        bool ValidateCredentials(string email, string password);
    }
}

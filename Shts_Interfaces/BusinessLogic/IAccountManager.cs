using Shts.Dal.DTOs;

namespace Shts_BusinessLogic.Collection_Interfaces
{
    public interface IAccountManager
    {
        bool CheckIfAccountExists(IUser user);
        bool ValidateAccount(string email, string password);
        IUser ConfigureAccount(IUser user);
    }
}

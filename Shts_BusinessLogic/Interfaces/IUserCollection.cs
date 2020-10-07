using Shts_BLLInterfaces;
using Shts_Entities.Enums;

namespace Shts_BusinessLogic
{
    public interface IUserCollection : IModelCollection<User>
    {
        User SearchUserByFilter(UserFilter filter);
    }
}

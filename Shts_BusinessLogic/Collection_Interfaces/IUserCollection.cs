using Shts_BLLInterfaces;
using Shts_Entities.Enums;

namespace Shts_BusinessLogic
{

   
    // Collection interfaces are put in the BusinessLogic so they can make use of the rich models & not cause circular dependencies in the Interface project :)
    public interface IUserCollection : IModelCollection<User>
    {
        User SearchUserByFilter(UserFilter filter);
    }
}

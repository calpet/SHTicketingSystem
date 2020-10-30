using System.Collections.Generic;
using Shts_Entities.Enums;

namespace Shts_BusinessLogic
{

   
    // Collection interfaces are put in the BusinessLogic so they can make use of the rich models & not cause circular dependencies in the Interface project :)
    public interface IUserCollection
    {
        void Add(User user);
        List<User> GetAll();
        User SearchUserByName(string name);
        User SearchUserByEmail(string email);
    }
}

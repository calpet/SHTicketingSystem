using System.Collections.Generic;
using Shts_BusinessLogic.Collection_Interfaces;
using Shts_Entities.Enums;

namespace Shts_BusinessLogic
{

   
    // Collection interfaces are put in the BusinessLogic so they can make use of the rich models & not cause circular dependencies in the Interface project :)
    public interface IUserCollection
    {
        void Add(IUser user);
        List<IUser> GetAll();
        IUser GetUserByName(string name);
        IUser GetUserByEmail(string email);
        IUser GetUserById(int id);
    }
}

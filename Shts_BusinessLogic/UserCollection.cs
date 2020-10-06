using System;
using System.Collections.Generic;
using Shts.Dal.DTOs;
using Shts_Factories;
using Shts_Interfaces.BLL;

namespace Shts_BusinessLogic
{
    public class UserCollection : IModelCollection<User>
    {
        private UserDto _dto;
        public void Add(User user)
        {
            if (user != null)
            {
                _dto = new UserDto() { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Password = user.Password};
                DalFactory.UserRepo.Create(_dto);
            }
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User SearchByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

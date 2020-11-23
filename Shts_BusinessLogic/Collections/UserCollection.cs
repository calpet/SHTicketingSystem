using System;
using System.Collections.Generic;
using Shts.Dal.DTOs;
using Shts_BusinessLogic.Collection_Interfaces;
using Shts_Factories;

namespace Shts_BusinessLogic
{
    public class UserCollection : IUserCollection
    {
        private UserDto _dto;
        private IUser _user;
        private List<IUser> _users;
        private IAccountManager _accountManager;

        public UserCollection(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        public void Add(IUser user)
        {
            if (user != null)
            {
                bool accountDoesntExist = _accountManager.CheckIfAccountExists(user);
                if (accountDoesntExist)
                {
                    _dto = DtoConverter.ConvertToUserDto(user);
                    DalFactory.UserRepo.Create(_dto);
                }
            }
        }

        public List<IUser> GetAll()
        {
            _users = new List<IUser>();
            var dtoList = DalFactory.UserRepo.GetAll();
                
            foreach (var dto in dtoList)
            {
                _users.Add(DtoConverter.ConvertToUserObject(dto));
            }

            return _users;
            }

        public IUser GetUserByName(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                _users = GetAll();

                for (int i = 0; i < _users.Count; i++)
                {
                    if (name == _users[i].FirstName || name == _users[i].LastName)
                    { 
                        _user = DtoConverter.ConvertToUserObject(_dto);
                    }
                }
            }

            return _user;
        }

        public IUser GetUserByEmail(string email)
        {
            if (!String.IsNullOrEmpty(email))
            {
                _users = GetAll();
                _user = _users.Find(x => x.Email == email);
                _user.FullName = _user.FirstName + " " + _user.LastName;
            }

            return _user;
        }

        public IUser GetUserById(int id)
        {
            if (id == 1 || id == 0)
            {
                _user = new User() { FullName = "Unassigned" };
            }
            else
            {
                _users = GetAll();
                _user = _users.Find(x => x.Id == id);
                _user.FullName = _user.FirstName + " " + _user.LastName;
            }
            

            return _user;
        }
    }
}

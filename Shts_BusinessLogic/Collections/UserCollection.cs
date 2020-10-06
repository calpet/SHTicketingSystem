using System;
using System.Collections.Generic;
using Shts.Dal.DTOs;
using Shts_Entities.Enums;
using Shts_Factories;
using Shts_Interfaces.BLL;

namespace Shts_BusinessLogic
{
    public class UserCollection : IModelCollection<User>
    {
        private UserDto _dto;
        private User _user;
        private User _requestingUser;

        public UserCollection(User user)
        {
            _requestingUser = user;
        }

        public List<User> Users { get; private set; }

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
            if (_requestingUser.Role >= UserRole.Agent)
            {
                Users = new List<User>();
                var dtoList = DalFactory.UserRepo.GetAll();
                foreach (var dto in dtoList)
                {
                    Users.Add( _user = new User()
                        {
                            Id = dto.Id, FirstName = dto.FirstName, LastName = dto.LastName, Email = dto.Email
                        });
                }
                return Users;
            }

            else
            {
                throw new InsufficientPermissionException("You have insufficient permission to perform this action.");
            }

            
        }

        public User SearchBy(FilterSettings setting)
        {
            if (setting == FilterSettings.Username)
            {
                _dto = DalFactory.UserRepo.GetUserByEmail(_requestingUser.Email);
                _user = new User() { Id = _dto.Id, FirstName = _dto.FirstName, LastName = _dto.LastName, Email = _dto.Email };


            }
            return _user;
        }
    }
}

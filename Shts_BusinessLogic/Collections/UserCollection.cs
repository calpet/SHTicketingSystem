using System;
using System.Collections.Generic;
using Shts.Dal.DTOs;
using Shts_Entities.Enums;
using Shts_Factories;
using Shts_Interfaces;

namespace Shts_BusinessLogic
{
    public class UserCollection : IUserCollection
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
                _dto = DtoConverter.ConvertToUserDto(user);
                DalFactory.UserRepo.Create(_dto);
            }
        }

        public List<User> GetAll()
        {
            if (_requestingUser.Role == UserRole.Admin)
            {
                Users = new List<User>();
                var dtoList = DalFactory.UserRepo.GetAll();
                foreach (var dto in dtoList)
                {
                    Users.Add(DtoConverter.ConvertToUserObject(dto));
                }
                return Users;
            }

            else
            {
                throw new InsufficientPermissionException("You have insufficient permission to perform this action.");
            }

            
        }

        public User SearchUserByFilter(UserFilter filter)
        {
            if (filter == UserFilter.Username)
            {
                _dto = DalFactory.UserRepo.GetUserByEmail(_requestingUser.Email);
                _user = DtoConverter.ConvertToUserObject(_dto);


            }
            return _user;
        }

    }
}

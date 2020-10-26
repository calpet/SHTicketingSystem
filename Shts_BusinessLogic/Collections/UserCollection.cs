﻿using System;
using System.Collections.Generic;
using Shts.Dal.DTOs;
using Shts_BusinessLogic.Collection_Interfaces;
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
        private List<User> _users;
        private IAccountManager _accountManager;


        //Constructor for when a User wants to use a functionality.
        public UserCollection(User user)
        {
            _requestingUser = user;
        }


        //Constructor for when a new account gets added.
        public UserCollection(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }


        public void Add(User user)
        {
            if (user != null)
            {
                _dto = _accountManager.CreateAccount(user);
                DalFactory.UserRepo.Create(_dto);
            }
        }

        public List<User> GetAll()
        {
            if (_requestingUser.Role == UserRole.Admin)
            {
                _users = new List<User>();
                var dtoList = DalFactory.UserRepo.GetAll();
                
                foreach (var dto in dtoList)
                {
                    _users.Add(DtoConverter.ConvertToUserObject(dto));
                }

                return _users;
            }

            else
            {
                throw new InsufficientPermissionException("You have insufficient permission to perform this action.");
            }

            
        }

        public User SearchUserByName(string name)
        {
            if (name != null)
            {
                _dto = DalFactory.UserRepo.GetUserByName(name);
                _user = DtoConverter.ConvertToUserObject(_dto);
            }
            else
            {
                throw new ArgumentNullException();
            }

            return _user;
        }

    }
}

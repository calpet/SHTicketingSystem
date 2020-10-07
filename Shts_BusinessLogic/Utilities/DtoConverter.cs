using System;
using System.Collections.Generic;
using System.Text;
using Shts.Dal.DTOs;

namespace Shts_BusinessLogic
{
    public static class DtoConverter
    {
        private static User _user;
        private static UserDto _dto;

        public static User ConvertToUserObject(UserDto dto)
        {
            _user = new User() { Id = dto.Id, FirstName = dto.FirstName, LastName = dto.LastName, Email = dto.Email };
            return _user;
        }

        public static UserDto ConvertToUserDto(User user)
        {
            _dto = new UserDto() { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Password = user.Password };
            return _dto;
        }


    }
}

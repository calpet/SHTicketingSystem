using System;
using System.Collections.Generic;
using System.Text;
using Shts.Dal.DTOs;
using Shts_BusinessLogic.Models;
using Shts_Entities.Enums;

namespace Shts_BusinessLogic
{
    public static class DtoConverter
    {
        private static User _user;
        private static UserDto _dto;

        public static User ConvertToUserObject(UserDto dto)
        {
            _user = new User() { Id = dto.Id, FirstName = dto.FirstName, LastName = dto.LastName, Gender = Enum.Parse<Gender>(dto.Gender), Role = Enum.Parse<UserRole>(dto.Role), Email = dto.Email, Password = dto.Password };
            return _user;
        }

        public static UserDto ConvertToUserDto(User user)
        {
            _dto = new UserDto() { FirstName = user.FirstName, LastName = user.LastName, Gender = user.Gender.ToString(), Role = user.Role.ToString(), Email = user.Email, Password = user.Password };
            return _dto;
        }


    }
}

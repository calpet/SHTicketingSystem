using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using Shts_BusinessLogic.Models;
using Shts_Entities.Enums;
using Shts_Factories;

namespace Shts_BusinessLogic
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Edit(User user)
        {
            DalFactory.UserRepo.Edit(DtoConverter.ConvertToUserDto(user));
        }

        public void Delete(int userId)
        {
            DalFactory.UserRepo.Delete(userId);
        }
    }
}

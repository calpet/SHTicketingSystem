using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SelfHelpTicketingSystem.Models;
using Shts_BusinessLogic;

namespace SelfHelpTicketingSystem.Classes
{
    public static class ViewModelConverter
    {
        private static User _user;
        private static UserViewModel _uvm;

        public static User ConvertViewModelToModel(UserViewModel uvm)
        {
            _user = new User() { Id = uvm.UserId, FirstName = uvm.FirstName, LastName = uvm.LastName, Gender = uvm.Gender, Email = uvm.Email, Password = uvm.Password };
            return _user;
        }

        public static UserViewModel ConvertModelToViewModel(User user)
        {
            _uvm = new UserViewModel() { UserId = user.Id, FirstName = user.FirstName, LastName = user.LastName, Gender = user.Gender, Email = user.Email, Password = user.Password };
            return _uvm;
        }
    }
}

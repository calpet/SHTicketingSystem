using System;
using System.Collections.Generic;
using Shts.Dal.DTOs;
using Shts_Interfaces;
using Shts_Interfaces.DAL;

namespace Shts.Dal
{
    public class UserRepository : IUserRepository
    {
        private IDatabaseConnection _dbCon;
        private object[] _params;
        private List<string> _result;

        public UserRepository(IDatabaseConnection dbCon)
        {
            _dbCon = dbCon;
        }

        public void Create(UserDto user)
        {
            _dbCon.ExecuteNonSearchQuery($"INSERT INTO `person`(`firstName`, `lastName`, `gender`, `role`, `email`, `password`) VALUES (@fname, @lname, @gender, @role, @email, @pwd)", _params = new object[] { user.FirstName, user.LastName, user.Gender, user.Role, user.Email, user.Password });
        }

        public void Edit(UserDto user)
        {
            _dbCon.ExecuteNonSearchQuery($"UPDATE `person` SET `firstName` = @fname, `lastName` = @lname, `email` = @email, `password` = @pwd WHERE `person`.`personID` = @id", _params = new object[] { user.FirstName, user.LastName, user.Email, user.Password, user.Id });
        }

        public void Delete(int id)
        {
            _dbCon.ExecuteNonSearchQuery($"DELETE FROM `person` WHERE `person`.`personID` = @uid", _params = new object[] { id });
        }

        public UserDto GetUserByEmail(string email)
        {
            
            _result = _dbCon.GetStringQuery($"SELECT `personID`, `firstName`, `lastName`, `gender`, `role`, `email`, `password`, `createdAt` FROM `person` WHERE `person`.`email` = @mail", _params = new object[] { email });
            if (_result.Count == 0)
                return null;
            
            UserDto user = new UserDto() {Id = Convert.ToInt32(_result[0]), FirstName = _result[1], LastName = _result[2], Gender = _result[3], Role = _result[4], Email = _result[5], Password = _result[6], CreatedAt = DateTime.Parse(_result[7])};
            return user;
        }

        public UserDto GetUserByName(string name)
        {
            _result = _dbCon.GetStringQuery($"SELECT `personID`, `firstName`, `lastName`, `gender`, `role`, `email`, `password`, `createdAt` FROM `person` WHERE `person`.`firstName` = @name", _params = new object[] { name });
            if (_result.Count == 0)
                return null;

            UserDto user = new UserDto() { Id = Convert.ToInt32(_result[0]), FirstName = _result[1], LastName = _result[2], Gender = _result[3], Role = _result[4], Email = _result[5], Password = _result[6], CreatedAt = DateTime.Parse(_result[7]) };
            return user;
        }

        public List<UserDto> GetAll()
        {
            List<UserDto> userList = new List<UserDto>();
            _result = _dbCon.GetStringQuery("SELECT * FROM `person`");
            for (int i = 0; i < _result.Count; i++)
            {
                // If the remainder of i / 8 equals 0, turn the strings into properties for the UserDto, then remove the strings from the list.
                if (_result.Count % 8 == 0)
                {
                    UserDto user = new UserDto()
                    {
                        Id = Convert.ToInt32(_result[0]), FirstName = _result[1], LastName = _result[2],
                        Gender = _result[3], Role = _result[4], Email = _result[5], Password = _result[6], CreatedAt = DateTime.Parse(_result[7])
                    };
                    userList.Add(user);
                    _result.RemoveRange(0, 8);
                }
                
            }

            return userList;
        }


    }
}

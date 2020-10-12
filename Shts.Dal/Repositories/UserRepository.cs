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
            _dbCon.ExecuteNonSearchQuery($"INSERT INTO `person`(`firstName`, `lastName`, `email`, `password`) VALUES (@fname, @lname, @email, @pwd)", _params = new object[] { user.FirstName, user.LastName, user.Email, user.Password });
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
            
            _result = _dbCon.GetStringQuery($"SELECT `personID`, `firstName`, `lastName`, `gender`, `email`, `password`, `createdAt` FROM `person` WHERE `person`.`email` = @mail", _params = new object[] { email });
            if (_result.Count == 0)
                return null;
            
            UserDto user = new UserDto() {Id = Convert.ToInt32(_result[0]), FirstName = _result[1], LastName = _result[2], Email = _result[4], Password = _result[5], CreatedAt = DateTime.Parse(_result[6])};
            return user;
        }

        public List<UserDto> GetAll()
        {
            List<UserDto> userList = new List<UserDto>();
            _result = _dbCon.GetStringQuery("SELECT * FROM `person`");
            for (int i = 0; i < _result.Count; i++)
            {
                // If the remainder of i / 6 equals 0, turn the strings into properties for the UserDto, then remove the strings from the list.
                if (i % 6 == 0)
                {
                    UserDto user = new UserDto()
                    {
                        Id = Convert.ToInt32(_result[0]), FirstName = _result[1], LastName = _result[2],
                        Email = _result[4], Password = _result[5], CreatedAt = DateTime.Parse(_result[6])
                    };
                    userList.Add(user);
                    _result.RemoveRange(0, 7);
                }
                
            }

            return userList;
        }


    }
}

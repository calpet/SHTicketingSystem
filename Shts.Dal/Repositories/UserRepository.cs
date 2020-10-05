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

        public void Add(UserDto user)
        {
            _dbCon.ExecuteNonSearchQuery($"INSERT INTO `person`(`firstName`, `lastName`, `email`, `password`) VALUES (@fname, @lname, @email, @pwd)", _params = new object[] { user.FirstName, user.LastName, user.Email, user.Password });
        }

        public void Edit(UserDto user)
        {
            _dbCon.ExecuteNonSearchQuery($"UPDATE `person` SET `firstName` = @fname, `lastName` = @lname, `email` = @email, `password` = @pwd WHERE `person`.`personID` = @id", _params = new object[] { user.FirstName, user.LastName, user.Email, user.Password, user.Id });
        }

        public void Delete(int userId)
        {
            _dbCon.ExecuteNonSearchQuery($"DELETE FROM `person` WHERE `person`.`personID` = @uid", _params = new object[] { userId });
        }

        public UserDto GetUserByEmail(string email)
        {
            
            _result = _dbCon.GetStringQuery($"SELECT `personID`, `firstName`, `lastName`, `gender`, `email`, `password`, `createdAt` FROM `person` WHERE `person`.`email` = @mail", _params = new object[] { email });
            UserDto user = new UserDto() {Id = Convert.ToInt32(_result[0]), FirstName = _result[1], LastName = _result[2], Email = _result[4], Password = _result[5], CreatedAt = DateTime.Parse(_result[6])};
            return user;
        }

        public List<UserDto> GetAll()
        {
            List<UserDto> userList = new List<UserDto>();
            _result = _dbCon.GetStringQuery("SELECT * FROM `person`");
            for (int i = 0; i < _result.Count; i++)
            {
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

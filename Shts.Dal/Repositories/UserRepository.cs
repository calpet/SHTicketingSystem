using System;
using System.Collections.Generic;
using Shts.Dal.DTOs;

namespace Shts.Dal
{
    public class UserRepository
    {
        private IDatabaseConnection _dbCon;
        private object[] _params;
        private List<string> _result;

        public UserRepository(IDatabaseConnection dbCon)
        {
            _dbCon = dbCon;
        }

        public void AddUser(UserDto user)
        {
            _dbCon.ExecuteNonSearchQuery($"INSERT INTO `person`(`firstName`, `lastName`, `email`, `password`) VALUES (@fname, @lname, @email, AES_ENCRYPT(@pwd, 'TICKET'))", _params = new object[] { user.Email, user.Password });
        }

        public void EditUser(UserDto user)
        {
            _dbCon.ExecuteNonSearchQuery($"UPDATE `person` SET `firstName` = @fname, `lastName` = @lname, `email` = @email, `password` = AES_ENCRYPT(@pwd, 'TICKET') WHERE `person`.`personID` = @id", _params = new object[] { user.FirstName, user.LastName, user.Email, user.Password, user.Id });
        }

        public void DeleteUser(int userId)
        {
            _dbCon.ExecuteNonSearchQuery($"DELETE FROM `person` WHERE `person`.`personID` = @uid", _params = new object[] { userId });
        }


        //@Todo: Fix this method pls:
        public UserDto GetUserById(int userId)
        {
            
            _result = _dbCon.GetStringQuery($"SELECT `firstName`, `lastName`, `gender`, `email`, `password`, `createdAt` FROM `person` WHERE `person`.`personID` = @uid", _params = new object[] { userId });
            UserDto user = new UserDto() {Id = Convert.ToInt32(_result[0]), Email = _result[5], Password = _result[6]};
            return user;
        }

        public List<UserDto> GetAllUsers()
        {
            return new List<UserDto>();
        }


    }
}

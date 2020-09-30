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
            _dbCon.ExecuteNonSearchQuery($"INSERT INTO `person`(`email`, `password`) VALUES (@email, @pwd)", _params = new object[] { user.Email, user.Password });
        }


        //@TODO: Implement these methods.
        public void EditUser(UserDto user)
        {
            _params = new object[] {user.FirstName, user.LastName, user.Email, user.Password, user.Email};
            //_dbCon.ExecuteNonSearchQuery($"UPDATE `person` SET (`person`.`firstName` = @fname, `person`.`lastName` = @lname, `person`.`email` = @email, `person`.`password` = @pwd WHERE `person`.`email` = @email)", _params);
        }

        public void DeleteUser(int userId)
        {
            _dbCon.ExecuteNonSearchQuery($"DELETE FROM `person` WHERE `person`.`personID` = @uid", _params = new object[] { userId });
        }


        //@Todo: Fix this method pls:
        public UserDto GetUserById(int userId)
        {
            _params = new object[] {userId};
            //_result = _dbCon.GetStringQuery($"SELECT `email`, `password` FROM `person` WHERE `person`.`personID` = @uid", _params);
            UserDto user = new UserDto() {Email = _result[0], Password = _result[1]};
            return user;
        }

        public List<UserDto> GetAllUsers()
        {
            return new List<UserDto>();
        }


    }
}

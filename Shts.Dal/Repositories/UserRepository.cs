using System.Collections.Generic;
using Shts.Dal.DTOs;

namespace Shts.Dal
{
    public class UserRepository
    {
        private IDatabaseConnection _dbCon;
        private object[] _params;

        public UserRepository(IDatabaseConnection dbCon)
        {
            _dbCon = dbCon;
        }

        public void AddUser(UserDto user)
        {
            _params = new object[]
            {
                user.Email,
                user.Password
            };

            _dbCon.ExecuteNonSearchQuery($"INSERT INTO `person`(`email`, `password`) VALUES '@email', '@pwd'", _params);
        }


        //@TODO: Implement these methods.
        public UserDto EditUser(UserDto user)
        {
            return user;
        }

        public void DeleteUser(int userId)
        {

        }

        public UserDto GetUserById(int userId)
        {
            return new UserDto();
        }

        public List<UserDto> GetAllUsers()
        {
            return new List<UserDto>();
        }


    }
}

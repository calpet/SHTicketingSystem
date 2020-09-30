using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHTS_DAL
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

            _dbCon.ExecuteNonSearchQuery("INSERT INTO `person`(`email`, `password`) VALUES '@email', '@pwd'", _params);
        }
    }
}

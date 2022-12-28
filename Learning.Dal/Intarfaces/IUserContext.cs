using Learning.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Dal.Intarfaces
{
    public interface IUserContext
    {
        void InsertUserToMongoDb(UserModel user);
        void DeleteUserFromMongoDb(UserModel user);
        void UpdateUserInMongoDb(UserModel user);
        void ReadUserFromMongoDb(UserModel user);
    }
}

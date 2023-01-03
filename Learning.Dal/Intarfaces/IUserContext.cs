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
        UserModel InsertUserToMongoDb(UserModel user);
        UserModel DeleteUserFromMongoDb(Guid userId);
        UserModel UpdateUserInMongoDb(Guid userID, UserModel user);
        UserModel ReadUserById(Guid userId);
        List<UserModel> GetAllList();
    }
}

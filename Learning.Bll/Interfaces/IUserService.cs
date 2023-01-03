using Learning.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Bll.Interfaces
{
    public interface IUserService
    {
        UserModel InsertUser(UserModel user);
        UserModel DeleteUser(Guid userId);
        UserModel UpdateUser(Guid userId, UserModel user);
        UserModel GetUserById(Guid userId);
        List<UserModel> GetAllUsers();
    }
}

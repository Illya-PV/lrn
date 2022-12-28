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
        UserModel DeleteUser(UserModel user);
        UserModel UpdateUser(UserModel user);
        UserModel ReadUser(UserModel user);
    }
}

using Learning.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Common.Models.InsertModels;

namespace Learning.Bll.Interfaces
{
    public interface IUserService
    {
        void InsertUser(UserInsertModel user);
        UserEntity DeleteUser(Guid userId);
        UserEntity UpdateUser(Guid userId, UserEntity user);
        UserEntity GetUserById(Guid userId);
        List<UserEntity> GetAllUsers();
    }
}

using Learning.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Common.Models.InsertModels;
using Learning.Common.Models.PatchModels;

namespace Learning.Dal.Intarfaces
{
    public interface IUserContext
    {
        void InsertUserToMongoDb(UserInsertModel user);
        UserEntity DeleteUserFromMongoDb(Guid userId);
        UserEntity UpdateUserInMongoDb(Guid userId, UserPatchModel user);
        UserEntity ReadUserById(Guid userId);
        List<UserEntity> GetAllList();
    }
}

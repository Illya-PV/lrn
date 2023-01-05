using Learning.Bll.Interfaces;
using Learning.Dal;
using Learning.Dal.Context;
using Learning.Dal.Intarfaces;
using Learning.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Common.Models.InsertModels;
using Learning.Common.Models.PatchModels;

namespace Learning.Bll.Implementation
{
    public class UserService:IUserService
    {
        private IUserContext _userContext;

        public UserService(IUserContext userContext) 
        { 
            _userContext = userContext;
        }
       
        /// <summary>
        /// insert validated user to mongoDB
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public void InsertUser(UserInsertModel user) 
        { 
            
            if (user.FirstName == " " | user.LastName == " ")
            {
                Console.WriteLine("user name can`t be empty\n");
                user.FirstName = "default";
                user.LastName = "default";
                if (user.Email.Contains('@') == false)
                {
                    Console.WriteLine("wrong email addres\n");
                }
                else if(user.Password.Length <= 8)
                { 
                    Console.WriteLine("password is to short");
                }
            }
            else if (user.Password.Length <= 8)
            {
                Console.WriteLine("password is to short");
                
            }
            else if (user.Email.Contains('@') == false)
            {
                Console.WriteLine("wrong email addres\n");
            }
            else
            {
                Console.WriteLine($"user:{user} added successfully\n");
                _userContext.InsertUserToMongoDb(user);                              
            } 
         
        }
        /// <summary>
        /// delete validated user from mongoDB
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserEntity DeleteUser(Guid userId) 
        {

            return _userContext.DeleteUserFromMongoDb(userId); 
        }
        /// <summary>
        /// update validated user in mongoDB
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserEntity UpdateUser(Guid userId,UserPatchModel user) 
        {
            return _userContext.UpdateUserInMongoDb(userId,user);
             
        }
        /// <summary>
        /// read user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserEntity GetUserById(Guid userId) 
        {
            return _userContext.ReadUserById(userId);
            
        }
        public List<UserEntity> GetAllUsers() 
        {
            return _userContext.GetAllList();
        }
    }
}

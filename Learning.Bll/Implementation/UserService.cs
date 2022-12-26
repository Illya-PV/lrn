﻿using Learning.Bll.Interfaces;
using Learning.Dal;
using Learning.Dal.Context;
using Learning.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Learning.Bll.Implementation
{
    public class UserService:IUserService
    {
        UserContext userContext;
       
        /// <summary>
        /// insert validated user to mongoDB
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserModel InsertUser(UserModel user) 
        { 
            user.UserId = Guid.NewGuid();
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
                userContext.InsertUserToMongoDb(user);                              
            } 
            return user;
        }
        /// <summary>
        /// delete validated user from mongoDB
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserModel DeleteUser(UserModel user) 
        {
            if (user.Email == "" || user.Email == " ")
            {
                Console.WriteLine("DB doesn`t has such model");
            }
            else { userContext.DeleteUserFromMongoDb(user); } 
            return user;
        }
        /// <summary>
        /// delete validated collection in mongoDB
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserModel DeleteCollection(UserModel user) 
        {
            userContext.DeleteCollection(user);
            return user;
        }
        /// <summary>
        /// update validated user in mongoDB
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserModel UpdateUser(UserModel user) 
        {
            userContext.UpdateUserInMongoDb(user);
            return user;
        }
        /// <summary>
        /// read user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserModel ReadUser(UserModel user) 
        {
            userContext.ReadUserFromMongoDb(user);
            return user;
        }
    }
}

﻿using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokoManager.Models;

namespace TokoManager.ViewModels
{
    class FirebaseHelper
    {
      
        public static FirebaseClient firebase = new FirebaseClient("https://tokomanager-test.firebaseio.com/");
   
        public static async Task<List<User>> GetUsers()
        {
            try
            {
                var users = (await firebase
                .Child("Users")
                .OnceAsync<User>())
                .Select(item =>
                new User
                {
                    Email = item.Object.Email,
                    Password = item.Object.Password
                }).ToList();
                return users;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Read     
        public static async Task<User> GetUser(string email)
        {
            try
            {
                var allUsers = await GetUsers();
                await firebase
                .Child("Users")
                .OnceAsync<User>();
                return allUsers
                    .Where(a => a.Email == email)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Inser a user    
        public static async Task<bool> AddUser(string email, string password)
        {
            try
            {


                await firebase
                .Child("Users")
                .PostAsync(new User() { Email = email, Password = password });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Update     
        public static async Task<bool> UpdateUser(string email, string password)
        {
            try
            {


                var toUpdateUser = (await firebase
                .Child("Users")
                .OnceAsync<User>())
                .Where(a => a.Object.Email == email)
                .FirstOrDefault();
                await firebase
                .Child("Users")
                .Child(toUpdateUser.Key)
                .PutAsync(new User() { Email = email, Password = password });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Delete User    
        public static async Task<bool> DeleteUser(string email)
        {
            try
            {


                var toDeletePerson = (await firebase
                .Child("Users")
                .OnceAsync<User>())
                .Where(a => a.Object.Email == email)
                .FirstOrDefault();
                await firebase
                    .Child("Users")
                    .Child(toDeletePerson.Key)
                    .DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }
    }
}

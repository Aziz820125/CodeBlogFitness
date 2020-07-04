using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller

{
    /// <summary>
    /// контроллер пользователя 
    /// </summary>
    public class UserController

    {
        /// <summary>
        /// пользователь приложения
        /// </summary>

        public List<User> Users { get; }

        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;
        /// <summary>
        /// создание нового контроллера пользователя
        /// </summary>
        /// <param name="user"></param>
        public UserController(string  userName)
          
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("имя пользователя не может быть пустым", nameof(userName));
            }
            Users = GetUsersDate();

            CurrentUser = Users.SingleOrDefault(user => user.Name == userName);
            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }
        /// <summary>
        /// получить сохраненный список пользователей
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersDate()

        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
                
            }
        }

        public void  SetNewUserData(string genderName, DateTime birthDate, double weight=0, double height=0)
        {
            // проверка
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.Birthdate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();

        }

        /// <summary>
        /// сохранить данные пользователя 
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))

            {
                formatter.Serialize(fs,Users);
            }
        }
        /// <summary>
        /// получить данные пользователя 
        /// </summary>
        /// <returns>пользователь приложения </returns>
        

    }
}
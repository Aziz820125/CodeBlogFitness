using CodeBlogFitness.BL.Model;
using System;
using System.IO;
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

        public User User { get; }
        /// <summary>
        /// создание нового контроллера пользователя
        /// </summary>
        /// <param name="user"></param>
        public UserController(string  userName, string genderName, DateTime birthDate, double Weight, double Height)
        {
            var gender = new Gender(genderName);
         User = new User(userName, gender, birthDate, Weight, Height);
           
        }
        public UserController()

        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {

                    User = user;
                }
                /// todo:что делать если пользователя не прочитали
            }
        }
        /// <summary>
        /// сохранить данные пользователя 
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))

            {
                formatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// получить данные пользователя 
        /// </summary>
        /// <returns>пользователь приложения </returns>
        

    }
}
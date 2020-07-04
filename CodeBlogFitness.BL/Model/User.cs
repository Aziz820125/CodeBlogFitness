using System;


namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// пользователь
    /// </summary>
    [Serializable]
   public class User

    {
        #region свойства
        /// <summary>
        /// имя 
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// пол
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// дата рождение
        /// </summary>

        public DateTime Birthdate { get; set; }
        /// <summary>
        /// вес
        /// </summary>

        public double Weight { get; set; }
        /// <summary>
        /// рост
        /// </summary>
        public double Height { get; set; }

        public int Age { get { return DateTime.Now.Year - Birthdate.Year; } }
        #endregion

        /// <summary>
        /// создать нового пользователя 
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="gender">пол</param>
        /// <param name="birthdate">дата рождения</param>
        /// <param name="weight">вес</param>
        /// <param name="height">рост</param>
        public User(string name,
            Gender gender, 
            DateTime birthdate,
            double weight, 
            double height )
        {
            #region проверка условий 
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(" имя не может быть пустым или null", nameof(name));
            }
            if (gender==null)
            {
                throw new ArgumentNullException("пол не может быть пустым или null", nameof(gender));
            }
            if( birthdate < DateTime.Parse("01.01.1900") || birthdate>= DateTime.Now)
            {
                throw new ArgumentNullException("невозможная дата рождения", nameof(birthdate));
            }    

            if (weight<=0)
            {
                throw new ArgumentNullException("вес не может быть меньше или равен нулю", nameof(weight));
            }
            if(height<=0)
            {
                throw new ArgumentNullException("рост не может быть меньше или равен нулю", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            Birthdate = birthdate;
            Weight = weight;
            Height = height;
        }
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(" имя не может быть пустым или null", nameof(name));
            }
            Name = name;

        }
        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}

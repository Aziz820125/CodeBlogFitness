using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// пол
    /// </summary>
    [Serializable]
   public class Gender
    {
        /// <summary>
        ///название
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// создать новый пол 
        /// </summary>
        /// <param name="name"> имя пола </param>
        public Gender (string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(" имя пола не может быть пустым или null", nameof(name));
            }
            Name = name;

        }
        public override string ToString()
        {
            return Name;
        }
    }
}

using System;

namespace BodkiaFitness.BL.Model
{
    /// <summary>
    /// Пол
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Названия
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Создать новий пол
        /// </summary>
        /// <param name="Name">Имя пола </param>
        public Gender(string Name)
        {
            if(string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустим или null",nameof(Name));
            }

            this.Name = Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

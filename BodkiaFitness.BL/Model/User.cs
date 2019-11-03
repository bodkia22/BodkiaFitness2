using System;


namespace BodkiaFitness.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get;}

        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime Birth { get; set; }

        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get { return DateTime.Now.Year - Birth.Year; } }
        //TODO: Правильное вичисления возраста.
        #endregion

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="gender">Гендер.</param>
        /// <param name="birth">Дата рождения.</param>
        /// <param name="weight">Вес.</param>
        /// <param name="height">Рост.</param>
        public User(string name, Gender gender, DateTime birth, double weight, double height)
        {
            #region Проверки условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователыя не может быть пустим или null.", nameof(name));
            }
            if(gender==null)
            {
                throw new ArgumentNullException("Гендер не может быть null.",nameof(gender));
            }
            if (birth < DateTime.Parse("01.01.1920")|| birth>DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения.", nameof(birth));
            }
            if (weight < 0)
            {
                throw new ArgumentException("Вес не может быть меньше нулю.", nameof(weight));
            }
            if(height<0)
            {
                throw new ArgumentException("Рост не может быть меньше нелю.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            Birth = birth;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователыя не может быть пустим или null.", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name+ " "+ Age;
        }
    }
}

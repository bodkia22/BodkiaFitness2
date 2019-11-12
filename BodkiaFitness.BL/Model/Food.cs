using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodkiaFitness.BL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }

        #region БЖУ

        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жири
        /// </summary>
        public double Fats { get;}

        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; }
        
        /// <summary>
        /// Калорий
        /// </summary>
        public double Callories { get; }

        #endregion   

        public Food(string name):this(name,0,0,0,0) {}

        public Food(string name, double calories,double proteins, double fats, double carbohydrates)
        {
            //TODO: Проверка значений 
            Callories = calories/100;
            Name = name;
            Proteins = proteins / 100;
            Fats = fats / 100;
            Carbohydrates = carbohydrates / 100;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

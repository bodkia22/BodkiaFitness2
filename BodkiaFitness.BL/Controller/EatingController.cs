using BodkiaFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BodkiaFitness.BL.Controller
{
    public class EatingController:BaseController
    {
        private const string FOOD_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";

        private readonly User user;

        public List<Food> Foods { get; }
        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Поользователь не может быть пустым или null.", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEatings();
        }

        public void Add(Food food,double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if(product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        private Eating GetEatings()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOOD_FILE_NAME) ?? new List<Food>();
        }

        private void Save()
        {
            Save(FOOD_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eating);
        }


    }
}

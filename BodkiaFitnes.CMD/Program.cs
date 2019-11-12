using BodkiaFitness.BL.Model;
using BodkiaFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodkiaFitnes.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожалувать в приложения BodkiaFitness.");

            Console.WriteLine("Введити имя пользователя.");
            var name = Console.ReadLine();

            var UserController = new UserController(name);
            var EatingController = new EatingController(UserController.CurrentUser);

            if (UserController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                DateTime birth = ParseDateTime();
                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");

                UserController.SetNewUserData(gender, birth, weight, height);
            }
            Console.WriteLine(UserController.CurrentUser);

            Console.WriteLine("Что вы хотите зделать ?");
            Console.WriteLine("E - ввести прием пищи");
            var key = Console.ReadKey();
            Console.WriteLine();

            if(key.Key==ConsoleKey.E)
            {
                var foods = EnterEating();
                EatingController.Add(foods.food, foods.Weight);

                foreach (var item in EatingController.Eating.Foods)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
            }
            Console.ReadLine();
        }

        
        private static (Food food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("калорийность");
            var protein = ParseDouble("белки");
            var fats = ParseDouble("жири");
            var carbs = ParseDouble("углеводы");

            var weight = ParseDouble("вес порции");
            var product = new Food(food,calories,protein,fats,carbs);

            return (product,weight);
        }
        private static DateTime ParseDateTime()
        {
            DateTime birth;
            while (true)
            {
                Console.Write("Введите дату рождения (dd.MM.yyyy) : ");
                if (DateTime.TryParse(Console.ReadLine(), out birth))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат написания даты.");
                }
            }

            return birth;
        }

        private static double ParseDouble(string name)
        {
            //TODO:Зделать ексепшин для <0
            while (true)
            {
                Console.WriteLine($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}a");
                }
            }
        }
    }
}

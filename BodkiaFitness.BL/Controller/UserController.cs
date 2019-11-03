﻿using BodkiaFitness.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;

namespace BodkiaFitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public List<User> Users { get; }

        /// <summary>
        /// Пользователь онлайн
        /// </summary>
        public User CurrentUser { get; set; }

        /// <summary>
        /// Флаг. Являеться пользователь новым или из приложения.
        /// </summary>
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создания нового контроллера пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пусти или null.",nameof(userName));
            }
            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName); //шукає якщо не існує то null
            if(CurrentUser==null) //якщо немає такого то создаэм
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Получить сохраненний список пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length>0 && formatter.Deserialize(fs) is List<User> user)//без lenght на тесте была ошибка
                {
                    return user;
                }
                else
                {
                    return new List<User>();
                }
            }
        }

        public void SetNewUserData(string gender,DateTime birth,double weight=1,double height=1)
        {
            //проверка
            CurrentUser.Gender = new Gender(gender);
            CurrentUser.Birth = birth;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;

            Save();
        }
        /// <summary>
        /// Сохранить данние пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs=new FileStream("user.dat",FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }
    }
}

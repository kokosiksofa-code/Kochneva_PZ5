using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordSecurity;
using Naptki.Models; 

namespace Naptki
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создание новой учетной записи для пользователя\n");

            Console.Write("Введите логин пользователя: ");
            string login = Console.ReadLine();

            Console.Write("Введите пароль пользователя: ");
            string password = Console.ReadLine();

            string hashedPassword = HashGenerator.GetHash(password);
            Console.WriteLine($"Хешированный пароль пользователя: {hashedPassword}");

            try
            {
                var db = Helper.GetContext();

                if (db.AuthorizationUsers.Any(u => u.Login == login))
                {
                    Console.WriteLine("Ошибка: Пользователь с таким логином уже существует!");
                    Console.ReadKey();
                    return;
                }
                AuthorizationUsers newUser = new AuthorizationUsers
                {
                    Login = login,
                    PasswordHash = hashedPassword,
                    IsActive = true,         
                    CreatedAt = DateTime.Now
                };

                db.AuthorizationUsers.Add(newUser);
                db.SaveChanges();

                Console.WriteLine("Учетная запись добавлена");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при работе с БД: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}

using Sat.Recruiment.IData;
using Sat.Recruiment.Model;
using Sat.Recruiment.Model.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Sat.Recruiment.Data
{
    public class Context : IContext
    {       
        public List<User> getUsers()
        {
            List<User> _users = new List<User>();

            var reader = ReadUsersFromFile();            

            while (reader.Peek() >= 0)
            {
                var lines = reader.ReadLineAsync().Result.Split(',');

                User user = new User
                {
                    Name = lines[0].ToString(),
                    Email = lines[1].ToString(),
                    Phone = lines[2].ToString(),
                    Address = lines[3].ToString(),
                    UserType = (UserType)Enum.Parse(typeof(UserType), lines[4].ToString()),
                    Money = decimal.Parse(lines[5].ToString())
                };
                _users.Add(user);
            }
            reader.Close();
            return _users;
        }

        private StreamReader ReadUsersFromFile()
        {
            var path = $"{Directory.GetCurrentDirectory()}/Files/Users.txt";

            StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open));
            return reader;
        }
    }
}

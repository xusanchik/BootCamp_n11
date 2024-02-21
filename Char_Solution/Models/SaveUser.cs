using Char_Solution.Db_Context;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Char_Solution.Models
{
    public class SaveUser
    {

        public void Save()
        {
            var user = new User();

            Console.WriteLine("Create Username");
            string Name = Console.ReadLine();
            Console.WriteLine("Create Password");
            string Password = Console.ReadLine();
            user.Name = Name;
            user.Password = Password;
            List<User> users = Data.GetReader();

            var find = users.Where(user => user.Name == Name).ToList();

            if( find.Count != 0)
            {
                Console.WriteLine("qalesa");

                Data.GetAll();
            }
            else
            {
                string connectionString = "User ID=postgres;Password=husan9090;Host=localhost;Port=5432;Database=univercity;IncludeErrorDetail = true;";

                using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();

                string query = $"INSERT INTO Users (name , password) values('{Name}','{Password}')";

                using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
                var rowCount = cmd.ExecuteNonQuery();

                Data.GetAll();


            }


        }




    }
}

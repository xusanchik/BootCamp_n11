using Char_Solution.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Char_Solution.Db_Context
{
    public class Data
    {
        public static void GetAll()
        {
            string connectionString = "User ID=postgres;Password=husan9090;Host=localhost;Port=5432;Database=univercity;IncludeErrorDetail = true;";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "select * from Users;";
                using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

                var result = cmd.ExecuteReader();

                while (result.Read())
                {
                    Console.WriteLine($" {result[0]} {result[1]} {result[2]}");
                }
            }
        }
        public static List<User>  GetReader()
        {
            string connectionString = "User ID=postgres;Password=husan9090;Host=localhost;Port=5432;Database=univercity;IncludeErrorDetail = true;";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "select * from Users;";
                using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

                var result = cmd.ExecuteReader();
                var newuser = new User();
                var userlist = new List<User>();
                while (result.Read())
                {
                    newuser.Id = result[0].GetHashCode();
                    newuser.Name = result[1].ToString();
                    newuser.Password = result[2].ToString();
                    userlist.Add(newuser);

                }
                return userlist;
            }
        }
    }
}

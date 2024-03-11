using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solutions
{
    public class Solution
    {
        public static void GetAll()
        {
            string connectionString = "User ID=postgres;Password=husan9090;Host=localhost;Port=5432;Database=ApiHome;IncludeErrorDetail = true;";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "select * from inventory ORDER BY id;;";
                using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

                var result = cmd.ExecuteReader();

                while (result.Read())
                {

                    Console.WriteLine($" {result[0]} {result[1]} {result[2]}");
                }
            }
        }

        public static void Create_table(string name)
        {
            string connectionString = "User ID=postgres;Password=husan9090;Host=localhost;Port=5432;Database=ApiHome;IncludeErrorDetail = true;";


            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();

            string query = $"insert into Testtable1(Name) values('{name}');insert into Testtable1(Name) values('{name}');";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var countRow = cmd.ExecuteNonQuery();

            Console.WriteLine(countRow + " qator qo'shildi");
        }
        public static void InserInto(string name, int quantity)
        {
            //GetAll();

            string connectionString = "User ID=postgres;Password=husan9090;Host=localhost;Port=5432;Database=ApiHome;IncludeErrorDetail = true;";


            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();

            string query = $"INSERT INTO inventory (name ,quantity) values('{name}','{quantity}')";

            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            var rowCount = cmd.ExecuteNonQuery();

            GetAll();
        }
        public static void GetById(int id)
        {

            string connectionString = "User ID=postgres;Password=husan9090;Host=localhost;Port=5432;Database=ApiHome;IncludeErrorDetail = true;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = $"select * from inventory where Id = '{id}';";
                using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

                var result = cmd.ExecuteReader();

                while (result.Read())
                {
                    Console.WriteLine($" {result[0]} {result[1]} {result[2]}");
                }
            }
        }
        public static void Delete()
        {
            string connectionString = "User ID=postgres;Password=husan9090;Host=localhost;Port=5432;Database=ApiHome;IncludeErrorDetail = true;";

            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            GetAll();
            Console.WriteLine("Qaysi id Ochirmoxchisz");
            var id = Console.ReadLine();

            string query = $"delete from inventory where Id='{id}'";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var rowCount = cmd.ExecuteNonQuery();

            GetAll();
            Console.WriteLine(rowCount + "Shuncha row muvaffaqiyatli o'chirildi");
        }
        public static void Update()
        {
            GetAll();

            Console.WriteLine("Qaysi id ozgarrtirmoqchisz");
            string id = Console.ReadLine();

            Console.WriteLine("Qaysi columinini");
            string column = Console.ReadLine();

            Console.WriteLine("Ozgarishni kiriti");
            string newvalue = Console.ReadLine();

            string connectionString = "User ID=postgres;Password=husan9090;Host=localhost;Port=5432;Database=ApiHome;IncludeErrorDetail = true;";


            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();

            string query = $"UPDATE inventory SET {column} = '{newvalue}' WHERE id = '{id}'";

            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var rowCount = cmd.ExecuteNonQuery();
            GetAll();
        }
        public static void UpdateID()
        {
            GetAll();

            Console.WriteLine("Qaysi id ozgarrtirmoqchisz");
            string id = Console.ReadLine();

            Console.WriteLine("Qaysi columinini");
            string column = Console.ReadLine();

            Console.WriteLine("Ozgarishni kiriti");
            string newvalue = Console.ReadLine();

            string connectionString = "User ID=postgres;Password=husan9090;Host=localhost;Port=5432;Database=ApiHome;IncludeErrorDetail = true;";


            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();

            string query = $"UPDATE inventory SET {column} = '{newvalue}' WHERE id = '{id}'";

            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var rowCount = cmd.ExecuteNonQuery();
            GetAll();
        }

        public static void UpdateTableName()
        {
            string connectionString = "Host=localhost;Port=5432;Database=Lesson;User Id=postgres;Password=A321a321;";

            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();

            Console.WriteLine("Enter rename table name");
            var oldTableName = Console.ReadLine();
            Console.WriteLine("Enter new table name ");
            var newTableName = Console.ReadLine();

            var query = $"ALTER TABLE {oldTableName} RENAME TO {newTableName};";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Created success");
        }
        public static void CheckDatabase()
        {
            bool dbExists;
            var createDatabase = @"Host=localhost;Port=5432;User Id=postgres;Password=A321a321;";

            using var mCreatedb = new NpgsqlConnection(createDatabase);
            Console.WriteLine("Enter database name");
            var nameDb = Console.ReadLine();
            string connectionString = $"Host=localhost;Port=5432;Database={nameDb};User Id=postgres;Password=A321a321;";
            var m_createTb = new NpgsqlConnection(connectionString);
            var cmdText =
                $"CREATE DATABASE \"{nameDb}\" WITH OWNER = postgres ENCODING = 'UTF8' LOCALE_PROVIDER = 'libc' CONNECTION LIMIT = -1 IS_TEMPLATE = False;";
            mCreatedb.Open();
            var cmd = new NpgsqlCommand(cmdText, mCreatedb);
            cmd.ExecuteNonQuery();
            mCreatedb.Close();
            cmd.CommandText = "create table test1(id serial primary key ,fullname varchar(255)); " +
                              "create table test2(id serial primary key ,fullname varchar(255));" +
                              "create table test3(id serial primary key ,fullname varchar(255));";

            cmd.Connection = m_createTb;

            m_createTb.Open();
            cmd.ExecuteNonQuery();
            m_createTb.Close();
        }
        public static void TruncateTable()
        {
            string connectionString = "Host=localhost;Port=5432;Database=Lesson;User Id=postgres;Password=A321a321;";

            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();

            Console.WriteLine("Enter truncate table name");
            var truncateTableName = Console.ReadLine();


            var query = $"TRUNCATE TABLE {truncateTableName}";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            cmd.ExecuteNonQuery();
            Console.WriteLine("success");
        }
        public static void JoinTwoTables(object result)
        {
            string connectionString = "Host=localhost;Port=5432;Database=Lesson;User Id=postgres;Password=A321a321;";

            var queryCreateReference = "Create Table if not exists students(student_id serial primary key, name varchar(55)); " +
                                       "Create table if not exists university(id serial primary key, name varchar(55),student_id int references students(student_id))";

            // var mockData =
            //     "INSERT INTO students (name) VALUES ('John Doe'),('Jane Smith'),('Michael Johnson'),('Emily Brown'),('William Taylor'),('Sophia Martinez'),('Matthew Anderson'),    ('Olivia Wilson'),    ('James Moore'),    ('Emma Garcia'),    ('Daniel Jackson'),    ('Ava White'),    ('Alexander Lee'),    ('Mia Harris'),    ('David Martin'),    ('Isabella Thompson'),    ('Joseph Clark'),    ('Charlotte Rodriguez'),    ('Samuel Lewis'),    ('Madison Hall');" +
            //     "INSERT INTO university (name, student_id) VALUES    ('Harvard University', 1),    ('Stanford University', 2),    ('Massachusetts Institute of Technology', 3),    ('University of Oxford', 4),    ('California Institute of Technology', 5),    ('University of Cambridge', 6),    ('University of California, Berkeley', 7),    ('Princeton University', 8),    ('Yale University', 9),    ('University of Chicago', 10),    ('Columbia University', 11),    ('University of Michigan', 12),    ('Cornell University', 13),    ('University of Pennsylvania', 14),    ('Johns Hopkins University', 15),    ('Northwestern University', 16),    ('University of California, Los Angeles', 17),    ('Duke University', 18),    ('University of Toronto', 19),    ('University of Washington', 20);";


            using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();

            using NpgsqlCommand cmdCreateTable = new NpgsqlCommand(queryCreateReference, connection);
            cmdCreateTable.ExecuteNonQuery();

            // using NpgsqlCommand c
            {
                //Console.WriteLine("{0,-3} {1,-50} {2}", result[0], result[1], result[2]);
            }
        }
    }



}

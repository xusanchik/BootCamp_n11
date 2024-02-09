using Ado_net.Models;
using Npgsql;
using System.Net;

public class Program
{
    private static void Main(string[] args)
    {
        string connectionString = "User ID=postgres;Password=husan9090;Host=localhost;Port=5432;Database=ApiHome;IncludeErrorDetail = true;";

        NpgsqlConnection db_context = new NpgsqlConnection(connectionString);
        db_context.Open();

        string query = "create table skypedars(id serial , mavzu varchar(40), start_date date,student_count int)";

        var table = new SkypeDars();
        table.Mavzu = "Ado.net";
        table.start_date = DateTime.Now;
        table.student_count = 25;

        string insertQuery = @$"insert into skypedars(mavzu, start_date, students_count) 
//                                   values('{table.Mavzu}', '{table.start_date}', {table.student_count})";

        IList<SkypeDars> datalar = new List<SkypeDars>()
                    {
                        new SkypeDars() { Mavzu = "MongoDB", start_date = DateTime.Now, student_count = 45 },
                        new SkypeDars() { Mavzu = "PostgreSQL", start_date = DateTime.Now, student_count = 20 },
                        new SkypeDars() { Mavzu = "Provayderlar bilan ishlash", start_date = DateTime.Now, student_count = 90 },
                    };



        string insertQueryS = @$"insert into skypedars(mavzu, start_date, students_count) 
                                           values('{table.Mavzu}', '{table.start_date}', {table.student_count})";


        string baseQuery = "insert into skypedars(mavzu, start_date, student_count) values ";

        for (int i = 0; i < datalar.Count; i++)
        {
            baseQuery += @$"('{datalar[i].Mavzu}', '{datalar[i].start_date}', {datalar[i].student_count}),";

            Console.WriteLine(baseQuery);
        }

        string modifiedString = baseQuery.Substring(0, baseQuery.Length - 1);
        NpgsqlCommand command = new NpgsqlCommand(baseQuery.Substring(0, baseQuery.Length - 1), db_context);

        command.ExecuteNonQuery();

        // logic
        Console.WriteLine("Databasega Muvaffaqiyatli table yaratildi");

        db_context.Close();
    }

}
using Npgsql;
class Program
{
    static void Main()
    {
        GetAll();
        Delete(Console.ReadLine());
        Update();
        //Create();

    }
    public static void GetAll()
    {
        string connectionString = "User ID=postgres;Password=husan9090;Host=localhost;Port=5432;Database=ApiHome;IncludeErrorDetail = true;";

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            string query = "select * from inventory;";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var result = cmd.ExecuteReader();

            while (result.Read())
            {

                Console.WriteLine($" {result[0]} {result[1]} {result[2]}");
            }
        }
    }

    public static void GetByName(string name)
    {
      
        string connectionString = "User ID=postgres;Password=husan9090;Host=localhost;Port=5432;Database=ApiHome;IncludeErrorDetail = true;";
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            string query = $"select * from inventory where Name = '{name}';";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var result = cmd.ExecuteReader();

            while (result.Read())
            {
                Console.WriteLine(result[1]);
            }
        }
    }

    public static void Create(string name)
    {
        string connectionString = "User ID=postgres;Password=husan9090;Host=localhost;Port=5432;Database=ApiHome;IncludeErrorDetail = true;";


        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        string query = $"insert into Testtable1(Name) values('{name}');insert into Testtable1(Name) values('{name}');";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

        var countRow = cmd.ExecuteNonQuery();

        Console.WriteLine(countRow + " qator qo'shildi");
    }

    public static void Crate(string name)
    {
        string connectionString = "User ID=postgres;Password=husan9090;Host=localhost;Port=5432;Database=ApiHome;IncludeErrorDetail = true;";


        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        string query = $"insert into Testtable1(Name) values('{name}');insert into Testtable1(Name) values('{name}');";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

        var countRow = cmd.ExecuteNonQuery();

        Console.WriteLine(countRow + " qator qo'shildi");
    }
    public static void Delete(string name)
    {
        string connectionString = "User ID=postgres;Password=husan9090;Host=localhost;Port=5432;Database=ApiHome;IncludeErrorDetail = true;";


        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        string query = $"delete from inventory where Name='{name}'";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

        var rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine(rowCount + "Shuncha row muvaffaqiyatli o'chirildi");
    }
    public static void Update()
    {
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
        Console.WriteLine( "Shuncha row muvaffaqiyatli o'chirildi");

        GetAll();
    }
}

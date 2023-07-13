using Npgsql;

namespace program.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Port=5433;User Id=postgres;Password=ing0077K);Database=dvdRental;";

            var cmd = new NpgsqlCommand();

            Console.WriteLine("Write Any Command");

            string commandText = Console.ReadLine();

            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                cmd.Connection = con;

                var result = GetBySubject(cmd, commandText);

                foreach (var i in result)
                {
                    Console.WriteLine(i);
                }
            }

            IEnumerable<object> GetBySubject(NpgsqlCommand cmd, string commandText)
            {
                cmd.CommandText = /*"SELECT * FROM actor INNER JOIN film_actor USING(actor_id);";*/ commandText;

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    var result = new List<object>();

                    while (reader.Read())
                    {
                        result.Add($"{reader[0]} {reader[1]} {reader[2]} {reader[3]}");
                    }

                    return result;
                }
            }
        }
    }
}
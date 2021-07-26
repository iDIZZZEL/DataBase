using System;
using Npgsql;

namespace Project_1
{
    class Program
    {
        private static string Host = "168.119.252.246";
        private static string User = "intern";
        private static string DBname = "wazzup_db";
        private static string Password = "intern321";
        private static string Port = "5432";
        static void Main(string[] args)
        {
            string connString =
            String.Format(
                "Server={0}; User Id={1}; Database={2}; Port={3}; Password={4};SSLMode=Prefer",
                Host,
                User,
                DBname,
                Port,
                Password);
                string sql_1 = "SELECT * FROM leads_amo_csv";

            using (var conn = new NpgsqlConnection(connString))
            {

                Console.Out.WriteLine("Opening connection");
                conn.Open();


                using (var command = new NpgsqlCommand(sql_1, conn))
                {

                    var reader = command.ExecuteReader();
                    /*while (reader.Read())
                    {
                        Console.WriteLine(
                            string.Format(
                                "Reading from table=({0}, {1}, {2})",
                                reader.GetInt32(0).ToString(),
                                reader.GetString(1),
                                reader.GetInt32(2).ToString()
                                )
                            );
                    }*/
                    reader.Close();
                }
            }


        }
    }
}

// See https://aka.ms/new-console-template for more information
using System.Data.SQLite;

Console.WriteLine("Hello, sqlite!!!");

using (var conn=new SQLiteConnection("Data Source=mydb.db;Version=3;New=True;Compress=True;"))
{
    conn.Open();
    ReadData(conn);
}
static void ReadData(SQLiteConnection conn)
{
    

    SQLiteCommand command = new SQLiteCommand("SELECT * FROM SampleTable", conn);

    try
    {
        using (SQLiteDataReader reader = command.ExecuteReader())
        {
            if (reader.HasRows) // если есть данные
            {
                while (reader.Read())   // построчно считываем данные
                {
                    var id = reader.GetValue(0);
                    var name = reader.GetValue(1);


                    Console.WriteLine($"{id} \t {name} ");
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }


    
    conn.Close();
}

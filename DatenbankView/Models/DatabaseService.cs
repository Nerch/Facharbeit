using MySql.Data.MySqlClient;
using System.Collections.Generic;

public class DatabaseService
{
    private string connectionString = "Server=localhost;Database=Lagerverwaltung;User=root;Password=;";

    public bool TestConnection()
    {
        try
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                return true;
            }
        }
        catch
        {
            return false;
        }
    }

    public List<Palette> GetPaletten()
    {
        var paletten = new List<Palette>();
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var command = new MySqlCommand("SELECT * FROM Paletten", connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    paletten.Add(new Palette
                    {
                        ID = reader.GetInt32("ID"),
                        Gewicht = reader.GetFloat("Gewicht"),
                        Beschreibung = reader.GetString("Beschreibung")
                    });
                }
            }
        }
        return paletten;
    }

    public List<PKW> GetPKWs()
    {
        var pkws = new List<PKW>();
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var command = new MySqlCommand("SELECT * FROM PKWs", connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    pkws.Add(new PKW
                    {
                        ID = reader.GetInt32("ID"),
                        Modell = reader.GetString("Modell"),
                        Kennzeichen = reader.GetString("Kennzeichen"),
                        Baujahr = reader.GetInt32("Baujahr"),
                        MaxGewicht = reader.GetFloat("MaxGewicht"),
                        MaxPaletten = reader.GetInt32("MaxPaletten")
                    });
                }
            }
        }
        return pkws;
    }

    // Weitere Methoden für andere Tabellen können hier hinzugefügt werden
}

public class Palette
{
    public int ID { get; set; }
    public float Gewicht { get; set; }
    public string Beschreibung { get; set; }
}

public class PKW
{
    public int ID { get; set; }
    public string Modell { get; set; }
    public string Kennzeichen { get; set; }
    public int Baujahr { get; set; }
    public float MaxGewicht { get; set; }
    public int MaxPaletten { get; set; }
}
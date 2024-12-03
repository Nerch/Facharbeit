using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace PKW_beladen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const float MaxLKWGewicht = 7500f; // Maximales Gewicht pro LKW
            const int MaxPalettenProLKW = 17; // Maximale Anzahl an Paletten pro LKW

            string connectionString = "Server=localhost;Database=Lagerverwaltung;User=root;Password=;";

            List<Palette> paletten = new List<Palette>();
            List<PKW> pkws = new List<PKW>();
            List<int> verfuegbarePKWs = new List<int>();
            List<int> verfuegbareFahrer = new List<int>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Laden der Paletten
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

                // Laden der PKWs
                command = new MySqlCommand("SELECT * FROM PKWs", connection);
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

                // Laden der verfügbaren PKWs
                command = new MySqlCommand("SELECT PKW_ID FROM PKW_Verfuegbarkeit WHERE Verfuegbar = 1", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        verfuegbarePKWs.Add(reader.GetInt32("PKW_ID"));
                    }
                }

                // Laden der verfügbaren Fahrer
                command = new MySqlCommand("SELECT Mitarbeiter_ID FROM Mitarbeiter_Verfuegbarkeit WHERE Verfuegbar = 1", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        verfuegbareFahrer.Add(reader.GetInt32("Mitarbeiter_ID"));
                    }
                }
            }

            // Arrays zur Verfolgung des aktuellen Gewichts und der Anzahl der Paletten auf jedem PKW
            float[] PKW_Gewichte = new float[verfuegbarePKWs.Count];
            int[] PKW_Paletten = new int[verfuegbarePKWs.Count];

            // Hauptlogik zur Verteilung der Paletten auf die PKWs
            foreach (var palette in paletten)
            {
                bool paletteZugeteilt = false;

                for (int j = 0; j < verfuegbarePKWs.Count; j++)
                {
                    // Überprüfen, ob der aktuelle PKW die Palette aufnehmen kann
                    if (PKW_Gewichte[j] + palette.Gewicht <= MaxLKWGewicht && PKW_Paletten[j] < MaxPalettenProLKW)
                    {
                        palette.LKW = verfuegbarePKWs[j]; // Palette dem PKW zuweisen
                        PKW_Gewichte[j] += palette.Gewicht; // Gewicht der Palette zum PKW-Gewicht hinzufügen
                        PKW_Paletten[j]++; // Anzahl der Paletten auf dem PKW erhöhen
                        paletteZugeteilt = true;
                        break;
                    }
                }

                // Wenn keine PKWs mehr verfügbar sind, eine Meldung ausgeben
                if (!paletteZugeteilt)
                {
                    Console.WriteLine("Nicht genug PKWs für alle Paletten.");
                    break;
                }
            }

            // Ausgabe der Ergebnisse
            foreach (var palette in paletten)
            {
                Console.WriteLine($"Palette: Gewicht = {palette.Gewicht}, PKW = {palette.LKW}, ID = {palette.ID}");
            }

            Console.ReadKey();
        }
    }

    public class Palette
    {
        public int ID { get; set; }
        public float Gewicht { get; set; }
        public string Beschreibung { get; set; }
        public int LKW { get; set; }
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
}
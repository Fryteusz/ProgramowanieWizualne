using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
using System.Linq;

namespace Lab9;

public partial class MainWindow : Window
{
    private const string ConnectionString = "Data Source=BAZA.db";
    public MainWindow()
    {
        InitializeComponent();
        InitDatabase();
    }
    public class FormEntry
    {
        public int Id { get; set; }
        public string Data { get; set; } = "";
        public string Album { get; set; } = "";
        public string NazwiskoImie { get; set; } = "";
        public string SemestrRok { get; set; } = "";
        public string KierunekStopien { get; set; } = "";
        public string Przedmiot { get; set; } = "";
        public string ECTS { get; set; } = "";
        public string Prowadzacy { get; set; } = "";
        public string Uzasadnienie { get; set; } = "";
        public string Podpis { get; set; } = "";
        public string Kom1 { get; set; } = "";
        public string Kom2 { get; set; } = "";
        public string Kom3 { get; set; } = "";
        public string DataDec { get; set; } = "";
        public string Pieczatka { get; set; } = "";

        public override string ToString()
        {
            return $"#{Id}: {NazwiskoImie}, {Album}, {Przedmiot},{Data}  ";
        }
    }

    private void InitDatabase()
    {
        using var conn = new SqliteConnection(ConnectionString);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = @"
            CREATE TABLE IF NOT EXISTS Wnioski (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Data TEXT,
                Album TEXT,
                NazwiskoImie TEXT,
                SemestrRok TEXT,
                KierunekStopien TEXT,
                Przedmiot TEXT,
                ECTS TEXT,
                Prowadzacy TEXT,
                Uzasadnienie TEXT,
                Podpis TEXT,
                Kom1 TEXT,
                Kom2 TEXT,
                Kom3 TEXT,
                DataDec TEXT,
                Pieczatka TEXT

            )";
        cmd.ExecuteNonQuery();


    }
    private void Save(object? sender, RoutedEventArgs e)
    {
        using var conn = new SqliteConnection(ConnectionString);
        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText = @"
            INSERT INTO Wnioski (
                Data, Album, NazwiskoImie, SemestrRok, KierunekStopien,
                Przedmiot, ECTS, Prowadzacy, Uzasadnienie, Podpis,
                Kom1, Kom2, Kom3, DataDec, Pieczatka
            ) VALUES (
                $Data, $Album, $NazwiskoImie, $SemestrRok, $KierunekStopien,
                $Przedmiot, $ECTS, $Prowadzacy,
                $Uzasadnienie,
                $Podpis,
                $Kom1, $Kom2, $Kom3, $DataDec, $Pieczatka
            )";

        cmd.Parameters.AddWithValue("$Data", Data.Text ?? "");
        cmd.Parameters.AddWithValue("$Album", Album.Text ?? "");
        cmd.Parameters.AddWithValue("$NazwiskoImie", NazwiskoImie.Text ?? "");
        cmd.Parameters.AddWithValue("$SemestrRok", SemestrRok.Text ?? "");
        cmd.Parameters.AddWithValue("$KierunekStopien", KierunekStopien.Text ?? "");
        cmd.Parameters.AddWithValue("$Przedmiot", Przedmiot.Text ?? "");
        cmd.Parameters.AddWithValue("$ECTS", ECTS.Text ?? "");
        cmd.Parameters.AddWithValue("$Prowadzacy", Prowadzacy.Text ?? "");
        cmd.Parameters.AddWithValue("$Uzasadnienie", Uzasadnienie.Text ?? "");
        cmd.Parameters.AddWithValue("$Podpis", Podpis.Text ?? "");
        cmd.Parameters.AddWithValue("$Kom1", Kom1.Text ?? "");
        cmd.Parameters.AddWithValue("$Kom2", Kom2.Text ?? "");
        cmd.Parameters.AddWithValue("$Kom3", Kom3.Text ?? "");
        cmd.Parameters.AddWithValue("$DataDec", DataDec.Text ?? "");
        cmd.Parameters.AddWithValue("$Pieczatka", Pieczatka.Text ?? "");

        cmd.ExecuteNonQuery();
    }

    private void Load(object? sender, RoutedEventArgs e)
    {
        var entries = GetEntries().ToList();
        EntriesList.ItemsSource = entries;
    }

    private IEnumerable<FormEntry> GetEntries()
    {
        var entries = new List<FormEntry>();
        using var conn = new SqliteConnection(ConnectionString);
        conn.Open();

        var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM Wnioski ORDER BY Id DESC";

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            entries.Add(new FormEntry
            {
                Id = reader.GetInt32(0),
                Data = reader.GetString(1),
                Album = reader.GetString(2),
                NazwiskoImie = reader.GetString(3),
                SemestrRok = reader.GetString(4),
                KierunekStopien = reader.GetString(5),
                Przedmiot = reader.GetString(6),
                ECTS = reader.GetString(7),
                Prowadzacy = reader.GetString(8),
                Uzasadnienie = reader.GetString(9),
                Podpis = reader.GetString(10),
                Kom1 = reader.GetString(11),
                Kom2 = reader.GetString(12),
                Kom3 = reader.GetString(13),
                DataDec = reader.GetString(14),
                Pieczatka = reader.GetString(15)
            });
        }

        return entries;
    }
    private void OnEntrySelected(object? sender, SelectionChangedEventArgs e)
    {
        if (EntriesList.SelectedItem is FormEntry entry)
        {
            Data.Text = entry.Data;
            Album.Text = entry.Album;
            NazwiskoImie.Text = entry.NazwiskoImie;
            SemestrRok.Text = entry.SemestrRok;
            KierunekStopien.Text = entry.KierunekStopien;
            Przedmiot.Text = entry.Przedmiot;
            ECTS.Text = entry.ECTS;
            Prowadzacy.Text = entry.Prowadzacy;
            Uzasadnienie.Text = entry.Uzasadnienie;
            Podpis.Text = entry.Podpis;
            Kom1.Text = entry.Kom1;
            Kom2.Text = entry.Kom2;
            Kom3.Text = entry.Kom3;
            DataDec.Text = entry.DataDec;
            Pieczatka.Text = entry.Pieczatka;
        }
    }
}
using System;
using System.IO;
using System.Xml.Serialization;
[Serializable]
public class Osoba
{
    public int Id { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Stanowisko { get; set; }
    public int Wiek { get; set; }
    public Osoba() { }
    public Osoba(int id, string imie, string nazwisko, int wiek, string stanowisko)
    {
        Id = id;
        Imie = imie;
        Nazwisko = nazwisko;
        Wiek = wiek;
        Stanowisko = stanowisko;
    }
}

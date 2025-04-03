using System;
using System.IO;
using System.Xml.Serialization;
public class Osoba
{
    public sting Id { get; set; };
    public string Imie { get; set; };
    public string Nazwisko { get; set; };
    public string Stanowisko { get; set; };
    public int Wiek { get; set; };
    public Osoba(int id,string imie, string nazwisko, int wiek, string stanowisko)
	{
        Id = id;
        Imie = imie;
        Nazwisko = nazwisko;
        Wiek = wiek;
        Stanowisko = stanowisko;
    }
    public void SerializeToXML(string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Person));
        using (TextWriter writer = new StreamWriter(fileName))
        {
            serializer.Serialize(writer, this);
        }
        Console.WriteLine("Obiekt został zserializowany do pliku XML.");
    }
    public static Person DeserializeFromXML(string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Person));
        using (TextReader reader = new StreamReader(fileName))
        {
            Person person = (Person)serializer.Deserialize(reader);
            Console.WriteLine("Obiekt został odczytany z pliku XML.");
            return person;
        }
    }
    public void DisplayInfo()
    {
        Console.WriteLine("Imię: " + FirstName);
        Console.WriteLine("Nazwisko: " + LastName);
        Console.WriteLine("Wiek: " + Age);

    }
    public static void Main(string[] args)
    {
        Person person1 = new Person("Jan", "Kowalski", 30);
        // Serializacja do XML
        person1.SerializeToXML("person.xml");
        // Odczyt z XML
        Person person2 = Person.DeserializeFromXML("person.xml");
        // Wyświetlenie informacji o osobie odczytanej z XML
        if (person2 != null)
        {
            person2.DisplayInfo();
        }
    }

using System;
using System.Collections.Generic;

class Bankkonto
{
    public string Kontoinhaber { get; set; }
    public decimal Kontostand { get; set; }
    public List<string> Transaktionen { get; set; }

    public Bankkonto(string kontoinhaber, decimal kontostand)
    {
        Kontoinhaber = kontoinhaber;
        Kontostand = kontostand;
        Transaktionen = new List<string>();
    }

    public void Einzahlen(decimal betrag)
    {
        Kontostand += betrag;
        Transaktionen.Add($"Einzahlung: {betrag}"); 
    }

    public void Abheben (decimal betrag)
    {
        if (betrag <= Kontostand)
        {
            Kontostand -= betrag;
            Transaktionen.Add($"Abhebung: {betrag}");
        }
        else
        {
            Console.WriteLine("Nicht genügend Guthaben.");
        }
    }
        public void Kontoauszug()
    {
        Console.WriteLine($"Kontoinhaber: {Kontoinhaber}");
        Console.WriteLine($"Kontostand: {Kontostand}");
        Console.WriteLine("Transaktionen:");
        foreach (var transaktion in Transaktionen)
        {
            Console.WriteLine(transaktion);
        }
    }

}

class Program
{
    static void Main(string[] args)
    {
        Bankkonto konto = new Bankkonto("Max Mustermann", 1000m);
        
        while (true)
        {
          Console.WriteLine("1. Einzahlung");
          Console.WriteLine("2. Auszahlung");
          Console.WriteLine("3. Kontostand");
          Console.WriteLine("4. Beenden");
          
          string auswahl = Console.ReadLine();
          
switch (auswahl)
{
    case "1":
        Console.WriteLine("Welchen Betrag möchten sie einzahlen");
        if (decimal.TryParse(Console.ReadLine(), out decimal einzahlbetrag))
{   konto.Einzahlen(einzahlbetrag);
    Console.WriteLine($"der folgende Betrag {einzahlbetrag} wurde ihrem Konto gutgeschrieben");
}
else
{
    Console.WriteLine("Bitte nur Zahlen eingeben!");
}
        
        break;
    
    case "2":
        Console.WriteLine("Welchen Betrag möchten sie abheben");
        if (decimal.TryParse(Console.ReadLine(), out decimal auszahlbetrag))
        {
          konto.Abheben(auszahlbetrag);
          Console.WriteLine($"der folgende Betrag {auszahlbetrag} wurde von ihrem Konto abgehoben");
          }
          else 
          {
            Console.WriteLine("Bitte nur Zahlen eingeben!");
            }
        
        
        
        break;
    case "3":
        konto.Kontoauszug();
        
        break;
    case "4":
        return;
    default:
        Console.WriteLine("Ungültige Eingabe!");
        break;
}
          

}
          
          
          }
        
        
      
}
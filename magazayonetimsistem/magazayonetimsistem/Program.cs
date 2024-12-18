using System;
using System.Collections.Generic;

abstract class Urun
{
    public string Ad { get; set; }
    public decimal Fiyat { get; set; }

    public abstract decimal HesaplaOdeme();
    public abstract void BilgiYazdir();
}

class Kitap : Urun
{
    public string Yazar { get; set; }

    public override decimal HesaplaOdeme()
    {
        return Fiyat * 1.10m;
    }

    public override void BilgiYazdir()
    {
        Console.WriteLine($"Kitap: {Ad}, Yazar: {Yazar}, Fiyat: {Fiyat:C}, Ödeme: {HesaplaOdeme():C}");
    }
}

class Elektronik : Urun
{
    public string Marka { get; set; }

    public override decimal HesaplaOdeme()
    {
        return Fiyat * 1.25m;
    }

    public override void BilgiYazdir()
    {
        Console.WriteLine($"Elektronik: {Ad}, Marka: {Marka}, Fiyat: {Fiyat:C}, Ödeme: {HesaplaOdeme():C}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Urun> urunler = new List<Urun>
        {
            new Kitap { Ad = "C# Öğreniyorum", Yazar = "Ali Veli", Fiyat = 50 },
            new Elektronik { Ad = "Kulaklık", Marka = "Sony", Fiyat = 300 }
        };

        foreach (var urun in urunler)
        {
            urun.BilgiYazdir();
        }
    }
}

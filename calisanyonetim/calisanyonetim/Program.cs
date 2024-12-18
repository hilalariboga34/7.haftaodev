using System;

public class Calisan
{
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public double Maas { get; set; }
    public string Pozisyon { get; set; }

    public virtual void BilgiYazdir()
    {
        Console.WriteLine($"Ad: {Ad}, Soyad: {Soyad}, Maaş: {Maas}, Pozisyon: {Pozisyon}");
    }
}

public class Yazilimci : Calisan
{
    public string YazilimDili { get; set; }

    public override void BilgiYazdir()
    {
        Console.WriteLine($"Ad: {Ad}, Soyad: {Soyad}, Maaş: {Maas}, Pozisyon: {Pozisyon}, Yazılım Dili: {YazilimDili}");
    }
}

public class Muhasebeci : Calisan
{
    public string MuhasebeYazilimi { get; set; }

    public override void BilgiYazdir()
    {
        Console.WriteLine($"Ad: {Ad}, Soyad: {Soyad}, Maaş: {Maas}, Pozisyon: {Pozisyon}, Muhasebe Yazılımı: {MuhasebeYazilimi}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Çalışan türünü seçin: 1- Yazılımcı, 2- Muhasebeci");
        int secim = int.Parse(Console.ReadLine());

        if (secim == 1)
        {
            Yazilimci yazilimci = new Yazilimci();
            Console.Write("Ad: "); yazilimci.Ad = Console.ReadLine();
            Console.Write("Soyad: "); yazilimci.Soyad = Console.ReadLine();
            Console.Write("Maaş: "); yazilimci.Maas = double.Parse(Console.ReadLine());
            Console.Write("Pozisyon: "); yazilimci.Pozisyon = Console.ReadLine();
            Console.Write("Yazılım Dili: "); yazilimci.YazilimDili = Console.ReadLine();
            yazilimci.BilgiYazdir();
        }
        else if (secim == 2)
        {
            Muhasebeci muhasebeci = new Muhasebeci();
            Console.Write("Ad: "); muhasebeci.Ad = Console.ReadLine();
            Console.Write("Soyad: "); muhasebeci.Soyad = Console.ReadLine();
            Console.Write("Maaş: "); muhasebeci.Maas = double.Parse(Console.ReadLine());
            Console.Write("Pozisyon: "); muhasebeci.Pozisyon = Console.ReadLine();
            Console.Write("Muhasebe Yazılımı: "); muhasebeci.MuhasebeYazilimi = Console.ReadLine();
            muhasebeci.BilgiYazdir();
        }
        else
        {
            Console.WriteLine("Geçersiz seçim.");
        }
    }
}

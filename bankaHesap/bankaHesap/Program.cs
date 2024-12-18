using System;

abstract class Hesap
{
    public int HesapNo { get; set; }
    public decimal Bakiye { get; protected set; } // Sadece türetilmiş sınıflar değiştirebilir.

    public abstract void ParaYatir(decimal miktar);
    public abstract void ParaCek(decimal miktar);
}

class BirikimHesabi : Hesap
{
    public decimal FaizOrani { get; set; }

    public BirikimHesabi(decimal faizOrani)
    {
        FaizOrani = faizOrani;
    }

    public override void ParaYatir(decimal miktar)
    {
        decimal faiz = miktar * FaizOrani;
        Bakiye += miktar + faiz;
        Console.WriteLine($"Birikim Hesabına {miktar:C} yatırıldı. Yeni bakiye: {Bakiye:C}");
    }

    public override void ParaCek(decimal miktar)
    {
        if (miktar <= Bakiye)
        {
            Bakiye -= miktar;
            Console.WriteLine($"Birikim Hesabından {miktar:C} çekildi. Kalan bakiye: {Bakiye:C}");
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye.");
        }
    }
}

class VadesizHesap : Hesap
{
    public decimal IslemUcreti { get; set; } = 5.0m;

    public override void ParaYatir(decimal miktar)
    {
        Bakiye += miktar;
        Console.WriteLine($"Vadesiz Hesabına {miktar:C} yatırıldı. Yeni bakiye: {Bakiye:C}");
    }

    public override void ParaCek(decimal miktar)
    {
        if (miktar + IslemUcreti <= Bakiye)
        {
            Bakiye -= miktar + IslemUcreti;
            Console.WriteLine($"Vadesiz Hesaptan {miktar:C} çekildi (İşlem ücreti: {IslemUcreti:C}). Kalan bakiye: {Bakiye:C}");
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye.");
        }
    }
}

interface IBankaHesabi
{
    DateTime HesapAcilisTarihi { get; set; }
    void HesapOzeti();
}

class Program
{
    static void Main(string[] args)
    {
        // Birikim Hesabı Oluşturma
        BirikimHesabi birikimHesap = new BirikimHesabi(0.05m)
        {
            HesapNo = 101
        };
        birikimHesap.ParaYatir(1000);
        birikimHesap.ParaCek(300);
        Console.WriteLine($"Birikim Hesap Son Bakiyesi: {birikimHesap.Bakiye:C}\n");

        // Vadesiz Hesap Oluşturma
        VadesizHesap vadesizHesap = new VadesizHesap
        {
            HesapNo = 102
        };
        vadesizHesap.ParaYatir(500);
        vadesizHesap.ParaCek(100);
        Console.WriteLine($"Vadesiz Hesap Son Bakiyesi: {vadesizHesap.Bakiye:C}");
    }
}

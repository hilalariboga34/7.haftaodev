using System;

public class Hesap
{
    public string HesapNumarasi { get; set; }
    public double Bakiye { get; set; }
    public string HesapSahibi { get; set; }

    public virtual void BilgiYazdir()
    {
        Console.WriteLine($"Hesap No: {HesapNumarasi}, Bakiye: {Bakiye}, Sahip: {HesapSahibi}");
    }

    public virtual void ParaYatir(double miktar)
    {
        Bakiye += miktar;
        Console.WriteLine($"{miktar} yatırıldı. Yeni bakiye: {Bakiye}");
    }

    public virtual void ParaCek(double miktar)
    {
        if (miktar <= Bakiye)
        {
            Bakiye -= miktar;
            Console.WriteLine($"{miktar} çekildi. Kalan bakiye: {Bakiye}");
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye!");
        }
    }
}

public class VadesizHesap : Hesap
{
    public double EkHesapLimiti { get; set; }

    public override void ParaCek(double miktar)
    {
        if (miktar <= Bakiye + EkHesapLimiti)
        {
            Bakiye -= miktar;
            Console.WriteLine($"{miktar} çekildi. Kalan bakiye: {Bakiye}");
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye ve ek hesap limiti!");
        }
    }
}

public class VadeliHesap : Hesap
{
    public int VadeSuresi { get; set; }
    public double FaizOrani { get; set; }

    public override void ParaCek(double miktar)
    {
        if (VadeSuresi > 0)
        {
            Console.WriteLine("Vade dolmadan para çekemezsiniz!");
        }
        else
        {
            base.ParaCek(miktar);
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Hesap türünü seçin: 1- Vadesiz Hesap, 2- Vadeli Hesap");
        int secim = int.Parse(Console.ReadLine());

        if (secim == 1)
        {
            VadesizHesap vadesiz = new VadesizHesap();
            Console.Write("Hesap No: "); vadesiz.HesapNumarasi = Console.ReadLine();
            Console.Write("Sahip: "); vadesiz.HesapSahibi = Console.ReadLine();
            Console.Write("Bakiye: "); vadesiz.Bakiye = double.Parse(Console.ReadLine());
            Console.Write("Ek Hesap Limiti: "); vadesiz.EkHesapLimiti = double.Parse(Console.ReadLine());
            vadesiz.ParaYatir(500);
            vadesiz.ParaCek(200);
            vadesiz.BilgiYazdir();
        }
        else if (secim == 2)
        {
            VadeliHesap vadeli = new VadeliHesap();
            Console.Write("Hesap No: "); vadeli.HesapNumarasi = Console.ReadLine();
            Console.Write("Sahip: "); vadeli.HesapSahibi = Console.ReadLine();
            Console.Write("Bakiye: "); vadeli.Bakiye = double.Parse(Console.ReadLine());
            Console.Write("Vade Süresi: "); vadeli.VadeSuresi = int.Parse(Console.ReadLine());
            Console.Write("Faiz Oranı: "); vadeli.FaizOrani = double.Parse(Console.ReadLine());
            vadeli.ParaYatir(1000);
            vadeli.ParaCek(500);
            vadeli.BilgiYazdir();
        }
        else
        {
            Console.WriteLine("Geçersiz seçim.");
        }
    }
}

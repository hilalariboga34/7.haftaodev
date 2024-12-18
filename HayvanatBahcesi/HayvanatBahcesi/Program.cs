using System;

public class Hayvan
{
    public string Ad { get; set; }
    public string Tur { get; set; }
    public int Yas { get; set; }

    public virtual void SesCikar()
    {
        Console.WriteLine("Hayvan bir ses çıkardı.");
    }
}

public class Memeli : Hayvan
{
    public string TuyRengi { get; set; }

    public override void SesCikar()
    {
        Console.WriteLine($"{Ad} bir memeli ve ses çıkarıyor: Vuh Vuh!");
    }
}

public class Kus : Hayvan
{
    public double KanatGenisligi { get; set; }

    public override void SesCikar()
    {
        Console.WriteLine($"{Ad} bir kuş ve ses çıkarıyor: Cik Cik!");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Hayvan türünü seçin: 1- Memeli, 2- Kuş");
        int secim = int.Parse(Console.ReadLine());

        if (secim == 1)
        {
            Memeli memeli = new Memeli();
            Console.Write("Ad: "); memeli.Ad = Console.ReadLine();
            Console.Write("Tür: "); memeli.Tur = Console.ReadLine();
            Console.Write("Yaş: "); memeli.Yas = int.Parse(Console.ReadLine());
            Console.Write("Tüy Rengi: "); memeli.TuyRengi = Console.ReadLine();
            memeli.SesCikar();
        }
        else if (secim == 2)
        {
            Kus kus = new Kus();
            Console.Write("Ad: "); kus.Ad = Console.ReadLine();
            Console.Write("Tür: "); kus.Tur = Console.ReadLine();
            Console.Write("Yaş: "); kus.Yas = int.Parse(Console.ReadLine());
            Console.Write("Kanat Genişliği: "); kus.KanatGenisligi = double.Parse(Console.ReadLine());
            kus.SesCikar();
        }
        else
        {
            Console.WriteLine("Geçersiz seçim.");
        }
    }
}

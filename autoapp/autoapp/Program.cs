using System.Security.Cryptography.X509Certificates;

namespace autoapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // indítás előtt az auto.csv fájlt a bin/debug mappába kell rakni a működés érdekében!

            //5. feladat: Az autók számának kiírása
            List<Auto> autok = Auto.Beolvas("autok.csv");
            Console.WriteLine($"5. feladat: {autok.Count} autó található a listában");

            //6. feladat: Az átlagosan eladott darabszám kiírása
            double atlagEladottDarabSzam = autok.Average(x => x.EladottDarabSzam);
            Console.WriteLine($"6. feladat: Az autók esetében az átlagosan eladott darabszám {atlagEladottDarabSzam:F1}");

            //7. feladat: Az elmúlt 5 évben gyártott autók kiírása
            Console.WriteLine("7. feladat: Az elmúlt 5 évben gyártott autók:");
            List<Auto> elmult5evautok = autok.Where(x => x.GyartasiEv >= DateTime.Now.Year - 5).ToList();
            foreach (var auto in elmult5evautok)
            {
                Console.WriteLine($"\t - {auto.Marka} {auto.Modell}: {auto.GyartasiEv}");
            }

            //8. feladat: Az egyes márkákhoz tartozó eladott autók számának kiírása
            Console.WriteLine("8. feladat: Az egyes márkákhoz tartozó eladott autók száma:");
            var markakEladasok = autok.GroupBy(x => x.Marka).Select(y => new { Marka = y.Key, EladottDarabSzam = y.Sum(x => x.EladottDarabSzam) });
            foreach (var marka in markakEladasok)
            {
                Console.WriteLine($"\t - {marka.Marka}: {marka.EladottDarabSzam} db");
            }
        }
    }
}

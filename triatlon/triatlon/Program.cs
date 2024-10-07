using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace triatlon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Versenyzok> lista = new List<Versenyzok>();

            StreamReader sr = new StreamReader("forras.txt");

            while (!sr.EndOfStream)
            {
                Versenyzok b = new Versenyzok(sr.ReadLine());
                lista.Add(b);
            }

            sr.Close();

            Console.WriteLine($"Összesen ennyi versenyző fejezte be a versenyt > {lista.Count}");
            Console.WriteLine($"Összesen ennyi versenyző van 'elit' kategóriában > {lista.Count(V => V.VEletkorKategoria == "elit")}");
            Console.WriteLine($"Összesen ennyi volt a futással töltött idő > {lista.Sum(V => V.FutasIdo.TotalHours):0.00}");

            Console.WriteLine($"Átlagos úszási idő 'elit junior' kategóriában > {lista.Where(V => V.VEletkorKategoria == "20-24").Average(V => V.UszasIdo.Minutes)} Perc");

            Console.WriteLine("\n ---------- \n");

            var NoiGyoztes = lista.Where(V => V.VNem == "Nő").OrderBy(V => V.VersenyzoOsszIdeje).First();

            Console.WriteLine(NoiGyoztes.ToString());





            Console.ReadKey(true);
        }
    }
}

using System;

namespace triatlon
{
    internal class Versenyzok
    {
        public string VNev { get; set; }
        public int VSzulEv { get; set; }
        public int VSzam {  get; set; }
        public string VNem { get; set; }
        public string VEletkorKategoria { get; set; }


        public TimeSpan UszasIdo { get; set; }
        public TimeSpan ElsoDepoIdo { get; set; }
        public TimeSpan KerekparIdo { get; set; }
        public TimeSpan MasodikDepo {  get; set; }
        public TimeSpan FutasIdo { get; set; }

        public TimeSpan VersenyzoOsszIdeje => UszasIdo + ElsoDepoIdo + KerekparIdo + MasodikDepo + FutasIdo;
        public double OsszUszasIdo => UszasIdo.TotalHours + UszasIdo.TotalMinutes + UszasIdo.TotalSeconds;


        public override string ToString()
        {

            return 
                $"" +
                $"Név: {VNev} \n" +
                $"Születési év: {VSzulEv} \n" +
                $"Rajtszám: {VSzam} \n" +
                $"Neme: {VNem} \n" +
                $"Életkor kategória: {VEletkorKategoria} \n" +
                $"\n" +
                $"Úszás ideje: {UszasIdo} \n" +
                $"Első depóban töltött ideje: {ElsoDepoIdo} \n" +
                $"Kerékpár ideje: {KerekparIdo} \n" +
                $"Második depóban töltött ideje: {MasodikDepo} \n" +
                $"Futás ideje: {FutasIdo} \n" +
                $"Összideje (Úszás - Depó - Kerékpár - Depó - Futás): {VersenyzoOsszIdeje}";
        }

        public Versenyzok(string sor)
        {
            string[] darabok = sor.Split(';');

            VNev = darabok[0];
            VSzulEv = int.Parse(darabok[1]);
            VSzam = int.Parse(darabok[2]);
            if (darabok[3] == "n")
            {
                VNem = "Nő";
            }
            else
            {
                VNem = "Férfi";
            }
            VEletkorKategoria = darabok[4];

            UszasIdo = TimeSpan.ParseExact(darabok[5], "hh\\:mm\\:ss", null);
            ElsoDepoIdo = TimeSpan.ParseExact(darabok[6], "hh\\:mm\\:ss", null);
            KerekparIdo = TimeSpan.ParseExact(darabok[7], "hh\\:mm\\:ss", null);
            MasodikDepo = TimeSpan.ParseExact(darabok[8], "hh\\:mm\\:ss", null);
            FutasIdo = TimeSpan.ParseExact(darabok[9], "hh\\:mm\\:ss", null);
        }
    }
}

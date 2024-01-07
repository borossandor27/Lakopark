using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lakopark
{
    internal class Lakopark
    {

        //- egy lakópark minden adatát reprezentáló osztály
        int lakoparkId;
        int[,] hazak;
        string nev;
        int utcakSzama;
        int telkekSzama;

        Image[] emeletKepek = new Image[4];

        public int[,] Hazak { get => hazak; set => hazak = value; }
        public string Nev { get => nev; set => nev = value; }
        public int UtcakSzama { get => utcakSzama; set => utcakSzama = value; }
        public int TelkekSzama { get => telkekSzama; set => telkekSzama = value; }
        public int LakoparkId { get => lakoparkId; set => lakoparkId = value; }

        public Lakopark(int id, string nev, int utcakSzama, int telkekSzama)
        {
            this.lakoparkId = id;
            this.nev = nev;
            this.utcakSzama = utcakSzama;
            this.telkekSzama = telkekSzama;
            hazak = new int[utcakSzama, telkekSzama];
            emeletKepek[0] = Image.FromFile($"Kepek{Path.DirectorySeparatorChar}kereszt.jpg");
            emeletKepek[1] = Image.FromFile($"Kepek{Path.DirectorySeparatorChar}Haz1.jpg");
            emeletKepek[2] = Image.FromFile($"Kepek{Path.DirectorySeparatorChar}Haz2.jpg");
            emeletKepek[3] = Image.FromFile($"Kepek{Path.DirectorySeparatorChar}Haz3.jpg");
        }
        public void HazFeltoltese(int utca, int hazszam, int emelet)
        {
            hazak[utca - 1, hazszam - 1] = emelet;
        }
        public Image HazKepImage(int utca, int hazszam)
        {
            return emeletKepek[hazak[utca - 1, hazszam - 1]];
        }
        public void emeletetNovel(int utca, int hazszam)
        {
            if (hazak[utca - 1, hazszam - 1] < 3) hazak[utca - 1, hazszam - 1]++; else hazak[utca - 1, hazszam - 1]=0;
        }
        public void emeletetCsokkent(int utca, int hazszam)
        {
            if (hazak[utca - 1, hazszam - 1] > 0) hazak[utca - 1, hazszam - 1]--;
            else
            {
                hazak[utca - 1, hazszam - 1] = 3;
            }
        }
        public Image nevadoKepe()
        {
            return Image.FromFile($"Kepek{Path.DirectorySeparatorChar}{this.nev}.jpg");
        }
        public int getEmelet(int utca, int hazszam)
        {
            return hazak[utca - 1, hazszam - 1];
        }
        private int getHazakSzama()
        {
            int db = 0;
            for (int i = 0; i < utcakSzama; i++)
            {
                for (int j = 0; j < telkekSzama; j++)
                {
                    if (hazak[i, j] > 0) db++;
                }
            }
            return db;
        }
        public double bevetel()
        {
            double bevetel = 0;
            for (int i = 0;  i < this.telkekSzama;  i++)
            {
                for (int j = 0; j < this.utcakSzama; j++)
                {
                    if (this.hazak[i, j] == 1)
                    {
                        bevetel += 80;
                    } else if (this.hazak[i, j] == 2)
                    {
                        bevetel += 80+70;
                    } else if (this.hazak[i, j] == 3)
                    {
                        bevetel += 80+70+50;
                    }
                }
                
            }
            return bevetel*300000;
        }
        public double beepitettseg()
        {
            return (double)getHazakSzama() / (double)(this.telkekSzama * this.utcakSzama);
        }

        public int teljesenBeepitettUtca()
        {
            int db = -1;
            for (int i = 0; i < this.utcakSzama; i++)
            {
                int hazakSzama = 0;
                for (int j = 0; j < this.telkekSzama; j++)
                {
                    if (this.hazak[i, j] > 0) hazakSzama++;
                }
                if (hazakSzama == this.telkekSzama)
                {
                    db = i;
                    break;
                }
            }
            return db;
        }
    }
}

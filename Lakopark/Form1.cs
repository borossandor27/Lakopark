using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lakopark
{
    public partial class Form1 : Form
    {
        List<Lakopark> HappyLiving = new List<Lakopark>();
        Adatbazis adatbazis = new Adatbazis();
        int lakoparkIndex = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HappyLiving = adatbazis.lakoparkokBetoltese();
            LakoparkBetoltese();
        }

        private void LakoparkBetoltese()
        {
            button_Novel.Visible = (lakoparkIndex < HappyLiving.Count - 1? true : false);
            button_Csokkent.Visible = (lakoparkIndex > 0 ? true : false);
            panel_Hazak.Controls.Clear();
            this.Text =$" {HappyLiving[lakoparkIndex].Nev} lakópark";
            pictureBox_Nevado.Image = HappyLiving[lakoparkIndex].nevadoKepe();
            pictureBox_Nevado.SizeMode = PictureBoxSizeMode.StretchImage;
            for (int i = 0; i < HappyLiving[lakoparkIndex].UtcakSzama; i++)
            {
                for (int j = 0; j < HappyLiving[lakoparkIndex].TelkekSzama; j++)
                {
                    PictureBox pb = new PictureBox();
                    pb.Image = HappyLiving[lakoparkIndex].HazKepImage(i + 1, j + 1);
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.Size = new Size(50, 50);
                    pb.Location = new Point(50 * j, 50 * i);
                    pb.Tag = new int[] { i + 1, j + 1, HappyLiving[lakoparkIndex].getEmelet(i+1,j+1) };
                    pb.Click += Haz_Click;
                    panel_Hazak.Controls.Add(pb);
                }
            }
        }

        private void Haz_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            int[] tag = (int[])pb.Tag;
            //-- megnöveli az emeletek számát ---
            HappyLiving[lakoparkIndex].emeletetNovel(tag[0], tag[1]);
            //-- frissíti a képet ---
            pb.Image = HappyLiving[lakoparkIndex].HazKepImage(tag[0], tag[1]);
        }

        private void button_Csokkent_Click(object sender, EventArgs e)
        {
            if (lakoparkIndex>0)            lakoparkIndex--;
            LakoparkBetoltese();
        }

        private void button_Novel_Click(object sender, EventArgs e)
        {
            if (lakoparkIndex<HappyLiving.Count-1) lakoparkIndex++;
            LakoparkBetoltese();
        }

        private void button_mentes_Click(object sender, EventArgs e)
        {
            adatbazis.emeletMentes(HappyLiving[lakoparkIndex]);
        }
    }
}

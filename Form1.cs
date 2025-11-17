using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Fa_feladatok
{
    public partial class Form1 : Form
    {
        Dictionary<string, CountryData> data;


        Label lblCountry, lblCapital, lblArea, lblPopulation;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Label cim = new Label();
            cim.Text = "Földrajzi adatok";
            cim.Font = new Font("Arial", 20, FontStyle.Bold);
            cim.AutoSize = true;
            cim.Location = new Point(355, 10);
            this.Controls.Add(cim);


            this.Text = "Országok adatai";
            this.Size = new Size(1000, 600);
            this.BackColor = Color.FromArgb(220, 220, 230);

            data = new Dictionary<string, CountryData>
            {
                { "Austria", new CountryData("Ausztria", "Bécs", "83 879 km²", "8 900 000") },
                { "France", new CountryData("Franciaország", "Párizs", "551 695 km²", "67 800 000") },
                { "UK", new CountryData("Nagy-Britannia", "London", "243 610 km²", "67 000 000") },
                { "Hungary", new CountryData("Magyarország", "Budapest", "93 000 km²", "9 980 000") },
                { "USA", new CountryData("USA", "Washington D.C.", "9 834 000 km²", "331 000 000") }
            };


            CreateFlagButton(Properties.Resources.AT, "Austria", 30);
            CreateFlagButton(Properties.Resources.FR, "France", 210);
            CreateFlagButton(Properties.Resources.GB, "UK", 390);
            CreateFlagButton(Properties.Resources.HU, "Hungary", 570);
            CreateFlagButton(Properties.Resources.USA, "USA", 750);


            CreateLabel("Az ország neve:", 50, 250);
            lblCountry = CreateValueLabel(250, 250);

            CreateLabel("Fővárosa:", 50, 300);
            lblCapital = CreateValueLabel(250, 300);

            CreateLabel("Területe:", 50, 350);
            lblArea = CreateValueLabel(250, 350);

            CreateLabel("Népessége:", 50, 400);
            lblPopulation = CreateValueLabel(250, 400);


            Button btnExit = new Button();
            btnExit.Text = "KILÉPÉS";
            btnExit.Font = new Font("Arial", 10, FontStyle.Italic);
            btnExit.Size = new Size(150, 50);
            btnExit.Location = new Point(800, 500);
            btnExit.Click += (s, ev) => this.Close();
            btnExit.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(btnExit);
            
            
            
            
        }


        private Button CreateFlagButton(Image img, string key, int x)
        {

            Button btn = new Button();
            btn.Size = new Size(150, 100);
            btn.Location = new Point(x, 50);
            btn.Image = img;
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.Tag = key;
            btn.Click += FlagClicked;
            this.Controls.Add(btn);

            
            Label lbl = new Label();
            lbl.Text = data[key].Name;
            lbl.Font = new Font("Arial", 10, FontStyle.Bold);
            lbl.AutoSize = false;
            lbl.Size = new Size(150, 25);
            lbl.Location = new Point(x, 155);
            lbl.TextAlign = ContentAlignment.MiddleCenter;

            this.Controls.Add(lbl);

            return btn;
        }

        private Label CreateLabel(string text, int x, int y)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Font = new Font("Arial", 12, FontStyle.Bold);
            lbl.Location = new Point(x, y);
            lbl.AutoSize = true;
            this.Controls.Add(lbl);
            return lbl;
        }

        private Label CreateValueLabel(int x, int y)
        {
            Label lbl = new Label();
            lbl.Text = "";
            lbl.Font = new Font("Arial", 12, FontStyle.Bold);
            lbl.ForeColor = Color.Black;
            lbl.AutoSize = true;
            lbl.Location = new Point(x, y);
            this.Controls.Add(lbl);
            return lbl;
        }

        private void FlagClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string key = btn.Tag.ToString();
            CountryData c = data[key];

            lblCountry.Text = c.Name;
            lblCapital.Text = c.Capital;
            lblArea.Text = c.Area;
            lblPopulation.Text = c.Population;
        }
    }



    public class CountryData
    {
        public string Name, Capital, Area, Population;

        public CountryData(string n, string c, string a, string p)
        {
            Name = n;
            Capital = c;
            Area = a;
            Population = p;
        }
    }

}
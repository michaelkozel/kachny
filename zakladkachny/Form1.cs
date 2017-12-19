using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zakladkachny
{
    public partial class Form1 : Form
    {

        Button prvni;
        Button druhy;

        int pocetTicku = 0;
        List<Button> list;
        public Form1()
        {
            InitializeComponent();
            prvni = new Button();
            prvni.Text = "Kachna";
            prvni.Left = 100;
            prvni.Top = 10;
            prvni.Click += this.Clicked;
            this.Controls.Add(prvni);

            druhy = new Button();
            druhy.Text = "pada";
            druhy.Left = 200;
            druhy.Top = 10;
            // zmena druha
            druhy.Click += this.Clicked;
            this.Controls.Add(druhy);
            Random random = new Random();
            timer.Enabled = true;
            list = new List<Button>();
       
            for (int i = 0; i < 10; i++)
            {
                int pozice = random.Next(0, this.Width - 1);
                druhy = new Button();
                druhy.Text = "pada";
                druhy.Left = pozice;
                druhy.Top = 10;
                this.Controls.Add(druhy);
                // zmena druha


                list.Add(druhy);
            }
        }

        public void Clicked(object sender, EventArgs args)
        {

            prvni.Text = "Kliknuto";

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < list.Count;i++) {
                Button tlacitko = list[i];
                tlacitko.Top += 3;
                prvni.Text = "Tick " + pocetTicku++;
            }
        }
    }
}

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
        int odkliknuto = 0;
        int pocetTicku = 0;
        List<Button> list;
        public Form1()
        {
            InitializeComponent();

            /*prvni = new Button();
            prvni.Text = "Kachna";
            prvni.Left = 100;
            prvni.Top = 10;
            prvni.Click += this.Clicked;
            this.Controls.Add(prvni);
            druhy = new Button();
            druhy.Text = "pada";
            druhy.Left = 200;
            druhy.Top = 10;
           */
           
            Random random = new Random();
            timer.Enabled = true;
            list = new List<Button>();
            label1.Text = "Skóre: ";
            for (int i = 0; i < 10; i++)
            {
                
                druhy = new Button();
                int pozice = random.Next(label1.Width, ClientSize.Width - druhy.Width);
                druhy.Click += this.Clicked;
                druhy.Text = "Kachna";
                druhy.Left = pozice;
                druhy.Top = random.Next(-10,15) ;
                this.Controls.Add(druhy);
                // zmena druha
                list.Add(druhy);
            }
        }

        public void Clicked(object sender, EventArgs args)
        {
            Button odesilatel = (Button)sender;
            odesilatel.Visible = false;
            odkliknuto++;
            label1.Text = "Skóre: "+odkliknuto;
            if (odkliknuto > 9)
            { label1.Text = "vyhrál jsi"; }
            else { label1.Text = "Skóre: " + odkliknuto; }
            

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < list.Count;i++) {
                Button tlacitko = list[i];
                tlacitko.Top += 2;
               // prvni.Text = "Tick " + pocetTicku++;
                if (tlacitko.Top >ClientSize.Height)
                { tlacitko.Visible = false;
                    odkliknuto--;
                }
            }
        }
    }
}

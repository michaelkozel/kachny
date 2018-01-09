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
        Random random;
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

            random = new Random();
            timer.Enabled = true;
            list = new List<Button>();
            label1.Text = "Skóre: ";
            for (int i = 0; i < 10; i++)
            {

                druhy = new Button();
                druhy.BackgroundImage = Image.FromFile("kachna.png");
                druhy.BackgroundImageLayout = ImageLayout.Stretch;
                druhy.Width = 350;
                druhy.Height = 200;
                int pozice = random.Next(label1.Width, ClientSize.Width - druhy.Width);
                druhy.Click += this.Clicked;
                druhy.Text = "";
                druhy.Left = pozice;
                druhy.Top = random.Next(-10, 15);
                this.Controls.Add(druhy);
                // zmena druha
                list.Add(druhy);
            }
        }

        public void Clicked(object sender, EventArgs args)
        {
            Button odesilatel = (Button)sender;
           
            label1.Text = "Skóre: " + ++odkliknuto; 
            odesilatel.Top = random.Next(-10, 10);
            odesilatel.Left = random.Next(label1.Width, ClientSize.Width - druhy.Width);

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Button tlacitko = list[i];
                tlacitko.Top += 4;
                // prvni.Text = "Tick " + pocetTicku++;
                if (tlacitko.Top > ClientSize.Height)
                {
                    tlacitko.Top = random.Next(-10, 10);
                    tlacitko.Left = random.Next(label1.Width, ClientSize.Width - druhy.Width);
                    odkliknuto--;
                    label1.Text = "Skóre: " + odkliknuto;
                }
            }
        }
    }
}

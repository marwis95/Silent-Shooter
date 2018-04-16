using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms;

namespace Shooter
{
    public partial class Form1 : Form
    {
        int counter = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void ScreenShoot(PictureBox pictureBox1)
        {
            //new Bitmap(szerokość, wysokość, format)
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            Graphics screenshot = Graphics.FromImage(bmp);
            /*
            CopyFromScreen(Początek screena od lewej strony, Początek screena od gory ekranu, 
                     Odleglosc screena od lewej przy wyswietlaniu, Odleglosc screena od góry przy wyswietlaniu, 
                     Wielkość ekranu, Styl screena); 
            */
            screenshot.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            //Wyswietlanie screena
            pictureBox1.Image = bmp;
            pictureBox1.Image.Save(counter.ToString() + ".png");
            counter++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScreenShoot(pictureBox1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            notifyIcon1.Icon = Properties.Resources.Invisible_Icon___By_Solitary_Jay;
            notifyIcon1.Text = "";
            this.ShowInTaskbar = false;
            this.Visible = false;
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            notifyIcon1.Icon = Properties.Resources.circle_32;
            ScreenShoot(pictureBox1);
            notifyIcon1.Icon = Properties.Resources.Invisible_Icon___By_Solitary_Jay;
        }
    }
}

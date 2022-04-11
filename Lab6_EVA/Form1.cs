using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6_EVA
{

    public partial class Form1 : Form
    {
        Image<Bgr, Byte> My_Image;
        Image<Bgr, Byte> imgOutput;
        Image<Gray, byte> gray_image;
        Image<Gray, byte> grayImgOutput;
        Rectangle rect; 
        Point StartROI; 
        bool MouseDown;


        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Openfile = new OpenFileDialog();
            if (Openfile.ShowDialog() == DialogResult.OK)
            {
                My_Image = new Image<Bgr, byte>(Openfile.FileName);
                pictureBox1.Image = My_Image.ToBitmap();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gray_image = My_Image.Convert<Gray, byte>();
            pictureBox2.Image = gray_image.AsBitmap();
            gray_image[0, 0] = new Gray(200);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HistogramViewer v = new HistogramViewer();
            v.HistogramCtrl.GenerateHistograms(My_Image, 255);
            v.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            float alpha = float.Parse(textBox1.Text);
            float beta = float.Parse(textBox2.Text);
            grayImgOutput = new Image<Gray, byte>(gray_image.Width, gray_image.Height);
            for (int i = 0; i < gray_image.Height; i++)
            {
                for (int j = 0; j < gray_image.Width; j++)
                {
                    var v = gray_image[i, j].Intensity * alpha + beta;
                    grayImgOutput[i, j] = new Gray(v);
                }
            }

            pictureBox3.Image = grayImgOutput.AsBitmap();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            var gamma = double.Parse(textBox3.Text);
            imgOutput = new Image<Bgr, byte>(My_Image.Width, My_Image.Height);
            imgOutput = My_Image.Copy();
            imgOutput._GammaCorrect(gamma);
            pictureBox4.Image = imgOutput.AsBitmap();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var scaleFactor=float.Parse(textBox4.Text);
            imgOutput=new Image<Bgr, byte>(My_Image.Width, My_Image.Height);
            imgOutput=My_Image.Copy();
            imgOutput.Resize(scaleFactor,Emgu.CV.CvEnum.Inter.Cubic);
            pictureBox5.Image=imgOutput.AsBitmap();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var angle = float.Parse(textBox5.Text);
            imgOutput = new Image<Bgr, byte>(My_Image.Width, My_Image.Height);
            imgOutput = My_Image.Copy();
            var background = new Bgr();
            background.Red = 255;
            imgOutput=imgOutput.Rotate(angle,background);
            pictureBox6.Image=imgOutput.AsBitmap();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                return;
            }
            int width = Math.Max(StartROI.X, e.X) - Math.Min(StartROI.X, e.X);
            int height = Math.Max(StartROI.Y, e.Y) - Math.Min(StartROI.Y, e.Y);
            rect = new Rectangle(Math.Min(StartROI.X, e.X),
            Math.Min(StartROI.Y, e.Y),
            width,
            height);
            Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDown = false;
            if (pictureBox1.Image == null || rect == Rectangle.Empty)
            { return; }
            var img = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();
            img.ROI = rect;
            var imgROI = img.Copy();
            pictureBox2.Image = imgROI.ToBitmap();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown = true;
            StartROI = e.Location;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (MouseDown)
            {
                using (Pen pen = new Pen(Color.Red, 1))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }
    }
}

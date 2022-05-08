using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        int TotalFrame, FrameNo;
        double Fps;
        bool IsReadingFrame;
        VideoCapture capture;
        private static VideoCapture cameraCapture;
        private Image<Bgr, Byte> newBackgroundImage;
        private static IBackgroundSubtractor fgDetector;





        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private async void ReadAllFrames()
        {

            Mat m = new Mat();
            while (IsReadingFrame == true && FrameNo < TotalFrame)
            {
                FrameNo += 1;
                var mat = capture.QueryFrame();
                pictureBox7.Image = mat.ToBitmap();
                await Task.Delay(1000 / Convert.ToInt16(Fps));
                label1.Text = FrameNo.ToString() + "/" + TotalFrame.ToString();
            }
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

        private void button9_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                return;
            }
            IsReadingFrame = true;
            ReadAllFrames();


        }

        private void ProcessFrames(object sender, EventArgs e)
        {
            Mat frame = cameraCapture.QueryFrame();
            Image<Bgr, byte> frameImage = frame.ToImage<Bgr, Byte>();

            Mat foregroundMask = new Mat();
            fgDetector.Apply(frame, foregroundMask);
            var foregroundMaskImage = foregroundMask.ToImage<Gray, Byte>();
            foregroundMaskImage = foregroundMaskImage.Not();

            var copyOfNewBackgroundImage = newBackgroundImage.Resize(foregroundMaskImage.Width, foregroundMaskImage.Height, Inter.Lanczos4);
            copyOfNewBackgroundImage = copyOfNewBackgroundImage.Copy(foregroundMaskImage);

            foregroundMaskImage = foregroundMaskImage.Not();
            frameImage = frameImage.Copy(foregroundMaskImage);
            frameImage = frameImage.Or(copyOfNewBackgroundImage);

        }

        private async void button10_Click(object sender, EventArgs e)
        {
            string[] FileNames = Directory.GetFiles(@"C:\Users\Alex\Documents\GitHub\Laborator_EVA\Lab6_EVA", "*.jpg");
            List<Image<Bgr, byte>> listImages = new List<Image<Bgr, byte>>();
            foreach (var file in FileNames)
            {
                listImages.Add(new Image<Bgr, byte>(file));
            }
            for (int i = 0; i < listImages.Count - 1; i++)
            {
                for (double alpha = 0.0; alpha <= 1.0; alpha += 0.01)
                {
                    pictureBox1.Image = listImages[i + 1].AddWeighted(listImages[i], alpha, 1 - alpha, 0).AsBitmap();
                    await Task.Delay(25);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            VideoCapture capture = new VideoCapture(@"C:\Users\Alex\Documents\GitHub\Laborator_EVA\Lab6_EVA\video1.mpg");

            int Fourcc = Convert.ToInt32(capture.Get(CapProp.FourCC));
            int Width = Convert.ToInt32(capture.Get(CapProp.FrameWidth));
            int Height = Convert.ToInt32(capture.Get(CapProp.FrameHeight));
            var Fps = capture.Get(CapProp.Fps);
            var TotalFrame = capture.Get(CapProp.FrameCount);


            string destionpath = @"C:\Users\Alex\Documents\GitHub\Laborator_EVA\Lab6_EVA\output.mpg";
            using (VideoWriter writer = new VideoWriter(destionpath, Fourcc, Fps, new Size(Width, Height), true))
            {
                Image<Bgr, byte> logo = new Image<Bgr, byte>(@"C:\Users\Alex\Documents\GitHub\Laborator_EVA\Lab6_EVA\logo.jpg");
                Mat m = new Mat();

                var FrameNo = 1;
                while (FrameNo < TotalFrame)
                {
                    capture.Read(m);
                    Image<Bgr, byte> img = m.ToImage<Bgr, byte>();
                    img.ROI = new Rectangle(Width - logo.Width - 30, 10, logo.Width, logo.Height);
                    logo.CopyTo(img);

                    img.ROI = Rectangle.Empty;

                    writer.Write(img.Mat);
                    FrameNo++;
                }
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                capture = new VideoCapture(ofd.FileName);
                Mat m = new Mat();
                capture.Read(m);
                pictureBox7.Image = m.ToBitmap();

                TotalFrame = (int)capture.Get(CapProp.FrameCount);
                Fps = capture.Get(CapProp.Fps);
                FrameNo = 1;
                numericUpDown1.Value = FrameNo;
                numericUpDown1.Minimum = 0;
                numericUpDown1.Maximum = TotalFrame;

            }

        }

    }
}

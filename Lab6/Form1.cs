using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Operations.Class1;

namespace Lab6
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> myImage;
        Image<Bgr, byte> resizedImage;
        Image<Bgr, byte> rotatedImage;
        Image<Bgr, byte> gammaOutput;
        Image<Gray, byte> grayImage;
        Image<Gray, byte> imgOutput;
        List<Image<Bgr, byte>> listImages;
        Rectangle rectangle;
        Point startROI;
        bool mouseDown;

        int TotalFrame, FrameNo;
        double Fps;
        bool IsReadingFrame;
        VideoCapture capture;

        //private static VideoCapture cameraCapture;
        //private Image<Bgr, Byte> newBackgroundImage;
        //private static IBackgroundSubtractor fgDetector;

        public Form1()
        {
            InitializeComponent();
        }

        public void LoadImage_Click(object sender, EventArgs e)
        {
            modifiedPicture.Image = null;
            LoadImage(ref myImage);
            originalPicture.Image = myImage.ToBitmap();
        }

        private void ConvertToGrayscale_Click(object sender, EventArgs e)
        {
            ConvertToGrayscale(myImage, ref grayImage);
            modifiedPicture.Image = grayImage.AsBitmap();
        }

        private void GenerateHistogram_Click(object sender, EventArgs e)
        {
            GenerateHistogram(myImage);
        }

        private void ChangeContrast_Click(object sender, EventArgs e)
        {
            float alpha = float.Parse(alphaTextBox.Text);
            float beta = float.Parse(betaTextBox.Text);
            ConvertToGrayscale(myImage, ref imgOutput);
            ChangeContrast(alpha,beta,ref imgOutput);
            modifiedPicture.Image = imgOutput.AsBitmap();
        }

        private void GammaCorrection_Click(object sender, EventArgs e)
        {
            double gamma = double.Parse(gammaTextBox.Text);
            gammaOutput = myImage;
            gammaOutput._GammaCorrect(gamma);
            modifiedPicture.Image = gammaOutput.AsBitmap();
        }

        private void ResizeImage_Click(object sender, EventArgs e)
        {
            ResizeImage(myImage, ref resizedImage);
            modifiedPicture.Image = resizedImage.AsBitmap();
        }
   
        private void RotateImage_Click(object sender, EventArgs e)
        {
            RotateImage(myImage, ref rotatedImage);
            modifiedPicture.Image = rotatedImage.AsBitmap();
        }

        private async void BlendImages_Click(object sender, EventArgs e)
        {
            BlendImages(ref listImages);
            for (int i = 0; i < listImages.Count - 1; i++)
            {
                for (double alpha = 0.0; alpha <= 1.0; alpha += 0.01)
                {
                    modifiedPicture.Image = listImages[i + 1].AddWeighted(listImages[i], alpha, 1 - alpha, 0).AsBitmap();
                    await Task.Delay(25);
                }
            }
        }

        private void LoadVideo_Click(object sender, EventArgs e)
        {
            modifiedPicture.Image = null;
            string videoPath = @"C:\Users\Alex\Documents\GitHub\Laborator_EVA\Star Wars Reflections 4K Unreal Engine Real-Time Ray Tracing Demonstration (360).mp4";
            Image output = originalPicture.Image;
            LoadVideo(ref TotalFrame, ref FrameNo, ref Fps, ref capture, ref output, videoPath);
            originalPicture.Image = output;
            frameCounter.Minimum = 0;
            frameCounter.Maximum = TotalFrame;
            frameCounter.Value = FrameNo;
        }

        private void StartVideo_Click(object sender, EventArgs e)
        {
            if (capture == null) return;
            IsReadingFrame = true;
            ReadAllFrames();
        }        

        private void WriteLogoToVideo_Click(object sender, EventArgs e)
        {
            string videoPath = @"C:\Users\Alex\Documents\GitHub\Laborator_EVA\Do. Or do not. There is no try.mpg";
            string destinationPath = @"C:\Users\Alex\Documents\GitHub\Laborator_EVA\ouput.mpg";
            string logoPath = @"C:\Users\Alex\Documents\GitHub\Laborator_EVA\logo.jpg";

            PutLogo(videoPath,destinationPath,logoPath);
        }

        private async void ReadAllFrames()
        {
            Mat m = new Mat();
            while (IsReadingFrame == true && FrameNo < TotalFrame-1)
            {
                
                var mat = capture.QueryFrame();
                originalPicture.Image = mat.ToBitmap();
                await Task.Delay(1000 / Convert.ToInt16(Fps));
                framesLabel.Text = FrameNo.ToString() + "/" + TotalFrame.ToString();
                FrameNo += 1;
                if (capture == null) return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string videoPath = @"C:\Users\Alex\Documents\GitHub\Laborator_EVA\Star Wars Reflections 4K Unreal Engine Real-Time Ray Tracing Demonstration (360).mp4";
            string videoPath2 = @"C:\Users\Alex\Documents\GitHub\Laborator_EVA\Do. Or do not. There is no try.mpg";
            Image output = originalPicture.Image;

            LoadVideo(ref TotalFrame, ref FrameNo, ref Fps, ref capture, ref output, videoPath);
            originalPicture.Image = output;
            frameCounter.Minimum = 0;
            frameCounter.Maximum = TotalFrame;
            frameCounter.Value = FrameNo;
            IsReadingFrame = true;
            ReadAllFrames();

            LoadVideo(ref TotalFrame, ref FrameNo, ref Fps, ref capture, ref output, videoPath2);
            originalPicture.Image = output;
            frameCounter.Minimum = 0;
            frameCounter.Maximum = TotalFrame;
            frameCounter.Value = FrameNo;
            IsReadingFrame = true;
            ReadAllFrames();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            startROI = e.Location;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (originalPicture.Image == null)
            {
                return;
            }
            int width = Math.Max(startROI.X, e.X) - Math.Min(startROI.X, e.X);
            int height = Math.Max(startROI.Y, e.Y) - Math.Min(startROI.Y, e.Y);
            rectangle = new Rectangle(
                    Math.Min(startROI.X, e.X),
                    Math.Min(startROI.Y, e.Y),
                    width,
                    height
                );
            int mouseX = e.X;
            int mouseY = e.Y;
            Refresh();
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            if (originalPicture.Image == null || rectangle == Rectangle.Empty)
                return;

            var img = new Bitmap(originalPicture.Image).ToImage<Bgr, byte>();
            img.ROI = rectangle;
            var imgROI = img.Copy();
            modifiedPicture.Image = imgROI.ToBitmap();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (mouseDown)
            {
                using (Pen pen = new Pen(Color.Red, 1))
                {
                    e.Graphics.DrawRectangle(pen, rectangle);
                }
            }
        }
    }
}

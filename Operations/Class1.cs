using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operations
{
    public class Class1
    {
        public static void LoadImage(ref Image<Bgr, byte> myImage)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                myImage = new Image<Bgr, Byte>(OpenFile.FileName);
            }
        }

        public static void ConvertToGrayscale(Image<Bgr, byte> myImage, ref Image<Gray, byte> grayImage)
        {
            grayImage = myImage.Convert<Gray, Byte>();
        }

        public static void GenerateHistogram(Image<Bgr, byte> myImage)
        {
            HistogramViewer v = new HistogramViewer();
            v.HistogramCtrl.GenerateHistograms(myImage, 255);
            v.Show();
        }

        public static void ResizeImage(Image<Bgr, byte> myImage, ref Image<Bgr, byte> resizedImage)
        {
            resizedImage = new Image<Bgr, byte>(myImage.Width, myImage.Height);
            resizedImage = myImage.Resize(256, 128, Emgu.CV.CvEnum.Inter.Cubic);
        }

        public static void RotateImage(Image<Bgr, byte> myImage, ref Image<Bgr, byte> rotatedImage)
        {
            rotatedImage = new Image<Bgr, byte>(myImage.Width, myImage.Height);
            rotatedImage = myImage.Rotate(45, new Bgr(255, 255, 255));
        }

        public static void BlendImages(ref List<Image<Bgr, byte>> listImages)
        {
            string[] FileNames = Directory.GetFiles(@"C:\Users\Alex\Documents\GitHub\Laborator_EVA", "*.jpg");
            listImages = new List<Image<Bgr, byte>>();
            foreach (var file in FileNames)
            {
                listImages.Add(new Image<Bgr, byte>(file));
            }
        }

        public static void ChangeContrast(float alpha, float beta, ref Image<Gray, byte> imgOutput)
        {
            for (int i = 0; i < imgOutput.Height; i++)
                for (int j = 0; j < imgOutput.Width; j++)
                {
                    var formula = imgOutput[i, j].Intensity * alpha + beta;
                    imgOutput[i, j] = new Gray(formula);
                }
        }

        public static void PutLogo(string videoPath, string destinationPath, string logoPath)
        {
            VideoCapture capture = new VideoCapture(videoPath);

            int Fourcc = Convert.ToInt32(capture.Get(CapProp.FourCC));
            int Width = Convert.ToInt32(capture.Get(CapProp.FrameWidth));
            int Height = Convert.ToInt32(capture.Get(CapProp.FrameHeight));
            var Fps = capture.Get(CapProp.Fps);
            var TotalFrame = capture.Get(CapProp.FrameCount);


            using (VideoWriter writer = new VideoWriter(destinationPath, Fourcc, Fps, new Size(Width, Height), true))
            {
                Image<Bgr, byte> logo = new Image<Bgr, byte>(logoPath);
                Mat m = new Mat();

                var FrameNo = 1;
                while (FrameNo < TotalFrame)
                {
                    capture.Read(m);
                    Image<Bgr, byte> img = m.ToImage<Bgr, byte>();
                    img.ROI = new Rectangle(10, 10, logo.Width-1, logo.Height-1);
                    logo.CopyTo(img);

                    img.ROI = Rectangle.Empty;

                    writer.Write(img.Mat);
                    FrameNo++;
                }
            }
        }

        public static void LoadVideo(ref int TotalFrame, ref int FrameNo, ref double Fps, ref VideoCapture capture, ref Image output, string videoPath)
        {
            capture = new VideoCapture(videoPath);
            Mat m = new Mat();
            capture.Read(m);
            output = m.ToBitmap();
            TotalFrame = (int)capture.Get(CapProp.FrameCount);
            Fps = capture.Get(CapProp.Fps);
            FrameNo = 1;
        }
    }
}

namespace Lab6
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.originalPicture = new System.Windows.Forms.PictureBox();
            this.modifiedPicture = new System.Windows.Forms.PictureBox();
            this.btnConvertToGrayscale = new System.Windows.Forms.Button();
            this.btnGenerateHistogram = new System.Windows.Forms.Button();
            this.alphaTextBox = new System.Windows.Forms.TextBox();
            this.betaTextBox = new System.Windows.Forms.TextBox();
            this.alfaLabel = new System.Windows.Forms.Label();
            this.betaLabel = new System.Windows.Forms.Label();
            this.btnChangeContrast = new System.Windows.Forms.Button();
            this.gammaTextBox = new System.Windows.Forms.TextBox();
            this.gammaLabel = new System.Windows.Forms.Label();
            this.btnGammaCorrection = new System.Windows.Forms.Button();
            this.btnResize = new System.Windows.Forms.Button();
            this.btnRotate = new System.Windows.Forms.Button();
            this.btnLoadVideo = new System.Windows.Forms.Button();
            this.frameCounter = new System.Windows.Forms.NumericUpDown();
            this.btnStartVideo = new System.Windows.Forms.Button();
            this.framesLabel = new System.Windows.Forms.Label();
            this.btnBlendImages = new System.Windows.Forms.Button();
            this.btnWriteLogoToVideo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.originalPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modifiedPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(12, 12);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(114, 43);
            this.btnLoadImage.TabIndex = 0;
            this.btnLoadImage.Text = "Load image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.LoadImage_Click);
            // 
            // originalPicture
            // 
            this.originalPicture.Location = new System.Drawing.Point(134, 119);
            this.originalPicture.Name = "originalPicture";
            this.originalPicture.Size = new System.Drawing.Size(444, 354);
            this.originalPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.originalPicture.TabIndex = 1;
            this.originalPicture.TabStop = false;
            this.originalPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.originalPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.originalPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.originalPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // modifiedPicture
            // 
            this.modifiedPicture.Location = new System.Drawing.Point(584, 119);
            this.modifiedPicture.Name = "modifiedPicture";
            this.modifiedPicture.Size = new System.Drawing.Size(449, 354);
            this.modifiedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.modifiedPicture.TabIndex = 2;
            this.modifiedPicture.TabStop = false;
            // 
            // btnConvertToGrayscale
            // 
            this.btnConvertToGrayscale.Location = new System.Drawing.Point(132, 12);
            this.btnConvertToGrayscale.Name = "btnConvertToGrayscale";
            this.btnConvertToGrayscale.Size = new System.Drawing.Size(116, 42);
            this.btnConvertToGrayscale.TabIndex = 3;
            this.btnConvertToGrayscale.Text = "Convert to grayscale";
            this.btnConvertToGrayscale.UseVisualStyleBackColor = true;
            this.btnConvertToGrayscale.Click += new System.EventHandler(this.ConvertToGrayscale_Click);
            // 
            // btnGenerateHistogram
            // 
            this.btnGenerateHistogram.Location = new System.Drawing.Point(254, 12);
            this.btnGenerateHistogram.Name = "btnGenerateHistogram";
            this.btnGenerateHistogram.Size = new System.Drawing.Size(114, 42);
            this.btnGenerateHistogram.TabIndex = 4;
            this.btnGenerateHistogram.Text = "Generate histogram";
            this.btnGenerateHistogram.UseVisualStyleBackColor = true;
            this.btnGenerateHistogram.Click += new System.EventHandler(this.GenerateHistogram_Click);
            // 
            // alphaTextBox
            // 
            this.alphaTextBox.Location = new System.Drawing.Point(422, 70);
            this.alphaTextBox.Name = "alphaTextBox";
            this.alphaTextBox.Size = new System.Drawing.Size(53, 22);
            this.alphaTextBox.TabIndex = 5;
            // 
            // betaTextBox
            // 
            this.betaTextBox.Location = new System.Drawing.Point(545, 70);
            this.betaTextBox.Name = "betaTextBox";
            this.betaTextBox.Size = new System.Drawing.Size(53, 22);
            this.betaTextBox.TabIndex = 6;
            // 
            // alfaLabel
            // 
            this.alfaLabel.AutoSize = true;
            this.alfaLabel.Location = new System.Drawing.Point(386, 73);
            this.alfaLabel.Name = "alfaLabel";
            this.alfaLabel.Size = new System.Drawing.Size(30, 16);
            this.alfaLabel.TabIndex = 7;
            this.alfaLabel.Text = "Alfa";
            // 
            // betaLabel
            // 
            this.betaLabel.AutoSize = true;
            this.betaLabel.Location = new System.Drawing.Point(504, 74);
            this.betaLabel.Name = "betaLabel";
            this.betaLabel.Size = new System.Drawing.Size(35, 16);
            this.betaLabel.TabIndex = 8;
            this.betaLabel.Text = "Beta";
            // 
            // btnChangeContrast
            // 
            this.btnChangeContrast.Location = new System.Drawing.Point(374, 13);
            this.btnChangeContrast.Name = "btnChangeContrast";
            this.btnChangeContrast.Size = new System.Drawing.Size(114, 43);
            this.btnChangeContrast.TabIndex = 9;
            this.btnChangeContrast.Text = "Change contrast";
            this.btnChangeContrast.UseVisualStyleBackColor = true;
            this.btnChangeContrast.Click += new System.EventHandler(this.ChangeContrast_Click);
            // 
            // gammaTextBox
            // 
            this.gammaTextBox.Location = new System.Drawing.Point(675, 70);
            this.gammaTextBox.Name = "gammaTextBox";
            this.gammaTextBox.Size = new System.Drawing.Size(53, 22);
            this.gammaTextBox.TabIndex = 11;
            // 
            // gammaLabel
            // 
            this.gammaLabel.AutoSize = true;
            this.gammaLabel.Location = new System.Drawing.Point(614, 73);
            this.gammaLabel.Name = "gammaLabel";
            this.gammaLabel.Size = new System.Drawing.Size(55, 16);
            this.gammaLabel.TabIndex = 12;
            this.gammaLabel.Text = "Gamma";
            // 
            // btnGammaCorrection
            // 
            this.btnGammaCorrection.Location = new System.Drawing.Point(494, 14);
            this.btnGammaCorrection.Name = "btnGammaCorrection";
            this.btnGammaCorrection.Size = new System.Drawing.Size(114, 42);
            this.btnGammaCorrection.TabIndex = 13;
            this.btnGammaCorrection.Text = "Gamma correction";
            this.btnGammaCorrection.UseVisualStyleBackColor = true;
            this.btnGammaCorrection.Click += new System.EventHandler(this.GammaCorrection_Click);
            // 
            // btnResize
            // 
            this.btnResize.Location = new System.Drawing.Point(614, 14);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(114, 42);
            this.btnResize.TabIndex = 14;
            this.btnResize.Text = "Resize";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.ResizeImage_Click);
            // 
            // btnRotate
            // 
            this.btnRotate.Location = new System.Drawing.Point(734, 14);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(114, 42);
            this.btnRotate.TabIndex = 15;
            this.btnRotate.Text = "Rotate";
            this.btnRotate.UseVisualStyleBackColor = true;
            this.btnRotate.Click += new System.EventHandler(this.RotateImage_Click);
            // 
            // btnLoadVideo
            // 
            this.btnLoadVideo.Location = new System.Drawing.Point(12, 61);
            this.btnLoadVideo.Name = "btnLoadVideo";
            this.btnLoadVideo.Size = new System.Drawing.Size(114, 42);
            this.btnLoadVideo.TabIndex = 16;
            this.btnLoadVideo.Text = "Load video";
            this.btnLoadVideo.UseVisualStyleBackColor = true;
            this.btnLoadVideo.Click += new System.EventHandler(this.LoadVideo_Click);
            // 
            // frameCounter
            // 
            this.frameCounter.Location = new System.Drawing.Point(135, 507);
            this.frameCounter.Name = "frameCounter";
            this.frameCounter.Size = new System.Drawing.Size(113, 22);
            this.frameCounter.TabIndex = 17;
            // 
            // btnStartVideo
            // 
            this.btnStartVideo.Location = new System.Drawing.Point(132, 60);
            this.btnStartVideo.Name = "btnStartVideo";
            this.btnStartVideo.Size = new System.Drawing.Size(116, 43);
            this.btnStartVideo.TabIndex = 18;
            this.btnStartVideo.Text = "Start video";
            this.btnStartVideo.UseVisualStyleBackColor = true;
            this.btnStartVideo.Click += new System.EventHandler(this.StartVideo_Click);
            // 
            // framesLabel
            // 
            this.framesLabel.AutoSize = true;
            this.framesLabel.Location = new System.Drawing.Point(131, 488);
            this.framesLabel.Name = "framesLabel";
            this.framesLabel.Size = new System.Drawing.Size(53, 16);
            this.framesLabel.TabIndex = 19;
            this.framesLabel.Text = "Frames";
            // 
            // btnBlendImages
            // 
            this.btnBlendImages.Location = new System.Drawing.Point(854, 14);
            this.btnBlendImages.Name = "btnBlendImages";
            this.btnBlendImages.Size = new System.Drawing.Size(114, 41);
            this.btnBlendImages.TabIndex = 20;
            this.btnBlendImages.Text = "Blend images";
            this.btnBlendImages.UseVisualStyleBackColor = true;
            this.btnBlendImages.Click += new System.EventHandler(this.BlendImages_Click);
            // 
            // btnWriteLogoToVideo
            // 
            this.btnWriteLogoToVideo.Location = new System.Drawing.Point(254, 60);
            this.btnWriteLogoToVideo.Name = "btnWriteLogoToVideo";
            this.btnWriteLogoToVideo.Size = new System.Drawing.Size(114, 43);
            this.btnWriteLogoToVideo.TabIndex = 21;
            this.btnWriteLogoToVideo.Text = "Write to video";
            this.btnWriteLogoToVideo.UseVisualStyleBackColor = true;
            this.btnWriteLogoToVideo.Click += new System.EventHandler(this.WriteLogoToVideo_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 42);
            this.button1.TabIndex = 22;
            this.button1.Text = "Abrupt video play";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 584);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnWriteLogoToVideo);
            this.Controls.Add(this.btnBlendImages);
            this.Controls.Add(this.framesLabel);
            this.Controls.Add(this.btnStartVideo);
            this.Controls.Add(this.frameCounter);
            this.Controls.Add(this.btnLoadVideo);
            this.Controls.Add(this.btnRotate);
            this.Controls.Add(this.btnResize);
            this.Controls.Add(this.btnGammaCorrection);
            this.Controls.Add(this.gammaLabel);
            this.Controls.Add(this.gammaTextBox);
            this.Controls.Add(this.btnChangeContrast);
            this.Controls.Add(this.betaLabel);
            this.Controls.Add(this.alfaLabel);
            this.Controls.Add(this.betaTextBox);
            this.Controls.Add(this.alphaTextBox);
            this.Controls.Add(this.btnGenerateHistogram);
            this.Controls.Add(this.btnConvertToGrayscale);
            this.Controls.Add(this.modifiedPicture);
            this.Controls.Add(this.originalPicture);
            this.Controls.Add(this.btnLoadImage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.originalPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modifiedPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnConvertToGrayscale;
        private System.Windows.Forms.Button btnGenerateHistogram;
        private System.Windows.Forms.Button btnChangeContrast;
        private System.Windows.Forms.Button btnGammaCorrection;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.Button btnRotate;
        private System.Windows.Forms.Button btnLoadVideo;
        private System.Windows.Forms.Button btnStartVideo;
        private System.Windows.Forms.Button btnBlendImages;
        private System.Windows.Forms.Button btnWriteLogoToVideo;

        private System.Windows.Forms.PictureBox originalPicture;
        private System.Windows.Forms.PictureBox modifiedPicture;
        
        private System.Windows.Forms.TextBox alphaTextBox;
        private System.Windows.Forms.TextBox betaTextBox;
        private System.Windows.Forms.TextBox gammaTextBox;

        private System.Windows.Forms.Label alfaLabel;
        private System.Windows.Forms.Label betaLabel;
        private System.Windows.Forms.Label gammaLabel;
        private System.Windows.Forms.Label framesLabel;

        private System.Windows.Forms.NumericUpDown frameCounter;
        private System.Windows.Forms.Button button1;
    }
}


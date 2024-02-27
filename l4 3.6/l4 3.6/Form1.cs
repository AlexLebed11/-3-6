using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace l4_3._6
{
    public partial class Form1 : Form
    {

        private Thread loadThread;
        private Thread rotateThread;
        private Image image;

        public Form1()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    loadThread = new Thread(() => loadImage(dialog.FileName));
                    loadThread.Start();
                }
            }
        }

        private void rotateButton_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                rotateThread = new Thread(rotateImage);
                rotateThread.Start();
            }
        }

        private void loadImage(string path)
        {
            image = Image.FromFile(path);
            this.Invoke((MethodInvoker)delegate
            {
                pictureBox1.Image = image;
            });
        }

        private void rotateImage()
        {
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            this.Invoke((MethodInvoker)delegate
            {
                pictureBox1.Image = image;
            });
        }
    }
}
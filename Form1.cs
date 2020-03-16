using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CV_lab_1
{
    public partial class Form1 : Form
    {
        Bitmap m_image;

        Stack imageHistory = new Stack();
 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files|*.png;*.jpeg;*.jpg;*.bmp|All files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                m_image = new Bitmap(dialog.FileName);
                imageHistory.Clear();
                imageHistory.Push(m_image);
            }

            pictureBox1.Image = m_image;
            pictureBox1.Refresh();
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = m_image;
                pictureBox1.Refresh();
            }

            progressBar1.Value = 0;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((IFilter)e.Argument).processImage(m_image, backgroundWorker1);

            if (backgroundWorker1.CancellationPending != true)
            {
                imageHistory.Push(m_image);
                m_image = newImage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFilter filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(dialog.FileName + ".jpeg", ImageFormat.Jpeg);
            }
        }

        private void gaussianFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFilter filter = new GaussianFilter(3, 2);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFilter filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFilter filter = new Sepia(10);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void increaseBrightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFilter filter = new BrightnessFilter(50);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void increaseSharpnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFilter filter = new IncreaseSharpness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void sobelFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFilter filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(imageHistory.Count > 0)
            {
                Bitmap img = (Bitmap)imageHistory.Pop();
                m_image = img;
                pictureBox1.Image = m_image;
                pictureBox1.Refresh();
            }
        }

        private void tisnenisFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFilter filter = new TisnenieFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}

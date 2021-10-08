using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Lab1
{
    public partial class Form1 : Form
    {
        List<Bitmap> Images = new List<Bitmap>();
        Bitmap Image;
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files |*.png;*.jpg,*.bmp|All Files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK) { Image = new Bitmap(dialog.FileName); pictureBox1.Image = Image;pictureBox1.Refresh(); Images.Add(Image); }


        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            //Bitmap resultImage = filter.processImage(Image);
            //pictureBox1.Image = resultImage;
            //pictureBox1.Refresh();

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(Image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true) {
                Image = newImage;
                Images.Add(newImage);
            }
                
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled) { pictureBox1.Image = Image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { backgroundWorker1.CancelAsync(); } catch { }
            
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void gausianFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void контрастX2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new ContrastFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void собеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void sharpnessFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharpnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new TisFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }



        private void moutionBlurДопToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MoutionBlur(27);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void x2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MoutionBlur(9);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void x1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MoutionBlur(3);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкостьДопToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharpnessDop();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Png Image|*.png";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.

                this.Image.Save(fs,System.Drawing.Imaging.ImageFormat.Png);


                fs.Close();
            }
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                if (Images.Count - 1 > 0)
                {
                Images.RemoveAt(Images.Count - 1);
                Image = Images[Images.Count - 1];
                pictureBox1.Image = Images[Images.Count - 1]; ;
                pictureBox1.Refresh();
                }
            } catch { }
                
            
        }
    }
}

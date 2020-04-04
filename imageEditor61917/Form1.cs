using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using System.IO;
using System.Drawing.Imaging;

namespace imageEditor61917
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        int c = 0;
        public Form1()
        {
            InitializeComponent();
        }
        static Image file;
        Boolean opened = false;
        string name_;
        int zoomImg = 0;
        string message = "Please open the image";

        public void openImage()
        {
            var odl = new OpenFileDialog();
            DialogResult dr = odl.ShowDialog();
            if (dr == DialogResult.OK)
            {
                name_ = odl.FileName;
                file = Image.FromFile(name_);
                Bitmap bmp = new Bitmap(file);
                pictureBox1.Image = file;
                StreamWriter sw = new StreamWriter("image.txt");
                sw.WriteLine(file);
                opened = true;
            }
        }

        void saveImage()
        {
            if (opened)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Image|*;.png;*.bmp;*.jpg;";
                ImageFormat format = ImageFormat.Png;
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string ext = Path.GetExtension(sfd.FileName);
                    switch (ext)
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;

                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    pictureBox1.Image.Save(sfd.FileName, format);
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, message);
            }
        }
        void reloadImage()
        {
            if (opened)
            {
                file = Image.FromFile(name_);
                pictureBox1.Image = file;
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                opened = true;
            }
            else
            {
                MetroMessageBox.Show(this, message);
            }
        }


        Image zoomImage(Size size)
        {
            Bitmap bmp = new Bitmap(file, file.Width + (file.Width * size.Width / 100), file.Height + (file.Height * size.Height / 100));
            Graphics grp = Graphics.FromImage(bmp);
            grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bmp;
        }

        public void grayscale()
        {
            Bitmap bmp = new Bitmap(file);
            pictureBox1.Image = bmp;
            int width = bmp.Width;
            int height = bmp.Height;
            Color p;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    p = bmp.GetPixel(i, j);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    int avg = (r + g + b) / 3;
                    bmp.SetPixel(i, j, Color.FromArgb(a, avg, avg, avg));

                }
            }
            pictureBox1.Image = bmp;


        }

        public void sepia()
        {
            Bitmap bmp = new Bitmap(file);
            pictureBox1.Image = bmp;
            int width = bmp.Width;
            int heigth = bmp.Height;
            Color p;
            for (int y = 0; y < heigth; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = bmp.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //calculate temp value
                    int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                    int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                    //set new RGB value
                    if (tr > 255)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = tr;
                    }

                    if (tg > 255)
                    {
                        g = 255;
                    }
                    else
                    {
                        g = tg;
                    }

                    if (tb > 255)
                    {
                        b = 255;
                    }
                    else
                    {
                        b = tb;
                    }

                    //set the new RGB value in image pixel
                    bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox1.Image = bmp;
        }

        public void polarido()
        {
            Bitmap bmp = new Bitmap(file);
            pictureBox1.Image = bmp;
            int width = bmp.Width;
            int heigth = bmp.Height;
            Color p;
            for (int y = 0; y < heigth; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = bmp.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //calculate temp value
                    int tr = (int)(0.1500 * r + 03225 * g + 0.772 * b);
                    int tg = (int)(0.882 * r + 0.533 * g + 0.882 * b);
                    int tb = (int)(0.1250 * r + 0.883 * g + 0.931 * b);

                    //set new RGB value
                    if (tr > 255)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = tr;
                    }

                    if (tg > 255)
                    {
                        g = 255;
                    }
                    else
                    {
                        g = tg;
                    }

                    if (tb > 255)
                    {
                        b = 255;
                    }
                    else
                    {
                        b = tb;
                    }

                    //set the new RGB value in image pixel
                    bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
        }

        public void frozen()
        {
            Bitmap bmp = new Bitmap(file);
            pictureBox1.Image = bmp;
            int width = bmp.Width;
            int heigth = bmp.Height;
            Color p;
            for (int y = 0; y < heigth; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = bmp.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //calculate temp value
                    int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    int tg = (int)(0.25 * r + 0.25 * g + 0.25 * b);
                    int tb = (int)(0.78 * r + 0.78 * g + 0.78 * b);

                    //set new RGB value
                    if (tr > 255)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = tr;
                    }

                    if (tg > 255)
                    {
                        g = 255;
                    }
                    else
                    {
                        g = tg;
                    }

                    if (tb > 255)
                    {
                        b = 255;
                    }
                    else
                    {
                        b = tb;
                    }

                    //set the new RGB value in image pixel
                    bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
        }

        public void dramatic()
        {
            Bitmap bmp = new Bitmap(file);
            pictureBox1.Image = bmp;
            int width = bmp.Width;
            int heigth = bmp.Height;
            Color p;
            for (int y = 0; y < heigth; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = bmp.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //calculate temp value
                    int tr = (int)(0.78 * r + 0.68 * g + 1.78 * b);
                    int tg = (int)(0.25 * r + 0.25 * g + 1.78 * b);
                    int tb = (int)(0.78 * r + 0.78 * g + 1.78 * b);

                    //set new RGB value
                    if (tr > 255)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = tr;
                    }

                    if (tg > 255)
                    {
                        g = 255;
                    }
                    else
                    {
                        g = tg;
                    }

                    if (tb > 255)
                    {
                        b = 255;
                    }
                    else
                    {
                        b = tb;
                    }

                    //set the new RGB value in image pixel
                    bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox1.Image = bmp;
        }

        public void flash()
        {
            Bitmap bmp = new Bitmap(file);
            pictureBox1.Image = bmp;
            int width = bmp.Width;
            int heigth = bmp.Height;
            Color p;
            for (int y = 0; y < heigth; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = bmp.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //calculate temp value
                    int tr = (int)(1.588 * r + 0.333 * g + 1.100 * b);
                    int tg = (int)(1.599 * r + 1.000 * g + 0.988 * b);
                    int tb = (int)(2.555 * r + 1.555 * g + 0.999 * b);

                    //set new RGB value
                    if (tr > 255)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = tr;
                    }

                    if (tg > 255)
                    {
                        g = 255;
                    }
                    else
                    {
                        g = tg;
                    }

                    if (tb > 255)
                    {
                        b = 255;
                    }
                    else
                    {
                        b = tb;
                    }

                    //set the new RGB value in image pixel
                    bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox1.Image = bmp;

        }


        public void mirrorImage()
        {
            Bitmap bmp = new Bitmap(file);
            pictureBox1.Image = bmp;
            int width = bmp.Width;
            int heigth = bmp.Height;
            Bitmap bmp2 = new Bitmap(width * 2, heigth);
            Color p;
            for (int x = 0; x < heigth; x++)
            {
                for (int lx = 0, rx = 2 * width - 1; lx < width; lx++, rx--)
                {
                    p = bmp.GetPixel(lx, x);
                    bmp2.SetPixel(lx, x, p);
                    bmp2.SetPixel(rx, x, p);
                }
            }
            pictureBox1.Image = bmp2;
        }
        //  int a = 0;

        public void red()
        {
            Bitmap bmp = new Bitmap(file);
            pictureBox1.Image = bmp;
            int width = bmp.Width;
            int heigth = bmp.Height;
            Color p;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < heigth; j++)
                {
                    p = bmp.GetPixel(i, j);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    if (r < 255 && b > 0 && g > 0)
                    {


                        bmp.SetPixel(i, j, Color.FromArgb(a, r + 1, g - 1, b - 1));
                    }

                }
            }
            pictureBox1.Image = bmp;

        }

        public void green()
        {
            Bitmap bmp = new Bitmap(file);
            pictureBox1.Image = bmp;
            int width = bmp.Width;
            int heigth = bmp.Height;
            Color p;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < heigth; j++)
                {
                    p = bmp.GetPixel(i, j);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    bmp.SetPixel(i, j, Color.FromArgb(a, 0, g, 0));

                }
            }
            pictureBox1.Image = bmp;

        }
        public void blue()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            //pictureBox1.Image = bmp;
            int width = bmp.Width;
            int heigth = bmp.Height;
            Color p;
            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    p = bmp.GetPixel(j, i);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    if (r > 15 && g > 15)
                    {
                        bmp.SetPixel(j, i, Color.FromArgb(a, r - 15, g - 15, b));
                    }
                    else if (r == 0 && g > 15)
                    {
                        bmp.SetPixel(j, i, Color.FromArgb(a, 0, g - 15, b));
                    }
                    else if (r > 15 && g == 0)
                    {
                        bmp.SetPixel(j, i, Color.FromArgb(a, r - 15, 0, b));
                    }
                    else
                    {
                        bmp.SetPixel(j, i, Color.FromArgb(a, 0, 0, b));
                    }

                }
            }
            pictureBox1.Image = bmp;

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            openImage();
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            saveImage();
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            if (opened)
            {
                pictureBox1.Image = null;
            }
            else
            {
                MetroMessageBox.Show(this, message);
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (opened)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                opened = true;
            }
            else
            {
                MetroMessageBox.Show(this, message);
            }
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            string msg = "Do you want To Exist";
            DialogResult dl = MetroFramework.MetroMessageBox.Show(this, msg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Error, 150);
            if (dl==DialogResult.Yes)
            {
                Application.Exit();                
            }
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            reloadImage();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (opened)
            {
                if (zoomImg <= 50)
                {
                    zoomImg = zoomImg + 10;
                    if (opened)
                    {
                        if (file == null)
                        {
                            file = pictureBox1.Image;
                        }
                        pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                        pictureBox1.Image = zoomImage(new Size(zoomImg, zoomImg));
                    }
                }
            }
            else
            {
                MetroMessageBox.Show(this, message);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (opened)
            {
                if (zoomImg <= 50)
                {
                    zoomImg = zoomImg - 10;
                    if (opened)
                    {
                        if (file == null)
                        {
                            file = pictureBox1.Image;
                        }
                        pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                        pictureBox1.Image = zoomImage(new Size(zoomImg, zoomImg));
                    }
                }
            }
            else
            {
                MetroMessageBox.Show(this, message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            grayscale();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            sepia();
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            mirrorImage();
        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void metroTrackBar3_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            metroPanel4.Visible = true;
        }

        private void metroTrackBar3_MouseClick(object sender, MouseEventArgs e)
        {
            red();
        }

        private void metroPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            metroPanel6.Visible = true;
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            metroPanel5.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            polarido();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            frozen();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dramatic();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            flash();
        }

        private void metroTrackBar5_Scroll(object sender, ScrollEventArgs e)
        {
            // metroTrackBar5.Value++;
            timer1.Start();
            blue();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            // blue();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            c++;
            if (c == 1)
            {
                blue();
                timer1.Stop();
                c = 0;

            }
            if (c == 2)
            {
                green();
                timer1.Stop();
                c = 0;

            }
            if (c == 3)
            {
                green();
                timer1.Stop();
                c = 0;

            }

        }

        private void metroTrackBar4_Scroll(object sender, ScrollEventArgs e)
        {
            timer1.Start();
            green();
        }
    }
}

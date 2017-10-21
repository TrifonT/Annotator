using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Annotator
{
    public partial class MainForm : Form
    {
        private List<string> _extentions;
        private List<string> _files;
        private int _currenIndex = -1;

        private double _xratio;
        private double _yratio;
        private double _xoffset;
        private double _yoffset;

        public MainForm()
        {
            _extentions = GetImageFileExtensions();
            InitializeComponent();
            this.DataBindings.Add(new System.Windows.Forms.Binding("Size", global::Annotator.Properties.Settings.Default, "FormSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Size = Properties.Settings.Default.FormSize;
            LoadFileList();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        public string ImageFolder
        {
            get { return txtImageFolder.Text; }
            set { txtImageFolder.Text = value; }
        }

        public int CurrenIndex
        {
            get
            {
                return _currenIndex;
            }

            set
            {
                if (value != _currenIndex)
                {
                    _currenIndex = value;
                    LoadFile(_currenIndex);
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                txtImageFolder.Text = FBD.SelectedPath;
            }
        }

        private void LoadFile(int index)
        {
            string fullPath = System.IO.Path.Combine(ImageFolder, _files[index]);
            if (System.IO.File.Exists(fullPath))
            {
                ShowImage(Image.FromFile(fullPath));
            }
        }

        private void LoadFileList()
        {
            if (_files == null)
                _files = new List<string>();

            _files.Clear();

            if (System.IO.Directory.Exists(ImageFolder))
            {
                string[] f = System.IO.Directory.GetFiles(ImageFolder);

                foreach (string file in f)
                {
                    string ext = Path.GetExtension(file).ToLowerInvariant();

                    if (_extentions.Contains(ext))
                    {
                        _files.Add(file);
                    }
                }
                _files.Sort();
                CurrenIndex = 0;
            }
        }

        private static List<string> GetImageFileExtensions()
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();

            List<string> extensions = new List<string>();

            foreach (var enc in encoders)
            {
                extensions.AddRange(enc.FilenameExtension.ToLowerInvariant().Replace("*", "").Split(';'));
            }
            return extensions;
        }

        private void ShowImage(Image image)
        {
            int maxWidth = picBox.Width;
            int maxHeight = picBox.Height;
            picBox.Image = new Bitmap(maxWidth, maxHeight);

            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            _xratio = (double)newWidth / image.Width;
            _yratio = (double)newHeight / image.Height;

            _xoffset = (maxWidth - newWidth) / 2;
            _yoffset = (maxHeight - newHeight) / 2;

            int x = Convert.ToInt32(_xoffset);
            int y = Convert.ToInt32(_yoffset);

            Rectangle r = new Rectangle(x, y, newWidth, newHeight);

            if (_drawImage != null)
                _drawImage.Dispose();

            _drawImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(_drawImage))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, r);
            }

            double fx = Convert.ToDouble(picBox.Width) / Convert.ToDouble(image.Width);
            double fy = Convert.ToDouble(picBox.Height) / Convert.ToDouble(image.Height);
            double f = Math.Min(fx, fy);

            int nw = Convert.ToInt32(image.Width * f);
            int nh = Convert.ToInt32(image.Height * f);

            picBox.Refresh();
        }

        private Image _drawImage;

        private void picBox_Paint(object sender, PaintEventArgs e)
        {
            if (_drawImage != null)
            {
                e.Graphics.DrawImage(_drawImage, new Point(0, 0));
            }
        }

        private void picBox_Resize(object sender, EventArgs e)
        {
            if (_currenIndex >= 0)
                LoadFile(_currenIndex);
        }
    }
}
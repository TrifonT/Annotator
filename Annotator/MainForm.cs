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

        private Image _drawnImage;
        private Image _loadedImage;

        private double _xratio;
        private double _yratio;
        private int _xoffset;
        private int _yoffset;

        public MainForm()
        {
            _extentions = GetImageFileExtensions();
            InitializeComponent();
            //this.DataBindings.Add(new System.Windows.Forms.Binding("Size", global::Annotator.Properties.Settings.Default, "FormSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            //picBox.Image = new Bitmap(2000, 2000);
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
                _loadedImage = Image.FromFile(fullPath);
                ShowLoadedImage();
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

        private void ShowLoadedImage()
        {
            int maxWidth = picBox.Width;
            int maxHeight = picBox.Height;

            double ratioX = (double)maxWidth / _loadedImage.Width;
            double ratioY = (double)maxHeight / _loadedImage.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = Convert.ToInt32(_loadedImage.Width * ratio);
            int newHeight = Convert.ToInt32(_loadedImage.Height * ratio);

            _xratio = (double)newWidth / _loadedImage.Width;
            _yratio = (double)newHeight / _loadedImage.Height;

            _xoffset = (maxWidth - newWidth) / 2;
            _yoffset = (maxHeight - newHeight) / 2;

            int x = Convert.ToInt32(_xoffset);
            int y = Convert.ToInt32(_yoffset);

            Rectangle r = new Rectangle(x, y, newWidth, newHeight);

            if (_drawnImage != null)
            {
                if (_drawnImage.Width != newWidth || _drawnImage.Height != newHeight)
                {
                    _drawnImage.Dispose();
                    _drawnImage = new Bitmap(newWidth, newHeight);
                }
            }
            else
            {
                _drawnImage = new Bitmap(newWidth, newHeight);
            }

            using (var graphics = Graphics.FromImage(_drawnImage))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(_loadedImage, 0, 0, newWidth, newHeight);
            }

            picBox.Refresh();
        }

        private void picBox_Paint(object sender, PaintEventArgs e)
        {
            if (_drawnImage != null)
            {
                e.Graphics.DrawImage(_drawnImage, new Point(_xoffset, _yoffset));
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CurrenIndex < _files.Count - 1)
                CurrenIndex++;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (CurrenIndex > 0)
                CurrenIndex--;
        }

        private void picBox_Resize(object sender, EventArgs e)
        {
            ShowLoadedImage();
        }
    }
}
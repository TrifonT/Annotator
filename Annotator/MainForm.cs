using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Annotator
{
    public partial class MainForm : Form
    {
        private List<string> _extentions;
        private List<string> _files;
        private int _currenIndex = -1;

        private AnnotationList _annList;
        private List<RectangleF> _currentRectangles;

        private Image _drawnImage;
        private Image _loadedImage;

        private float _ratio;
        private float _xoffset;
        private float _yoffset;

        public MainForm()
        {
            _extentions = GetImageFileExtensions();
            InitializeComponent();
            LoadFileList();
            LoadAnnotations();
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
                        _files.Add(Path.GetFileName(file));
                    }
                }
                _files.Sort();
                CurrenIndex = 0;
            }
        }

        private void LoadAnnotations()
        {
            if (Directory.Exists(Properties.Settings.Default.ImageFolder))
            {
                string annXml = Path.Combine(Properties.Settings.Default.ImageFolder, "Annotations.xml");
                if (File.Exists(annXml))
                {
                    _annList = AnnotationList.FromFile(annXml);
                }
                else
                {
                    _annList = new AnnotationList();
                }
                foreach (string file in _files)
                {
                    if (!_annList.ContainsKey(file))
                    {
                        _annList.Add(file);
                    }
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Directory.Exists(ImageFolder))
            {
                if (_annList == null)
                    _annList = new AnnotationList();
                _annList.Save(Path.Combine(ImageFolder, "Annotations.xml"));
            }
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
                    LoadRectangles(_currenIndex);
                    LoadFile(_currenIndex);
                }
            }
        }

        private void SaveRectangles(int index)
        {
            if (_files != null && index >= 0 && index < _files.Count)
            {
                string file = _files[index];
                _annList.CheckInRectangles(file, _currentRectangles, _xoffset, _yoffset, _ratio);
            }
        }

        private void LoadRectangles(int index)
        {
            if (_files != null && index >= 0 && index < _files.Count)
            {
                string file = _files[index];
                _currentRectangles = _annList.CheckoutRectangles(file, _xoffset, _yoffset, _ratio);
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

            float ratioX = ((float)maxWidth) / ((float)_loadedImage.Width);
            float ratioY = ((float)maxHeight) / ((float)_loadedImage.Height);
            _ratio = Math.Min(ratioX, ratioY);

            int newWidth = Convert.ToInt32(_loadedImage.Width * _ratio);
            int newHeight = Convert.ToInt32(_loadedImage.Height * _ratio);

            _xoffset = ((float)(maxWidth - newWidth)) / 2.0f;
            _yoffset = ((float)(maxHeight - newHeight)) / 2.0f;

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
                e.Graphics.DrawImage(_drawnImage, new PointF(_xoffset, _yoffset));
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
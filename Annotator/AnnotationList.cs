using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Drawing;

namespace Annotator
{
    public class AnnotationEntry
    {
        public string File { get; set; }
        public List<RectangleF> Rectangles { get; set; }
    }

    public class AnnotationList : Dictionary<string, List<RectangleF>>
    {
        public void Add(string file)
        {
            if (!this.ContainsKey(file))
            {
                this[file] = new List<RectangleF>();
            }
        }

        public void Add(string file, Rectangle rect)
        {
            if (!this.ContainsKey(file))
            {
                this[file] = new List<RectangleF>();
            }
            this[file].Add(rect);
        }

        public void Save(TextWriter tw)
        {
            XmlSerializer xs = new XmlSerializer(typeof(AnnotationEntry[]), new XmlRootAttribute() { ElementName = "Entries" });
            xs.Serialize(tw, this.Select(i => new AnnotationEntry() { File = i.Key, Rectangles = i.Value }).ToArray());
        }

        public void Save(string fileName)
        {
            TextWriter tw = new StreamWriter(fileName);
            Save(tw);
            tw.Close();
        }

        public static AnnotationList FromFile(string fileName)
        {
            TextReader tr = new StreamReader(fileName);
            XmlSerializer xs = new XmlSerializer(typeof(AnnotationEntry[]), new XmlRootAttribute() { ElementName = "Entries" });

            AnnotationEntry[] aentry = (AnnotationEntry[])xs.Deserialize(tr);
            tr.Close();

            AnnotationList result = new AnnotationList();
            foreach (AnnotationEntry en in aentry)
            {
                result.Add(en.File, en.Rectangles);
            }

            return result;
        }

        public RectangleF Transform(RectangleF rect, float xOffset, float yOffset, float ratio)
        {
            float x = rect.X * ratio + xOffset;
            float y = rect.Y * ratio + yOffset;
            float w = rect.Width * ratio;
            float h = rect.Height * ratio;
            return new RectangleF(x, y, w, h);
        }

        public RectangleF UnTransform(RectangleF rect, float xOffset, float yOffset, float ratio)
        {
            float x = (rect.X - xOffset) / ratio;
            float y = (rect.Y - yOffset) / ratio;
            float w = rect.Width / ratio;
            float h = rect.Height / ratio;
            return new RectangleF(x, y, w, h);
        }

        public List<RectangleF> CheckoutRectangles(string file, float xOffset, float yOffset, float ratio)
        {
            List<RectangleF> transformed = new List<RectangleF>();

            if (!this.ContainsKey(file))
            {
                this[file] = new List<RectangleF>();
            }

            foreach (RectangleF r in this[file])
            {
                transformed.Add(Transform(r, xOffset, yOffset, ratio));
            }
            return transformed;
        }

        public void CheckInRectangles(string file, List<RectangleF> rectangles, float xOffset, float yOffset, float ratio)
        {
            List<RectangleF> untransformed = new List<RectangleF>();

            foreach (RectangleF r in rectangles)
            {
                untransformed.Add(UnTransform(r, xOffset, yOffset, ratio));
            }

            this[file] = untransformed;
        }
    }
}
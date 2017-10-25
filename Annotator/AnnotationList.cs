using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Annotator
{
    public class AnnotationEntry
    {
        public string File { get; set; }
        public List<BRectangle> Rectangles { get; set; }
    }

    public class AnnotationList : Dictionary<string, List<BRectangle>>
    {
        public void Add(string file)
        {
            if (!this.ContainsKey(file))
            {
                this[file] = new List<BRectangle>();
            }
        }

        public void Add(string file, BRectangle rect)
        {
            if (!this.ContainsKey(file))
            {
                this[file] = new List<BRectangle>();
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

        public BRectangle Transform(BRectangle rect, float xOffset, float yOffset, float ratio)
        {
            float x = rect.X * ratio + xOffset;
            float y = rect.Y * ratio + yOffset;
            float w = rect.Width * ratio;
            float h = rect.Height * ratio;
            return new BRectangle(x, y, w, h);
        }

        public BRectangle UnTransform(BRectangle rect, float xOffset, float yOffset, float ratio)
        {
            float x = (rect.X - xOffset) / ratio;
            float y = (rect.Y - yOffset) / ratio;
            float w = rect.Width / ratio;
            float h = rect.Height / ratio;
            return new BRectangle(x, y, w, h);
        }

        public List<BRectangle> CheckoutRectangles(string file, float xOffset, float yOffset, float ratio)
        {
            List<BRectangle> transformed = new List<BRectangle>();

            if (!this.ContainsKey(file))
            {
                this[file] = new List<BRectangle>();
            }

            foreach (BRectangle r in this[file])
            {
                transformed.Add(Transform(r, xOffset, yOffset, ratio));
            }
            return transformed;
        }

        public void CheckInRectangles(string file, List<BRectangle> rectangles, float xOffset, float yOffset, float ratio)
        {
            if (rectangles != null)
            {
                List<BRectangle> untransformed = new List<BRectangle>();
                foreach (BRectangle r in rectangles)
                {
                    untransformed.Add(UnTransform(r, xOffset, yOffset, ratio));
                }
                this[file] = untransformed;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Annotator
{
    public class AnnotationList : Dictionary<string, AnnotationEntry>
    {
        public void Add(AnnotationEntry entry)
        {
            Add(entry.File, entry);
        }

        public void Save(TextWriter tw)
        {
            XmlSerializer xs = new XmlSerializer(typeof(AnnotationEntry[]), new XmlRootAttribute() { ElementName = "Entries" });
            xs.Serialize(tw, this.Select(i => new AnnotationEntry() { File = i.Key, Rectangles = i.Value.Rectangles }).ToArray());
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
                result.Add(en.File, en);
            }

            return result;
        }
    }
}
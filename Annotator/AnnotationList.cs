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
        public void Save(TextWriter tw)
        {
            XmlSerializer xs = new XmlSerializer(typeof(AnnotationList));
            xs.Serialize(tw, this);
        }

        public void Save(string fileName)
        {
            TextWriter tw = new StreamWriter(fileName);
            Save(tw);
            tw.Close();
        }

        public AnnotationList FromFile(string fileName)
        {
            TextReader tr = new StreamReader(fileName);
            XmlSerializer xs = new XmlSerializer(typeof(AnnotationList));
            AnnotationList alst = (AnnotationList)xs.Deserialize(tr);
            tr.Close();
            return alst;
        }
    }
}
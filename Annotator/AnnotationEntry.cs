using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Annotator
{
    public class AnnotationEntry
    {
        public AnnotationEntry()
        {
            Rectangles = new List<Rectangle>();
        }

        public string File { get; set; }
        public List<Rectangle> Rectangles { get; set; }
    }
}
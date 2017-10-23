using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Annotator
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //AnnotationList lst = new AnnotationList();
            //Rectangle r1 = new Rectangle(0, 0, 100, 200);
            //Rectangle r2 = new Rectangle(10, 10, 200, 300);
            //lst.Add("file1", r1);
            //lst.Add("file1", r2);

            //lst.Save("Annotations.xml");

            //lst = AnnotationList.FromFile("Annotations.xml");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
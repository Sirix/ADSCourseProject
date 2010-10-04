using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Glee.Drawing;
using Timer = System.Timers.Timer;

namespace ADSCourseProject
{
    public static class RichTextBoxHelper
    {
        public static void AppendFormat(this RichTextBox rtb, string format, params object[] param)
        {
            rtb.AppendText(string.Format(format, param));
        }
    }
    public static class NodeHelper
    {
        public static void Blink(this Node n, Color c)
        {
            var o = n.Attr.Fillcolor;
            n.Attr.Fillcolor = c;
            Timer t = new Timer(500) {Enabled = true};
            t.Elapsed += (v1, v2) => { n.Attr.Fillcolor = o; };
            t.Start();
        }
    }
}

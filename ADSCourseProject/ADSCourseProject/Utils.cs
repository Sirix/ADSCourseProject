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
        /// <summary>
        /// Append text line to RichTextBox control
        /// </summary>
        /// <param name="rtb"></param>
        /// <param name="text">Text line</param>
        public static void AppendLine(this RichTextBox rtb, string text)
        {
            rtb.AppendText(text);
            rtb.AppendText("\n");
        }

        /// <summary>
        /// Append formatted text line to RichTextBox control
        /// </summary>
        /// <param name="rtb"></param>
        /// <param name="format">Format string</param>
        /// <param name="param">Format string parameters</param>
        public static void AppendFormatLine(this RichTextBox rtb, string format, params object[] param)
        {
            rtb.AppendText(string.Format(format, param));
            rtb.AppendText("\n");
        }

        /// <summary>
        /// Append color text line to RichTextBox control
        /// </summary>
        /// <param name="rtb"></param>
        /// <param name="text">Text line</param>
        /// <param name="c">Text Color</param>
        public static void AppendColorText(this RichTextBox rtb, string text, System.Drawing.Color c)
        {
            int s = rtb.Text.Length;
            int l = text.Length;
            rtb.AppendLine(text);
            rtb.Select(s, l);
            rtb.SelectionColor = c;
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

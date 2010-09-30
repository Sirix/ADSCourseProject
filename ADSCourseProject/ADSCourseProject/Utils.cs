using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADSCourseProject
{
    public static class RichTextBoxHelper
    {
        public static void AppendFormat(this RichTextBox rtb, string format, params object[] param)
        {
            rtb.AppendText(string.Format(format, param));
        }
    }
}

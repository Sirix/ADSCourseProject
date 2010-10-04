using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

namespace ADSCourseProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //try
           // {
                Application.Run(new MainForm());
           // }
          //  catch (TargetInvocationException ex)
          //  {
          //      throw ex.InnerException;
          //  }
        }
    }
}

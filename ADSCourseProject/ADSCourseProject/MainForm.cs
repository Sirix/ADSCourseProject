using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Glee.Drawing;
using ADSCourseProject.Log;

namespace ADSCourseProject
{
    public partial class MainForm : Form
    {
        private Observer o;

        public MainForm()
        {
            InitializeComponent();

            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);

            btnDrawGraph_Click(null, null);
           // button1_Click(null, null);
        }

        private void btnDrawGraph_Click(object sender, EventArgs e)
        {
            o = new Observer(new ObserverParameters
            {
                ComputersCount = (int)nComputersCount.Value,
                TimeInterval = 1 * 500
            });

          
            Graph g = new Graph("graph");
            foreach (var c in o.Channels)
            {
                Edge ed = g.AddEdge(c.A.ToString(), c.MaxLoad.ToString(), c.B.ToString());
                ed.Attr.ArrowHeadAtTarget = ArrowStyle.None;
            }
            gViewer.Graph = g;

        }    
        object selectedObjectAttr;
        object selectedObject;
        void gViewer_SelectionChanged(object sender, EventArgs e)
        {

            if (selectedObject != null)
            {
                if (selectedObject is Edge)
                    (selectedObject as Edge).Attr = selectedObjectAttr as EdgeAttr;
                else if (selectedObject is Node)
                    (selectedObject as Node).Attr = selectedObjectAttr as NodeAttr;

                selectedObject = null;
            }

            if (gViewer.SelectedObject == null)
            {
               // label1.Text = "No object under the mouse";
                //this.gViewer.SetToolTip(toolTip1, "");

            }
            else
            {
                selectedObject = gViewer.SelectedObject;
                
                if (selectedObject is Edge)
                {
                    selectedObjectAttr = (gViewer.SelectedObject as Edge).Attr.Clone();
                    (gViewer.SelectedObject as Edge).Attr.Color = Microsoft.Glee.Drawing.Color.Magenta;
                    (gViewer.SelectedObject as Edge).Attr.Fontcolor = Microsoft.Glee.Drawing.Color.Magenta;
                   // Edge edge = gViewer.SelectedObject as Edge;

                    //here you can use e.Attr.Id or e.UserData to get back to you data
                   //this.gViewer.SetToolTip(this.toolTip1, String.Format("edge from {0} {1}", edge.Source, edge.Target));

                }
                else if (selectedObject is Node)
                {

                    selectedObjectAttr = (gViewer.SelectedObject as Node).Attr.Clone();
                    (selectedObject as Node).Attr.Fillcolor = Microsoft.Glee.Drawing.Color.Magenta;
                    (selectedObject as Node).Attr.Color = Microsoft.Glee.Drawing.Color.Magenta;
                    (selectedObject as Node).Attr.Fontcolor = Microsoft.Glee.Drawing.Color.Magenta;
                    //here you can use e.Attr.Id to get back to your data
                 //   this.gViewer.SetToolTip(toolTip1, String.Format("node {0}", (selectedObject as Node).Attr.Label));
                }
               // label1.Text = selectedObject.ToString();
            }
            gViewer.Invalidate();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            o.Cancelling = false;
            //start background thread
            backgroundWorker.RunWorkerAsync();

            btnRun.Enabled = false;
            btnStop.Enabled = true;
        }
        private int lastGener = 0;
        //main UI update method
        void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //thread concurrence error protection
            object locker = new object();
            LogEntry[] le;
            lock(locker)
            {
                le = new LogEntry[Logger.Instance.Records.Count];
                Logger.Instance.Records.CopyTo(le, 0);
            }
            //end protection

            foreach (var r in le.Where(er => er.Tick == lastGener))
            {
                System.Drawing.Color color = tbLog.ForeColor;
                if (r.LogType == LogType.DataSended)
                    color = System.Drawing.Color.Green;

                if (r.LogType == LogType.PacketSended)
                    color = System.Drawing.Color.Khaki;

                tbLog.AppendColorText(r.Message, color);
            }
            tbLog.AppendText("\n");
            lastGener++;
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }


        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!o.Cancelling)
            {
                if (backgroundWorker.CancellationPending)
                {
                    o.Cancelling = true;
                    e.Cancel = true;
                }
                else
                {
                    var s = o.Tick();
                    backgroundWorker.ReportProgress(1, s);
                    e.Cancel = false;
                }
            }
            e.Cancel = true;
        }

        //TODO: Move cancelAsync call to one method(e.g.WPF command)
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundWorker.CancelAsync();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            o.Cancelling = true;
            backgroundWorker.CancelAsync();

            btnRun.Enabled = true;
            btnStop.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            WorkingBranch.Init();
            WorkingBranch.FindShortWay(1, 4, 5,
                WorkingBranch.Power, WorkingBranch.Way);
            string s = "";
            WorkingBranch.ShortWay.ForEach(i => s += i + " ");
            MessageBox.Show(s);
        }
    }
}

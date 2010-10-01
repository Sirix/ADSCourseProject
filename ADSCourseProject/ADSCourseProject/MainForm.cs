using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Glee.Drawing;

namespace ADSCourseProject
{
    public partial class MainForm : Form
    {
        private Observer o;

        public MainForm()
        {
            InitializeComponent();

            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);

            btnDrawGraph_Click(null, null);
        }

        private int[,] peaks;
        private void btnDrawGraph_Click(object sender, EventArgs e)
        {
            int cc = (int) nComputersCount.Value;
            //int connections = (int) nConnectsCount.Value;
            int connections = cc*2;
            //if(connections>

            peaks = new int[cc,cc];

            for (int i = 0; i < cc; i++)
                for (int j = 0; j < cc; j++)
                    peaks[i, j] = -1;

            Random r = new Random();
            
            int get = 0;
            while (get < connections)
            {
                int s = r.Next(0, cc);
                int t = r.Next(0, cc);
                int v = r.Next(0, 100);

                //no self-to-self connections
                if (s == t) continue;

                if (peaks[s, t] == -1 && peaks[t, s] == -1)
                {
                    /*int c = 0, z = 0;
                    for (int i = 0; i < cc; i++)
                    {
                        if (peaks[s, i] != -1 || peaks[i, s] != -1) c++;
                        if (peaks[t, i] != -1 || peaks[i, t] != -1) z++;
                    }
                    if (c > connections || z > connections) continue;
                    */
                    peaks[s, t] = v;
                    peaks[t, s] = v;
                    get++;
                }
            }

            //save peak info to new data array.
            //we'll mark items as draw them
            int[,] temp = new int[cc,cc];
                Array.Copy(peaks, temp, peaks.Length);
            Graph g = new Graph("graph");
            for (int i = 0; i < cc; i++)
                for (int j = 0; j < cc; j++)
                {
                    //if edge exist and we not draw it and not draw back link
                    if (peaks[i, j] != -1 && temp[i, j] != -1 && temp[j, i] != -1)
                    {
                        g.AddEdge(i.ToString(), peaks[i, j].ToString(), j.ToString());
                        temp[i, j] = -1;
                        temp[j, i] = -1;
                    }
                    //if (peaks[i, j] != -1 && (g.EdgeById(i.ToString() + j.ToString()) == null && g.EdgeById(j.ToString() + i.ToString()) == null))
                        
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
            //initialize observer
            o = new Observer(new ObserverParameters
                                 {
                                     ComputersCount = (int) nComputersCount.Value,
                                     TimeInterval = 1*1000,
                                     Graph = peaks
                                 });

            
            
            this.backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);

            //start background thread
            backgroundWorker.RunWorkerAsync();
            btnRun.Enabled = false;
        }

        //main UI update method
        void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //BUG: Lambda expression here can crush application on exit
            o.Packets.ForEach(delegate(Packet p)
            {
                var s =
                    gViewer.Graph.Edges.FirstOrDefault(
                        ed =>
                        ed.Source == p.Sender.ToString() &&
                        ed.Target == p.Receiver.ToString());

                if (s != null)
                    s.EdgeAttr.Label = p.Size.ToString();
                /*
                if (s != null)
                {
                    //gViewer.Graph.Edges.Remove(s);
                    gViewer.Graph.Edges.Add(s);
                }*/
                tbLog.AppendText(p.ToString());
            });
            tbLog.AppendFormat("\r\n Updated \r\n");
            this.gViewer.Invalidate();
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
                    var s = o.Tick(e.Argument);
                    backgroundWorker.ReportProgress(1, s);
                    e.Cancel = false;
                }
            }
            e.Cancel = true;
        }

        void o_ObserverStateChanged(NetStateArgs e)
        {
            if (!backgroundWorker.CancellationPending)
                this.backgroundWorker.ReportProgress(0, e);
        }

        //TODO: Move cancelAsync call to one method(e.g.WPF command)
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundWorker.CancelAsync();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            o.Cancelling = !o.Cancelling;

            //o.Cancelling = !o.Cancelling;
         //   backgroundWorker.CancelAsync();

           ///// btnRun_Click(sender, e);
        }
    }
}

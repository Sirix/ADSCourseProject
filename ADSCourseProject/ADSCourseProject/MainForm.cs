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
        public MainForm()
        {
            InitializeComponent();

            Graph g = new Graph("graph");
            g.GraphAttr.NodeAttr.Padding = 3;

            g.AddEdge("S35", "36");
            g.AddEdge("S35", "43");
            g.AddEdge("43", "43");
            g.AddEdge("36", "43");

            gViewer.Graph = g;
        }

        private void btnDrawGraph_Click(object sender, EventArgs e)
        {
            int cc = (int) nComputersCount.Value;
            int connections = cc*(int) nConnectsCount.Value;

            int[,] peaks = new int[cc,cc];

            for (int i = 0; i < cc; i++)
                for (int j = 0; j < cc; j++)
                    peaks[i, j] = -1;

            Random r = new Random();
            
            int get = 0;
            while (get <= connections)
            {
                int s = r.Next(0, cc);
                int t = r.Next(0, cc);
                int v = r.Next(0, 100);

                if (s == t) continue;

                if (peaks[s, t] == -1)
                {
                    int c = 0, z = 0;
                    for (int i = 0; i < cc; i++)
                    {
                        if (peaks[s, i] != -1 || peaks[i, s] != -1) c++;
                        if (peaks[t, i] != -1 || peaks[i, t] != -1) z++;
                        ;
                    }
                    if (c > connections - 1 || z > connections - 1) continue;

                    peaks[s, t] = v;
                   // peaks[t, s] = v;
                    get++;
                }
            }
        


            Graph g = new Graph("graph");
            for (int i = 0; i < cc; i++)
                for (int j = 0; j < cc; j++)
                    if (peaks[i, j] != -1)
                        g.AddEdge(i.ToString(), j.ToString());

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
    }
}

namespace ADSCourseProject
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gViewer = new Microsoft.Glee.GraphViewerGdi.GViewer();
            this.nComputersCount = new System.Windows.Forms.NumericUpDown();
            this.lblComputersCount = new System.Windows.Forms.Label();
            this.lblConnectsCount = new System.Windows.Forms.Label();
            this.nConnectsCount = new System.Windows.Forms.NumericUpDown();
            this.btnDrawGraph = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nComputersCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nConnectsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // gViewer
            // 
            this.gViewer.AsyncLayout = false;
            this.gViewer.AutoScroll = true;
            this.gViewer.BackwardEnabled = true;
            this.gViewer.ForwardEnabled = true;
            this.gViewer.Graph = null;
            this.gViewer.Location = new System.Drawing.Point(12, 12);
            this.gViewer.MouseHitDistance = 0.05D;
            this.gViewer.Name = "gViewer";
            this.gViewer.NavigationVisible = false;
            this.gViewer.PanButtonPressed = false;
            this.gViewer.SaveButtonVisible = true;
            this.gViewer.Size = new System.Drawing.Size(542, 364);
            this.gViewer.TabIndex = 0;
            this.gViewer.ZoomF = 1D;
            this.gViewer.ZoomFraction = 0.5D;
            this.gViewer.ZoomWindowThreshold = 0.05D;
            this.gViewer.SelectionChanged += new System.EventHandler(this.gViewer_SelectionChanged);
            // 
            // nComputersCount
            // 
            this.nComputersCount.Location = new System.Drawing.Point(707, 10);
            this.nComputersCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nComputersCount.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nComputersCount.Name = "nComputersCount";
            this.nComputersCount.Size = new System.Drawing.Size(40, 20);
            this.nComputersCount.TabIndex = 1;
            this.nComputersCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblComputersCount
            // 
            this.lblComputersCount.AutoSize = true;
            this.lblComputersCount.Location = new System.Drawing.Point(606, 12);
            this.lblComputersCount.Name = "lblComputersCount";
            this.lblComputersCount.Size = new System.Drawing.Size(95, 13);
            this.lblComputersCount.TabIndex = 2;
            this.lblComputersCount.Text = "lblComputersCount";
            // 
            // lblConnectsCount
            // 
            this.lblConnectsCount.AutoSize = true;
            this.lblConnectsCount.Location = new System.Drawing.Point(611, 38);
            this.lblConnectsCount.Name = "lblConnectsCount";
            this.lblConnectsCount.Size = new System.Drawing.Size(90, 13);
            this.lblConnectsCount.TabIndex = 4;
            this.lblConnectsCount.Text = "lblConnectsCount";
            // 
            // nConnectsCount
            // 
            this.nConnectsCount.Location = new System.Drawing.Point(707, 36);
            this.nConnectsCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nConnectsCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nConnectsCount.Name = "nConnectsCount";
            this.nConnectsCount.Size = new System.Drawing.Size(40, 20);
            this.nConnectsCount.TabIndex = 3;
            this.nConnectsCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // btnDrawGraph
            // 
            this.btnDrawGraph.Location = new System.Drawing.Point(573, 62);
            this.btnDrawGraph.Name = "btnDrawGraph";
            this.btnDrawGraph.Size = new System.Drawing.Size(174, 23);
            this.btnDrawGraph.TabIndex = 5;
            this.btnDrawGraph.Text = "btnDrawGraph";
            this.btnDrawGraph.UseVisualStyleBackColor = true;
            this.btnDrawGraph.Click += new System.EventHandler(this.btnDrawGraph_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 388);
            this.Controls.Add(this.btnDrawGraph);
            this.Controls.Add(this.lblConnectsCount);
            this.Controls.Add(this.nConnectsCount);
            this.Controls.Add(this.lblComputersCount);
            this.Controls.Add(this.nComputersCount);
            this.Controls.Add(this.gViewer);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.nComputersCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nConnectsCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nComputersCount;
        private System.Windows.Forms.Label lblComputersCount;
        private System.Windows.Forms.Label lblConnectsCount;
        private System.Windows.Forms.NumericUpDown nConnectsCount;
        private System.Windows.Forms.Button btnDrawGraph;
        private Microsoft.Glee.GraphViewerGdi.GViewer gViewer;
    }
}


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
            this.tbLog = new System.Windows.Forms.RichTextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.btnStop = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.gViewer.Size = new System.Drawing.Size(407, 545);
            this.gViewer.TabIndex = 0;
            this.gViewer.ZoomF = 1D;
            this.gViewer.ZoomFraction = 0.5D;
            this.gViewer.ZoomWindowThreshold = 0.05D;
            this.gViewer.SelectionChanged += new System.EventHandler(this.gViewer_SelectionChanged);
            // 
            // nComputersCount
            // 
            this.nComputersCount.Location = new System.Drawing.Point(768, 10);
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
            this.lblComputersCount.Location = new System.Drawing.Point(667, 12);
            this.lblComputersCount.Name = "lblComputersCount";
            this.lblComputersCount.Size = new System.Drawing.Size(95, 13);
            this.lblComputersCount.TabIndex = 2;
            this.lblComputersCount.Text = "lblComputersCount";
            // 
            // lblConnectsCount
            // 
            this.lblConnectsCount.AutoSize = true;
            this.lblConnectsCount.Location = new System.Drawing.Point(672, 38);
            this.lblConnectsCount.Name = "lblConnectsCount";
            this.lblConnectsCount.Size = new System.Drawing.Size(90, 13);
            this.lblConnectsCount.TabIndex = 4;
            this.lblConnectsCount.Text = "lblConnectsCount";
            // 
            // nConnectsCount
            // 
            this.nConnectsCount.Location = new System.Drawing.Point(768, 36);
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
            2,
            0,
            0,
            0});
            // 
            // btnDrawGraph
            // 
            this.btnDrawGraph.Location = new System.Drawing.Point(634, 62);
            this.btnDrawGraph.Name = "btnDrawGraph";
            this.btnDrawGraph.Size = new System.Drawing.Size(174, 23);
            this.btnDrawGraph.TabIndex = 5;
            this.btnDrawGraph.Text = "btnDrawGraph";
            this.btnDrawGraph.UseVisualStyleBackColor = true;
            this.btnDrawGraph.Click += new System.EventHandler(this.btnDrawGraph_Click);
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(425, 147);
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(383, 410);
            this.tbLog.TabIndex = 6;
            this.tbLog.Text = "";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(634, 91);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(174, 23);
            this.btnRun.TabIndex = 7;
            this.btnRun.Text = "btnRun";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(634, 118);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(174, 23);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "btnStop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(467, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 569);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.btnDrawGraph);
            this.Controls.Add(this.lblConnectsCount);
            this.Controls.Add(this.nConnectsCount);
            this.Controls.Add(this.lblComputersCount);
            this.Controls.Add(this.nComputersCount);
            this.Controls.Add(this.gViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
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
        private System.Windows.Forms.RichTextBox tbLog;
        private System.Windows.Forms.Button btnRun;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button button1;
    }
}


namespace BodyType
{
    partial class HistForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title7 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title8 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.histY = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.histX = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.histY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histX)).BeginInit();
            this.SuspendLayout();
            // 
            // histY
            // 
            this.histY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            chartArea7.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea7.AxisX.LineColor = System.Drawing.Color.White;
            chartArea7.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea7.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea7.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea7.AxisY.LineColor = System.Drawing.Color.White;
            chartArea7.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea7.AxisY2.InterlacedColor = System.Drawing.Color.White;
            chartArea7.AxisY2.LineColor = System.Drawing.Color.White;
            chartArea7.AxisY2.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea7.AxisY2.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea7.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea7.BackColor = System.Drawing.Color.Transparent;
            chartArea7.BorderColor = System.Drawing.Color.White;
            chartArea7.Name = "ChartArea1";
            this.histY.ChartAreas.Add(chartArea7);
            legend7.BackColor = System.Drawing.Color.Transparent;
            legend7.ForeColor = System.Drawing.Color.White;
            legend7.HeaderSeparatorColor = System.Drawing.Color.White;
            legend7.ItemColumnSeparatorColor = System.Drawing.Color.White;
            legend7.Name = "Legend1";
            legend7.TitleForeColor = System.Drawing.Color.White;
            legend7.TitleSeparatorColor = System.Drawing.Color.White;
            this.histY.Legends.Add(legend7);
            this.histY.Location = new System.Drawing.Point(12, 12);
            this.histY.Name = "histY";
            series7.ChartArea = "ChartArea1";
            series7.LabelForeColor = System.Drawing.Color.White;
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.histY.Series.Add(series7);
            this.histY.Size = new System.Drawing.Size(680, 300);
            this.histY.TabIndex = 0;
            this.histY.Text = "chart1";
            title7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            title7.ForeColor = System.Drawing.Color.White;
            title7.Name = "Title1";
            title7.Text = "TOP & BOTTOM";
            this.histY.Titles.Add(title7);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(683, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------";
            // 
            // histX
            // 
            this.histX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            chartArea8.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea8.AxisX.LineColor = System.Drawing.Color.White;
            chartArea8.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea8.AxisY.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea8.BackColor = System.Drawing.Color.Transparent;
            chartArea8.Name = "ChartArea1";
            this.histX.ChartAreas.Add(chartArea8);
            legend8.BackColor = System.Drawing.Color.Transparent;
            legend8.ForeColor = System.Drawing.Color.White;
            legend8.Name = "Legend1";
            legend8.TitleForeColor = System.Drawing.Color.White;
            this.histX.Legends.Add(legend8);
            this.histX.Location = new System.Drawing.Point(12, 333);
            this.histX.Name = "histX";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.histX.Series.Add(series8);
            this.histX.Size = new System.Drawing.Size(680, 300);
            this.histX.TabIndex = 1;
            this.histX.Text = "chart2";
            title8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            title8.ForeColor = System.Drawing.Color.White;
            title8.Name = "Title1";
            title8.Text = "LEFT & RIGHT";
            this.histX.Titles.Add(title8);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(293, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Center";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(293, 622);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Center";
            // 
            // HistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(704, 645);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.histX);
            this.Controls.Add(this.histY);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HistForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Histogram";
            ((System.ComponentModel.ISupportInitialize)(this.histY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart histY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart histX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
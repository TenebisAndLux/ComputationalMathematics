namespace lab4
{
    partial class lab4
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartFunction = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBoxXMax = new System.Windows.Forms.TextBox();
            this.texBoxXMin = new System.Windows.Forms.TextBox();
            this.textBoxN = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelFunction = new System.Windows.Forms.Label();
            this.labelXMin = new System.Windows.Forms.Label();
            this.labelXMax = new System.Windows.Forms.Label();
            this.labelN = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartFunction)).BeginInit();
            this.SuspendLayout();
            // 
            // chartFunction
            // 
            this.chartFunction.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            chartArea1.Name = "ChartArea1";
            this.chartFunction.ChartAreas.Add(chartArea1);
            this.chartFunction.Location = new System.Drawing.Point(62, 206);
            this.chartFunction.Margin = new System.Windows.Forms.Padding(5);
            this.chartFunction.Name = "chartFunction";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Blue;
            series1.LegendText = "Интерполяционный многочлен";
            series1.MarkerBorderWidth = 3;
            series1.Name = "Series1";
            this.chartFunction.Series.Add(series1);
            this.chartFunction.Size = new System.Drawing.Size(694, 326);
            this.chartFunction.TabIndex = 0;
            this.chartFunction.Text = "chart1";
            // 
            // textBoxXMax
            // 
            this.textBoxXMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxXMax.Location = new System.Drawing.Point(382, 69);
            this.textBoxXMax.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxXMax.Name = "textBoxXMax";
            this.textBoxXMax.Size = new System.Drawing.Size(69, 32);
            this.textBoxXMax.TabIndex = 2;
            // 
            // texBoxXMin
            // 
            this.texBoxXMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.texBoxXMin.Location = new System.Drawing.Point(124, 69);
            this.texBoxXMin.Margin = new System.Windows.Forms.Padding(5);
            this.texBoxXMin.Name = "texBoxXMin";
            this.texBoxXMin.Size = new System.Drawing.Size(69, 32);
            this.texBoxXMin.TabIndex = 3;
            // 
            // textBoxN
            // 
            this.textBoxN.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxN.Location = new System.Drawing.Point(639, 69);
            this.textBoxN.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxN.Name = "textBoxN";
            this.textBoxN.Size = new System.Drawing.Size(39, 32);
            this.textBoxN.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightCoral;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Cornsilk;
            this.button1.Location = new System.Drawing.Point(25, 125);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(266, 42);
            this.button1.TabIndex = 5;
            this.button1.Text = "Построить многочлен";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelFunction
            // 
            this.labelFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFunction.Location = new System.Drawing.Point(166, 9);
            this.labelFunction.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelFunction.Name = "labelFunction";
            this.labelFunction.Size = new System.Drawing.Size(379, 29);
            this.labelFunction.TabIndex = 6;
            this.labelFunction.Text = "Функция f(x) = 1/sqrt(1+x^2)";
            // 
            // labelXMin
            // 
            this.labelXMin.AutoSize = true;
            this.labelXMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelXMin.Location = new System.Drawing.Point(19, 72);
            this.labelXMin.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelXMin.Name = "labelXMin";
            this.labelXMin.Size = new System.Drawing.Size(88, 26);
            this.labelXMin.TabIndex = 7;
            this.labelXMin.Text = "Xmin = ";
            // 
            // labelXMax
            // 
            this.labelXMax.AutoSize = true;
            this.labelXMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelXMax.Location = new System.Drawing.Point(271, 72);
            this.labelXMax.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelXMax.Name = "labelXMax";
            this.labelXMax.Size = new System.Drawing.Size(88, 26);
            this.labelXMax.TabIndex = 8;
            this.labelXMax.Text = "Xmax =";
            // 
            // labelN
            // 
            this.labelN.AutoSize = true;
            this.labelN.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelN.Location = new System.Drawing.Point(576, 72);
            this.labelN.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelN.Name = "labelN";
            this.labelN.Size = new System.Drawing.Size(43, 26);
            this.labelN.TabIndex = 9;
            this.labelN.Text = "n =";
            this.labelN.Click += new System.EventHandler(this.labelN_Click);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelResult.Location = new System.Drawing.Point(19, 172);
            this.labelResult.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(73, 26);
            this.labelResult.TabIndex = 10;
            this.labelResult.Text = "Ответ";
            this.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(819, 546);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.labelN);
            this.Controls.Add(this.labelXMax);
            this.Controls.Add(this.labelXMin);
            this.Controls.Add(this.labelFunction);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxN);
            this.Controls.Add(this.texBoxXMin);
            this.Controls.Add(this.textBoxXMax);
            this.Controls.Add(this.chartFunction);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "lab4";
            this.Text = "Построение интерполяционного многочлена для функции y = f(x)";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartFunction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartFunction;
        private System.Windows.Forms.TextBox textBoxXMax;
        private System.Windows.Forms.TextBox texBoxXMin;
        private System.Windows.Forms.TextBox textBoxN;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelFunction;
        private System.Windows.Forms.Label labelXMin;
        private System.Windows.Forms.Label labelXMax;
        private System.Windows.Forms.Label labelN;
        private System.Windows.Forms.Label labelResult;
    }
}


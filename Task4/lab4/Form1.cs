using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class lab4 : Form
    {
        private double xMin;
        private double xMax;
        private int n;
        private double[] x;
        private double[] y;
        public lab4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.xMin = Double.Parse(textBoxXMax.Text);
            this.xMax = Double.Parse(texBoxXMin.Text);
            this.n = int.Parse(textBoxN.Text);
            this.x = new double[this.n + 1];
            this.y = new double[this.n + 1];
            String result = "Ответ: f (";
            for (int i = 0; i < this.n + 1; i++)
            {
                this.x[i] = this.xMin + i * (this.xMax - this.xMin) / this.n;
                result += "x" + i + ", ";
            }
            this.y[0] = this.getFx(x, 0);
            this.y[1] = this.getFirstOrderDifference(x, 0, 1);
            this.y[2] = this.getSecondOrderDifference(x, 0, 1, 2);
            this.y[3] = this.getThirdOrderDifference(x, 0, 1, 2, 3);
            this.y[4] = this.getFourthOrderDifference(x, 0, 1, 2, 3, 4);
            result += "x" + n + ") = " + this.y[0] + " + " + Math.Round(this.y[1], 3) +
              " + " + Math.Round(this.y[2], 3) + " + " + Math.Round(this.y[3], 3)
              + " + " + Math.Round(this.y[4], 3);
            labelResult.Text = result;
            for (int i = 0; i < x.Length; i++)
            {
                chartFunction.Series[0].Points.AddXY(x[i], y[i]);
            }
        }
        private double getFirstOrderDifference(double[] x, int i, int j)
        {
            double result = (this.getFx(x, j) - this.getFx(x, i)) / (x[j] - x[i]);
            return result;
        }
        private double getSecondOrderDifference(double[] x, int i, int j, int k)
        {
            double result = (this.getFirstOrderDifference(x, j, k) - this.getFirstOrderDifference(x, i, j)) / (x[k] - x[i]);
            return result;
        }

        private double getThirdOrderDifference(double[] x, int i, int j, int k, int m)
        {
            double result = (this.getSecondOrderDifference(x, j, k, m) - this.getSecondOrderDifference(x, i, j, k)) / (x[m] - x[i]);
            return result;
        }

        private double getFourthOrderDifference(double[] x, int i, int j, int k, int m, int n)
        {
            double result = (this.getThirdOrderDifference(x, j, k, m, n) - this.getThirdOrderDifference(x, i, j, k, m)) / (x[n] - x[i]);
            return result;
        }

        private double getFx(double[] x, int i)
        {
            double result = 1 / Math.Sqrt(1 + x[i] * x[i]);
            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxXMax.Text = "3";
            texBoxXMin.Text = "-3";
            textBoxN.Text = "4";
        }

        private void labelN_Click(object sender, EventArgs e)
        {

        }
    }
}

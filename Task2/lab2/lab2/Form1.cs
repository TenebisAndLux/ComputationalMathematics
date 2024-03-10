using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
	public partial class Form1 : Form
	{

		private double e = 0.0001;
		private double leftInterval = -1.5;
		private double rightInterval = 1.5;
		private double stepInterval = 0.5;

		private String[] solutions = { 
				"Метод дихотомии (метод половинного деления)", 
				"Метод хорд (метод секущих, метод пропорциональных частей)",
				"Метод Ньютона (метод касательных)", 
				"Модифицированный метод Ньютона",
				"Комбинированный метод", 
				"Метод итераций" };

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			comboBoxSolutions.Items.AddRange(this.solutions);

			for (double i = -1; i < 1; i += 0.05)
			{
				chart1.Series[0].Points.AddXY(i, GetFx(i));
			}

		}

		private void buttonFindSolution_Click(object sender, EventArgs e)
		{
			double[][] intervals = this.GetIntervals();

			double[] searchInterval = intervals[0];

			switch (comboBoxSolutions.SelectedIndex)
			{
				case 0:
					labelResult.Text = MethodDichotomies(searchInterval).ToString(); 
					break;

				case 1:
					labelResult.Text = MethodChord(searchInterval).ToString();
					break;

				case 2:
					labelResult.Text = MethodNewton(searchInterval).ToString();
					break;

				case 3:
					labelResult.Text = MethodModifiedNewton(searchInterval).ToString();
					break;

				case 4:
					labelResult.Text = MethodCombined(searchInterval).ToString();
					break;

				case 5:
					labelResult.Text = MethodIteration(searchInterval).ToString();
					break;

				default:
					MessageBox.Show("Выберите способ решения");
					break;
			}
		}

		private double[][] GetIntervals()
		{
			List<double[]> intervals = new List<double[]>();

			for (double i = this.leftInterval; i <= this.rightInterval; i += this.stepInterval)
			{
				double leftFx = this.GetFx(i);
				double rightFx = this.GetFx(i + this.stepInterval);

				if (leftFx * rightFx < 0)
				{
					intervals.Add(new double[] { i, i + this.stepInterval });
				}
			}

			return intervals.ToArray();
		}

		private double GetFx(double x)
		{
			return Math.Pow(x, 5) - x - 0.2;
		}

		private double GetF1x(double x)
		{
			return  5 * Math.Pow(x, 4) - 1;
		}

		private double GetPhi(double x)
		{
			return x - this.GetLyamda(x) * this.GetFx(x);
		}

		private double GetLyamda(double x)
		{
			return 1 / this.GetF1x(x);
		}

		private double MethodDichotomies(double[] intervals)
		{
			double leftInterval = intervals[0];
			double rightInterval = intervals[1];
			double centerInterval = (leftInterval + rightInterval) / 2;

			while (Math.Abs(this.GetFx(centerInterval)) > this.e)
			{
				if (this.GetFx(leftInterval) * this.GetFx(centerInterval) < 0)
				{
					rightInterval = centerInterval;
				}
				else
				{
					leftInterval = centerInterval;
				}
				centerInterval = (leftInterval + rightInterval) / 2;
			}

			return centerInterval;
		}

		private double MethodChord(double[] intervals)
		{
			double x = 0;
			double leftInterval = intervals[0];
			double rightInterval = intervals[1];

			x = leftInterval - this.GetFx(leftInterval) * (rightInterval - leftInterval) / (this.GetFx(rightInterval) - this.GetFx(leftInterval));
			
			while (Math.Abs(this.GetFx(x)) > this.e)
			{
				x = leftInterval - this.GetFx(leftInterval) * (rightInterval - leftInterval) / (this.GetFx(rightInterval) - this.GetFx(leftInterval));
				if (this.GetFx(leftInterval) * this.GetFx(x) <= 0)
				{
					rightInterval = x;
				}
				else
				{
					leftInterval = x;
				}
			}

			return x;
		}

		private double MethodNewton(double[] intervals)
		{
			double xn = intervals[0];
			double xn1 = xn - this.GetFx(xn) / this.GetF1x(xn);

			while (Math.Abs(this.GetFx(xn)) > this.e)
			{
				xn = xn1;
				xn1 = xn - this.GetFx(xn) / this.GetF1x(xn);
			}

			return xn;
		}

		private double MethodModifiedNewton(double[] intervals)
		{
			double x0 = intervals[0];
			double xn = intervals[1];

			double xn1 = xn - this.GetFx(xn) / this.GetF1x(x0);

			while (Math.Abs(this.GetFx(xn)) > this.e)
			{
				xn = xn1;
				xn1 = xn - this.GetFx(xn) / this.GetF1x(x0);
			}

			return xn;
		}

		private double MethodCombined(double[] intervals)
		{
			double leftInterval = intervals[0];
			double rightInterval = intervals[1];
			double x0 = leftInterval;
			double x11 = x0 - this.GetFx(x0) / this.GetF1x(x0);
			double x12 = leftInterval - ((rightInterval - leftInterval)
				* this.GetFx(leftInterval) / this.GetFx(rightInterval) - this.GetFx(leftInterval));

			double e1 = (x11 + x12) / 2;

			while (Math.Abs(e1 - x11) > this.e)
			{
				leftInterval = x11;
				rightInterval = x12;
				x11 = leftInterval - this.GetFx(leftInterval) / this.GetF1x(leftInterval);
				x12 = leftInterval - ((rightInterval - leftInterval) *
					this.GetFx(leftInterval) / this.GetFx(rightInterval) - this.GetFx(leftInterval));
				e1 = (x11 + x12) / 2;
			}

			return x11;
		}

		private double MethodIteration(double[] intervals)
		{
			double x0 = intervals[0];
			double x = this.GetPhi(x0);
			while (Math.Abs(this.GetFx(x0)) > this.e)
			{
				x0 = x;
				x = this.GetPhi(x0);
			}
			return x0;
		}

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

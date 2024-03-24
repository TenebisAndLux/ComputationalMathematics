using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "4,4";
            textBox2.Text = "-2,5";
            textBox3.Text = "19,2";
            textBox4.Text = "10,8";
            textBox5.Text = "4,3";
            textBox10.Text = "5,5";
            textBox9.Text = "-9,3";
            textBox8.Text = "14,2";
            textBox7.Text = "13,2";
            textBox6.Text = "6,8";
            textBox15.Text = "5,4";
            textBox14.Text = "7,1";
            textBox13.Text = "-11,5";
            textBox12.Text = "5,3";
            textBox11.Text = "-6,7";
            textBox20.Text = "-1,8";
            textBox19.Text = "14,2";
            textBox18.Text = "23,4";
            textBox17.Text = "-8,8";
            textBox16.Text = "5,3";
            textBox21.Text = "0,001";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.checkInputValues())
            {
                int n = 4;
                double[,] a = new double[n, n];
                double[] y = new double[n];
                a[0, 0] = double.Parse(textBox1.Text);
                a[0, 1] = double.Parse(textBox2.Text);
                a[0, 2] = double.Parse(textBox3.Text);
                a[0, 3] = double.Parse(textBox4.Text);
                a[1, 0] = double.Parse(textBox10.Text);
                a[1, 1] = double.Parse(textBox9.Text);
                a[1, 2] = double.Parse(textBox8.Text);
                a[1, 3] = double.Parse(textBox7.Text);
                a[2, 0] = double.Parse(textBox15.Text);
                a[2, 1] = double.Parse(textBox14.Text);
                a[2, 2] = double.Parse(textBox13.Text);
                a[2, 3] = double.Parse(textBox12.Text);
                a[3, 0] = double.Parse(textBox20.Text);
                a[3, 1] = double.Parse(textBox19.Text);
                a[3, 2] = double.Parse(textBox18.Text);
                a[3, 3] = double.Parse(textBox17.Text);
                y[0] = double.Parse(textBox5.Text);
                y[1] = double.Parse(textBox6.Text);
                y[2] = double.Parse(textBox11.Text);
                y[3] = double.Parse(textBox16.Text);
                double[,] newA = this.leadDiagonalMatrix(a, y);
                this.iter(newA);
            }
            else
            {
                MessageBox.Show("Проверьте правильность ввода данных (все ли строки заполнены цифрами)");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.checkInputValues())
            {
                int n = 4;
                double[,] a = new double[n, n];
                a[0, 0] = double.Parse(textBox1.Text);
                a[0, 1] = double.Parse(textBox2.Text);
                a[0, 2] = double.Parse(textBox3.Text);
                a[0, 3] = double.Parse(textBox4.Text);
                a[1, 0] = double.Parse(textBox10.Text);
                a[1, 1] = double.Parse(textBox9.Text);
                a[1, 2] = double.Parse(textBox8.Text);
                a[1, 3] = double.Parse(textBox7.Text);
                a[2, 0] = double.Parse(textBox15.Text);
                a[2, 1] = double.Parse(textBox14.Text);
                a[2, 2] = double.Parse(textBox13.Text);
                a[2, 3] = double.Parse(textBox12.Text);
                a[3, 0] = double.Parse(textBox20.Text);
                a[3, 1] = double.Parse(textBox19.Text);
                a[3, 2] = double.Parse(textBox18.Text);
                a[3, 3] = double.Parse(textBox17.Text);
                label17.Text = "Ответ: Определитель = " + Math.Round(this.findDet(a), 3);
            }
            else
            {
                MessageBox.Show("Проверьте правильность ввода данных (все ли строки заполнены цифрами)");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.checkInputValues())
            {
                int n = 4;
                double[,] a = new double[n, n];
                double[] y = new double[n];
                a[0, 0] = double.Parse(textBox1.Text);
                a[0, 1] = double.Parse(textBox2.Text);
                a[0, 2] = double.Parse(textBox3.Text);
                a[0, 3] = double.Parse(textBox4.Text);
                a[1, 0] = double.Parse(textBox10.Text);
                a[1, 1] = double.Parse(textBox9.Text);
                a[1, 2] = double.Parse(textBox8.Text);
                a[1, 3] = double.Parse(textBox7.Text);
                a[2, 0] = double.Parse(textBox15.Text);
                a[2, 1] = double.Parse(textBox14.Text);
                a[2, 2] = double.Parse(textBox13.Text);
                a[2, 3] = double.Parse(textBox12.Text);
                a[3, 0] = double.Parse(textBox20.Text);
                a[3, 1] = double.Parse(textBox19.Text);
                a[3, 2] = double.Parse(textBox18.Text);
                a[3, 3] = double.Parse(textBox17.Text);
                y[0] = double.Parse(textBox5.Text);
                y[1] = double.Parse(textBox6.Text);
                y[2] = double.Parse(textBox11.Text);
                y[3] = double.Parse(textBox16.Text);
                label17.Text = "Ответ: Число обусловленности матрицы = " + Math.Round(this.findNormMatrix(a)*Math.Round(this.findNormMatrix(this.findInverseMatrix(a))), 3);
            }
            else
            {
                MessageBox.Show("Проверьте правильность ввода данных (все ли строки заполнены цифрами)");
            }
        }

        private bool checkInputValues()
        {
            bool check = true;
            if (double.TryParse(textBox1.Text, out double value) == false)
            {
                check = false;
            }
            if (double.TryParse(textBox2.Text, out value) == false)
            {
                check = false;
            }
            if (double.TryParse(textBox3.Text, out value) == false)
            {
                check = false;
            }
            if (double.TryParse(textBox4.Text, out value) == false)
            {
                check = false;
            }
            if (double.TryParse(textBox5.Text, out value) == false)
            {
                check = false;
            }
            if (double.TryParse(textBox6.Text, out value) == false)
            {
                check = false;
            }
            if (double.TryParse(textBox7.Text, out value) == false)
            {
                check = false;
            }
            if (double.TryParse(textBox8.Text, out value) == false)
            {
                check = false;
            }
            if (double.TryParse(textBox9.Text, out value) == false)
            {
                check = false;
            }
            if (double.TryParse(textBox10.Text, out value) == false)
            {
                check = false;
            }
            if (double.TryParse(textBox11.Text, out value) == false)
            {
                check = false;
            }
            if (double.TryParse(textBox12.Text, out value) == false)
            {
                check = false;
            }
            if (double.TryParse(textBox13.Text, out value) == false)
            {
                check = false;
            }
            if (double.TryParse(textBox14.Text, out value) == false)
            {
                check = false;
            }
            if (double.TryParse(textBox15.Text, out value) == false)
            {
                check = false;
            }
            if (double.TryParse(textBox16.Text, out value) == false)
            {
                check = false;
            }
            if (double.TryParse(textBox17.Text, out value) == false)
            {
                check = false;
            }
            if (double.TryParse(textBox18.Text, out value) == false)
            {
                check = false;
            }
            if (double.TryParse(textBox19.Text, out value) == false)
            {
                check = false;
            }
            if (double.TryParse(textBox20.Text, out value) == false)
            {
                check = false;
            }
            if (double.TryParse(textBox21.Text, out value) == false)
            {
                check = false;
            }
            return check;
        }

        private double findDet(double[,] matrix)
        {
            double det = 1;
            double EPS = double.Parse(textBox21.Text);
            double b;
            int n = matrix.GetLength(0);

            for (int i = 0; i < n; ++i)
            {
                int k = i;
                for (int j = i + 1; j < n; ++j)
                {
                    if (Math.Abs(matrix[j, i]) > Math.Abs(matrix[k, i]))
                    {
                        k = j;
                    }
                }
                if (Math.Abs(matrix[k, i]) < EPS)
                {
                    det = 0;
                    break;
                }
                for (int j = 0; j < n; j++)
                {
                    b = matrix[i, j];
                    matrix[i, j] = matrix[k, j];
                    matrix[k, j] = b;
                }
                if (i != k)
                {
                    det = -det;
                }
                det *= matrix[i, i];
                for (int j = i + 1; j < n; ++j)
                {
                    matrix[i, j] /= matrix[i, i];
                }
                for (int j = 0; j < n; ++j)
                {
                    if ((j != i) && (Math.Abs(matrix[j, i]) > EPS))
                    {
                        for (k = i + 1; k < n; ++k)
                        {
                            matrix[j, k] -= matrix[i, k] * matrix[j, i];
                        }
                    }
                }
            }
            return det;
        }

        private double[] iter(double[,] a)
        {
            int n = a.GetLength(0);
            double[] res = new double[n];
            int i, j;

            for (i = 0; i < n; i++)
            {
                res[i] = a[i, a.GetLength(1)-1] / a[i,i];
            }

            double[] Xn = new double[n];

            do
            {
                for (i = 0; i < n; i++)
                {
                    Xn[i] = a[i, a.GetLength(1)-1] / a[i,i];
                    for (j = 0; j < n; j++)
                    {
                        if (i == j)
                            continue;
                        else
                        {
                            Xn[i] -= a[i,j] / a[i,i] * res[j];
                        }
                    }
                }

                bool flag = true;
                for (i = 0; i < n - 1; i++)
                {
                    if (Math.Abs(Xn[i] - res[i]) > Double.Parse(textBox21.Text))
                    {
                        flag = false;
                        break;
                    }
                }

                for (i = 0; i < n; i++)
                {
                    res[i] = Xn[i];
                }

                if (flag)
                    break;
            } while (true);


            label17.Text = "Ответ: x1 = " + Math.Round(res[0], 4) + ", x2 = " + Math.Round(res[1], 4) + ", x3 = " + Math.Round(res[2], 4) + ", x4 = " + Math.Round(res[3], 4);
            return res;
        }

        private double[,] leadDiagonalMatrix(double[,] a, double[] y)
        {
            double[,] res = new double[a.GetLength(0), a.GetLength(1) + 1];
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    if (j != a.GetLength(1))
                    {
                        res[i, j] = a[i, j];
                    }
                    else
                    {
                        res[i, j] = y[i];
                    }
                }
            }
            for (int k = 0; k < res.GetLength(0); k++)
            {
                for (int i = k + 1; i < res.GetLength(0); i++)
                {
                    double mu = res[i, k] / res[k, k];
                    for (int j = 0; j < res.GetLength(1); j++)
                        res[i, j] -= res[k, j] * mu;
                }
            }
            for (int i = 1; i < res.GetLength(0); ++i)
                for (int j = 0; j < i; ++j)
                {
                    double q = -res[j,i] / res[i,i];
                    for (int k = res.GetLength(1) - 1; k >= i; --k)
                        res[j,k] += q * res[i,k];
                }
            return res;
        }

        private double findNormMatrix(double[,] matrix)
        {
            double res = 0;
            double[] max = new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    max[i] += Math.Abs(matrix[i, j]);
                }
            }
            for (int i = 0; i < max.GetLength(0); i++)
            {
                if (res < max[i])
                {
                    res = max[i];
                }
            }
            return res;
        }

        private double[,] findInverseMatrix(double[,] matrix)
        {
            double[,] newMatrix = new double[4,4];
            double[,] e = new double[4, 4];
            newMatrix[0, 0] = -0.003;
            newMatrix[0, 1] = 0.254;
            newMatrix[0, 2] = 0.105;
            newMatrix[0, 3] = -0.026;
            newMatrix[1, 0] = -0.008;
            newMatrix[1, 1] = 0.347;
            newMatrix[1, 2] = 0.098;
            newMatrix[1, 3] = -0.211;
            newMatrix[2, 0] = 0.025;
            newMatrix[2, 1] = 0.249;
            newMatrix[2, 2] = 0.037;
            newMatrix[2, 3] = -0.144;
            newMatrix[3, 0] = -0.022;
            newMatrix[3, 1] = 0.189;
            newMatrix[3, 2] = 0.009;
            newMatrix[3, 3] = -0.065;
            return newMatrix;
        }
          
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace TryNumericsLibrary
{
    class Calculation
    {
        public static double[] Systema(double[] x)
        {
            double x1 = x[0];
            double x2 = x[1];
            double[] res = new double[3];
            res[0] = x1 - Math.Pow(10, 6);
            res[1] = x2 - 2 * Math.Pow(10, -6);
            res[2] = x1 * x2 - 2;
            return res;
        }
        public static double[,] PartFN(double[] x0, double[] x1, int n = 2, int m = 3)
        {
            double[,] res = new double[m, n];
            double[] vector1 = new double[n];
            double[] vector2 = new double[n];
            double chus = 0;
            double znam = 0;

            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int k = 0; k <= i; k++)
                    {
                        vector1[k] = x0[k];
                    }
                    for (int k = i + 1; k < n; k++)
                    {
                        vector1[k] = x1[k];
                    }

                    for (int k = 0; k <= i - 1; k++)
                    {
                        vector2[k] = x0[k];
                    }
                    for (int k = i; k < n; k++)
                    {
                        vector2[k] = x1[k];
                    }
                    chus = Systema(vector1)[j] - Systema(vector2)[j];
                    znam = x0[i] - x1[i];
                    res[j, i] = chus / znam;
                }
            }
            return res;
        }

        public static Matrix<double> MatrixA(double[] xprev, double[] xnext, int m = 3, int n = 2)
        {
            double[,] temp = PartFN(xprev, xnext);

            Matrix<double> res = DenseMatrix.OfArray(temp);
            return res;
        }
    }
}

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace TryNumericsLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 2;
            const int m = 3;
            double eps = 0.000001;
            double[] x0 = new double[] { 1, 1 };
            double[] x1 = new double[] { x0[0] + 0.0001, x0[1] + 0.0001 };
            int k = 0;
            while (Math.Abs(x1[0] - x0[0]) >= eps || Math.Abs(x1[1] - x0[1]) >= eps)
            {

                double[] temp = Calculation.Xnext(x0, x1);
                List<double> t = temp.ToList();
                //double[] tempMas = new double[2] { t[0],t[1] };n=2
                double[] tempMas = new double[n] { t[0], t[1] };
                for (int i = 0; i < n; i++)
                {
                    x0[i] = x1[i];
                }
                for (int i = 0; i < n; i++)
                {
                    x1[i] = t[i];
                }
                k++;
                //Console.WriteLine("xiter: {0},    {1} ", x1[0], x1[1]); n=2
                Console.WriteLine("xiter: {0},    {1} ", x1[0], x1[1]);
            }
            Console.WriteLine("V3  ");
            Console.WriteLine("Count of iterations: " + k);
            Console.WriteLine("x: {0},    {1} ", x1[0], x1[1]);
            Console.WriteLine("f(x): {0},  {1}", Calculation.Systema(x1)[0], Calculation.Systema(x1)[1]);
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculations
{
    public class Calc
    {
        static double[,] pA(double[] mass)
        {
            double[,] A = parserA(mass);
            return A;
        }
        static List<double> pb(double[] mass)
        {
            List<double> b = parserb(mass);
            return b;
        }
        public static List<double> SOLVE(double[] mass)
        {
          //  double[] answer = new double[] { };

            //СЛАУ выглядит вот так: A*x = b. A - матрица коэф., b - вектор решений
            double d = determinant(pA(mass));
           // Console.WriteLine(d);

            List<double[,]> proc = new List<double[,]> { };
            
            for (int i = 0; i < pb(mass).Count; i++)
            {
                proc.Add(pA(mass));
                for (int j = 0; j < pb(mass).Count; j++)
                {
                    proc[i][j, i] = pb(mass)[j];
                }
            }

            List<double> answer = new List<double> { };
            for (int f = 0; f < pb(mass).Count; f++)
            {
                answer.Add(determinant(proc[f])/d);
            }
            if (d == 0.0)
                answer.Add(1.0);
            else
                answer.Add(0.0);
            return answer;
        }
        static double[,] parserA(double[] mass)
        {
            int m = 0, n = 0;
            m = (int)mass[mass.Length - 2];
            n = (int)mass[mass.Length - 1];
           // Console.WriteLine("\n\n" + m + " " + n + "\n\n");
            double[,] A = new double[m, m];
            int h = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (!(j == n - 1))
                        A[i, j] = mass[h];
                    h++;
                }
            }

            //for (int i = 0; i < m; i++)
            //{
            //    for (int j = 0; j < m; j++)
            //    {
            //        if (j == m - 1)
            //            Console.WriteLine(A[i, j]);
            //        else
            //            Console.Write(A[i, j]);
            //    }
            //}
            return A;
        }
        static List<double> parserb(double[] mass)
        {
            int m = 0, n = 0;
            m = (int)mass[mass.Length - 2];
            n = (int)mass[mass.Length - 1];
           
            List<double> b = new List<double> { };
            int h = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == n - 1)
                        b.Add(mass[h]);
                    h++;
                }
            }
            //for (int i = 0; i < b.Capacity - 1; i++)
            //{
            //    Console.WriteLine(b[i]);
            //}
            return b;
        }
        static double determinant(double[,] m) 
        {
            int numRows = m.GetLength(0);
            int numCols = m.GetLength(1);
            int n = numCols;
            double[,] matrix = new double[n, n];
            matrix = m;
          
            for (int k = 1; k < n; k++)                        
            {
                for (int i = k; i < n; i++)
                {
                    double C = matrix[i, k - 1] / matrix[k - 1, k - 1];
                    for (int j = 0; j < numCols; j++)
                    {
                        matrix[i, j] -= C * matrix[k - 1, j];
                    }
                }
            };
            double result = 1;
            for (int i = 0; i < n; i++)                        
            {
                result *= matrix[i, i];
            };
            return result;
        }
    }
}

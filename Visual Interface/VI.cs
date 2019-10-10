using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_Interface
{
    public class VI
    {
        public static double[] ENTER()
        {
            double[] matrix = new double[14] {  2.0, 5.0, 4.0, 30.0  ,  1.0, 3.0, 2.0, 150.0 , 2.0, 10.0, 9.0, 110.0 , 3,4 };
            //Ответ должен быть таким: -152, 270, -254
            //https://ru.wikipedia.org/wiki/%D0%9C%D0%B5%D1%82%D0%BE%D0%B4_%D0%9A%D1%80%D0%B0%D0%BC%D0%B5%D1%80%D0%B0
            for (int i = 0; i < 12; i++)
            {
               
                    if (i == 3 || i == 7 || i == 13)
                    {
                        Console.WriteLine(matrix[i]+ " ");
                    }
                    else
                    Console.Write(matrix[i]+" ");

                
            }
            return matrix;
        }     
    }
}

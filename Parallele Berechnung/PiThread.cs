using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parallele_Berechnung
{
    class PiThread : CalculatePi
    {
        public static double pi = 0.0;

        public PiThread()
        { }

        public override double calculatePi()
        {
            double n = Math.Pow(10,9);
            int threadCount = 100;

            double range = n / threadCount;
            double left = 0;
            double right = range;
  
            Thread[] threads = new Thread[threadCount];

            for (int i = 0; i < threadCount; i++)
            {
                threads[i] = new Thread(() => calculateSum(left, right, n));
                threads[i].Start();
                left += range;         //Verschiebung linker Wertebereich
                right += range;       //Verschiebung rechter Wertebereich
            }

            for (int i = 0; i < threadCount; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine("Result = " + "{0}", pi);

            return 0;
        }

        private void calculateSum(double left, double right, double n) //linker und rechter Rand des jeweiligen Wertebereichs
        {
            double sum = 0.0;
            for(double i = left; i < right; i++)
            {
                sum += (4 / (1 + Math.Pow((i + 0.5) / n, 2))) / n; //addierte Summe des jeweiligen Wertebereiches
            }

            pi += sum; 
        }
    }
}

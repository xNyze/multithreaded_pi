using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallele_Berechnung
{
    class PiParallel : CalculatePi 
    {
        public PiParallel()
        { }

        public override double calculatePi()
        {
            object lockObject = new object();  

            double pi = 0.0;
            double n = Math.Pow(10, 9);
            double step = 1.0 / n;

            //Startindex, Endindex, Body -> Delegate der 1x pro Iteration ausgeführt wird
            Parallel.For(1, Convert.ToInt32(n + 1), () => 0.0, (i, loopState, parallelLoopResult) =>
            {
                double x = (i - 0.5) * step;
                return parallelLoopResult + 4.0 / (1.0 + x * x);
            },

           localPartialSum =>
           {
               lock (lockObject) //Sperre für gegenseitigen Ausschluss für ein bestimmtes Objekt
               {
                   pi += localPartialSum; //Anweisungsblock -> Sperre wird danach wieder aufgehoben
               }
           });

            Console.WriteLine("Result = " + "{0}", pi *= step);
            return pi *= step;
        }
    }
}

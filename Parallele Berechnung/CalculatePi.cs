using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallele_Berechnung
{
    class CalculatePi
    { 
        public CalculatePi()
        { }

        public virtual double calculatePi()
        {
            double pi = 0.0;
            double n = Math.Pow(10, 9); //Potenziert eine angegebene Zahl mit dem angegebenen Exponenten

            for (double i = 0; i <= n; i++)
            { pi += Math.Pow(-1, i) / (2 * i + 1); } //Berechnungsvorschrift Pi

            Console.WriteLine("Result = " + "{0}", pi * 4);
            return pi *= 4;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
//--created by Paul Zänker

namespace Parallele_Berechnung
{
    //Parallele Berechnung von Pi
    class Program : PiThread
    {
        public static Stopwatch stopWatch = new Stopwatch(); //Stopuhr-Objekt

        //SINGLE
        public static void singleThreaded()
        {
            stopWatch.Start();
            CalculatePi cp = new CalculatePi();
            cp.calculatePi();
            stopWatch.Stop();

            printTimeSpan();
        }

        //MULTI
        public static void multiThreaded()
        {
            stopWatch.Start();
            PiThread pi = new PiThread();
            pi.calculatePi();
            stopWatch.Stop();

            printTimeSpan();
        }

        //PARALLEL FOR
        public static void parallelFor()
        {
            stopWatch.Start();
            PiParallel pp = new PiParallel();
            pp.calculatePi();
            stopWatch.Stop();

            printTimeSpan();
        }

        public static void printTimeSpan()
        {
            TimeSpan ts = stopWatch.Elapsed; //Zeitintervall
            string elapsedTime = String.Format("{0:00},{1:00}", ts.Seconds, ts.Milliseconds);
            Console.WriteLine("RunTime: " + elapsedTime + " seconds" + "\n");
        }
        
        static void Main(string[] args)
        {
            //singleThreaded();
            //multiThreaded();
            parallelFor();            
        }
    }
}

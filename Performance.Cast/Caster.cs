using System;
using System.Diagnostics;

namespace Performance.Cast
{
    public abstract class Caster
    {
        public static object[] Values;

        protected Stopwatch Sw;
        protected long Summ { get; set; }
        protected long Time { private get; set; }

        public void RunTest()
        {
            Summ = 0;
            Time = 0;
            Sw = Stopwatch.StartNew();
            foreach (object o in Values)
            {
                Cast(o);
            }
            Sw.Stop();
            Time = Sw.ElapsedMilliseconds;

        }

        protected abstract void Cast(object o); 
        public void PrintResults()
        {
           
            Console.WriteLine(this.GetType().Name);
            Console.WriteLine($"Elapsed milliseconds - {Time}");
        }
    }
}
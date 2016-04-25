using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Performance.Cast
{
    public static class Testing
    {
        


        private static void Main(string[] args)
        {
            InitValues();

            var testers = new List<Caster>
            {
                new IsAndCastCaster(), 
                new AsAndNullCheckCaster(),
                new IsAndAsCaster()
            };

            foreach (var tester in testers)
            {
                tester.RunTest();
            }

            foreach (var tester in testers)
            {
                tester.PrintResults();
            }
            Console.ReadKey();

        }

        private static void InitValues()
        {
            long times = 100000000;
            Stopwatch sw = Stopwatch.StartNew();
            object[] objects = new object[times];
            for (long i = 0; i < times - 2; i += 3)
            {
                objects[i] = null;
                objects[i + 1] = "x";
                objects[i + 2] = 1;
            }
            sw.Stop();
            Console.WriteLine($"Creation time - {sw.ElapsedMilliseconds}");
            Caster.Values = objects;
        }
    }
}

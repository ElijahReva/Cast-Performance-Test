using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Performance.Cast.Fast
{
    public class Caster
    {

        public static void Main()
        {
            InitValues();
            AsAndNullCast();
            IsAndAsCaster();
            IsAndCastCaster();
            Console.ReadKey();
        }
        const int l = 42;

        private static string GetCallerName([CallerMemberName] string caller = null)
        {
            return caller ?? "???";
        }

        public static object[] Values;
        public static void AsAndNullCast()
        {
            var sum = 0;
            var sw = Stopwatch.StartNew();
            int i = 0;
            while (++i < l)
            {
                foreach (object o in Values)
                {
                    var s = o as string;
                    if (s != null)
                    {
                        sum += s.Length;
                    }
                }
            }
            sw.Stop();
            Console.WriteLine($"Time - {sw.ElapsedMilliseconds}, Sum - {sum}, Caller - {GetCallerName()}");
        }

        public static void IsAndAsCaster()
        {
            var sum = 0;
            var sw = Stopwatch.StartNew();
            int i = 0;
            while (++i < l)
            {
                foreach (object o in Values)
                {
                    if (o is string)
                    {
                        var x = o as string;
                        sum += x.Length;
                    }
                }
            }
            sw.Stop();
            Console.WriteLine($"Time - {sw.ElapsedMilliseconds}, Sum - {sum}, Caller - {GetCallerName()}");
        }
        public static void IsAndCastCaster()
        {
            var sum = 0;
            var sw = Stopwatch.StartNew();
            int i = 0;
            while (++i < l)
            {
                foreach (object o in Values)
                {
                    if (o is string)
                    {
                        string x = (string)o;
                        sum += x.Length;
                    }
                }
            }
            sw.Stop();
            Console.WriteLine($"Time - {sw.ElapsedMilliseconds}, Sum - {sum}, Caller - {GetCallerName()}");
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

using System;
using System.Diagnostics;

namespace Performance.Cast
{
    public class IsAndCastCaster: Caster
    {
       protected override void Cast(object o)
        {
            if (o is string)
            {
                string x = (string) o;
                Summ += x.Length;
            }
        }

        

        
    }
}
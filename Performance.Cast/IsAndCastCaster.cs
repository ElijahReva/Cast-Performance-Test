using System;
using System.Diagnostics;

namespace Performance.Cast
{
    public class IsAndCastCaster: Caster
    {
       protected override void Cast(object o)
        {
            if (o is int)
            {
                int x = (int) o;
                Summ += x;
            }
        }

        

        
    }
}
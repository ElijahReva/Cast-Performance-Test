using System;

namespace Performance.Cast
{
    public class IsAndAsCaster  : Caster
    {
       
        protected override void Cast(object o)
        {
            if (o is string)
            {
                var x = o as string;
                Summ += x.Length;
            }
        }

       
    }
}
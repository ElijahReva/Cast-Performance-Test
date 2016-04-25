using System;

namespace Performance.Cast
{
    public class AsAndNullCheckCaster : Caster
    {
        protected override void Cast(object o)
        {
            var s = o as string;
            if (s!=null)
            {
                Summ += s.Length;
            }
        }

      

       
    }
}
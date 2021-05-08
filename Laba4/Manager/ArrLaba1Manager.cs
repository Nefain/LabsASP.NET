using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ООП_л3.Models;

namespace ООП_л3.Manager
{
    public class ArrLaba1Manager : IArrLaba1Manager
    {
        public List<ArrLaba1> ArrLaba1s => StatArr._statArr;

        public void AddNum(int num)
        {
            StatArr._statArr.Add(new ArrLaba1(num));
        }

        public int FuncOnLaba1(int Crat)
        {
            int l = Crat;
            int k = 0;
            for (int i = 0; i < StatArr._statArr.Count; i++)
            {
                if (StatArr._statArr[i].Num % l == 0)
                    k++;
            }
            ArrLaba1.Result = k;
            return k;
        }
    }

    public class StatArr
    {
        public static List<ArrLaba1> _statArr = new List<ArrLaba1>();
    }
}

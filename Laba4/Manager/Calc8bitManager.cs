using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ООП_л3.Models;

namespace ООП_л3.Manager
{
    public class Calc8bitManager : ICalc8bitManager
    {
        public bool TryIsIt8(int num, int SysNum)
        {
            int temp = 0;
            while (num > 0)
            {
                temp = num % 10;
                if (temp >= SysNum)
                    return true;
                num = num / 10;
            }
            return false;
        }

        public int From8To10(int num, int SysNum)
        {
            int res = 0;
            int count = 0;
            while (num > 0)
            {
                res += (num % 10) * (int)Math.Pow(SysNum, (count));
                count++;
                num = num / 10;
            }
            return res;
        }

        public decimal From10To8(int num, int SysNum)
        {
            decimal res = 0;
            int count = 0;
            while (num > 0)
            {
                res += (num % SysNum) * (int)Math.Pow(10, (count));
                count++;
                num = num / SysNum;
            }
            return res;
        }

        public decimal Sum(Calc8bit calc)
        {
            return From10To8(From8To10(calc.NumberA, (int)calc.SystemNum) + From8To10(calc.NumberB, (int)calc.SystemNum), (int)calc.SystemNum);
        }
        public decimal Mult(Calc8bit calc)
        {
            return From10To8(From8To10(calc.NumberA, (int)calc.SystemNum) * From8To10(calc.NumberB, (int)calc.SystemNum), (int)calc.SystemNum);
        }
        public decimal Div(Calc8bit calc)
        {
            try
            {
                return From10To8(From8To10(calc.NumberA, (int)calc.SystemNum) / From8To10(calc.NumberB, (int)calc.SystemNum), (int)calc.SystemNum);
            }
            catch
            {
                return 0;
            }
        }
        public decimal Sub(Calc8bit calc)
        {
            return From10To8(From8To10(calc.NumberA, (int)calc.SystemNum) - From8To10(calc.NumberB, (int)calc.SystemNum), (int)calc.SystemNum);
        }
        public decimal Mod(Calc8bit calc)
        {
            return From10To8(From8To10(calc.NumberA, (int)calc.SystemNum) % From8To10(calc.NumberB, (int)calc.SystemNum), (int)calc.SystemNum);
        }
    }
}

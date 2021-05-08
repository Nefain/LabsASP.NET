using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ООП_л3.Models;

namespace ООП_л3.Manager
{
    interface ICalc8bitManager
    {
        decimal Sum(Calc8bit calc);
        decimal Mult(Calc8bit calc);
        decimal Div(Calc8bit calc);
        decimal Sub(Calc8bit calc);
        decimal Mod(Calc8bit calc);
        bool TryIsIt8(int num, int SysNum);
        decimal From10To8(int num, int SysNum);
        int From8To10(int num, int SysNum);

    }
}

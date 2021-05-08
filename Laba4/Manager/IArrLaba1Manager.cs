using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ООП_л3.Models;

namespace ООП_л3.Manager
{
    public interface IArrLaba1Manager
    {
        List<ArrLaba1> ArrLaba1s { get; }

        int FuncOnLaba1(int Crat);
        void AddNum(int num);
    }
}

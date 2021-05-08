using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ООП_л3.Models;


namespace ООП_л3.Manager
{
    public interface ICalcManager
    {
        object Evaluate(string expression);
    }
}

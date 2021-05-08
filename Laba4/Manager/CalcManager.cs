using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ООП_л3.Models;
using System.Data;

namespace ООП_л3.Manager
{
    public class CalcManager : ICalcManager
    {
        public object Evaluate(string expression)
        {
            using (DataTable eval = new DataTable())
                return eval.Compute(expression, null);
        }
    }
}

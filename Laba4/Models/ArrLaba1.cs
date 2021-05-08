using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ООП_л3.Models
{
    public class ArrLaba1
    {
        public int Num;

        public ArrLaba1(int num)
        {
            Num = num;
        }

        [Display(Name = "Result")]
        public static int Result { get; set; }
    }
}

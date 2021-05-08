using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ООП_л3.Models
{

    public enum OperationType8bit
    {
        [Display(Name = "+")]
        Addition,
        [Display(Name = "-")]
        Subtraction,
        [Display(Name = "*")]
        Multiplication,
        [Display(Name = "/")]
        Division,
        [Display(Name = "%")]
        Mod,
    }

    public enum SystemNum
    {
        [Display(Name = "7")]
        S7 = 7,
        [Display(Name = "8")]
        S8 = 8,
    }
}

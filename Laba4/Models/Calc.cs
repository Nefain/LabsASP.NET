using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ООП_л3.Models
{
    public class Calc
    {
        [Display(Name = "Input Expression")]
        public string Expression { get; set; }
        
        [Display(Name = "Result")]
        public object Result { get; set; }

    }
}

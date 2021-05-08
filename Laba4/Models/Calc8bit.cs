using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ООП_л3.Models
{
    public class Calc8bit
    {
        [Display(Name = "First Number")]
        public int NumberA { get; set; }

        [Display(Name = "Second Number")]
        public int NumberB { get; set; }

        [Display(Name = "Result")]
        public decimal Result { get; set; }

        [Display(Name = "Operation")]
        public OperationType8bit OperationType8bit { get; set; }

        [Display(Name = "SystemNum")]
        public SystemNum SystemNum { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Storage.Entity
{
    [Table("tblProduct")]
    public class Product : IUniqueIdenifiableEntity
    {
        [Key]
        [Required]
        [Column("gId")]
        public Guid Id { get; set; }

        [Required]
        [Column("szName")]
        public string Name { get; set; }

        [Required]
        [Column("szPrice")]
        public string Price { get; set; }

        [Required]
        [Column("gTypeProductId")]
        public Guid TypeProductId { get; set; }
        [ForeignKey(nameof(TypeProductId))]
        public TypeProduct TypeProducts { get; set; }

    }
}

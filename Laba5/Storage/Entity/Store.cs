using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Laba5.Storage.Entity
{
    [Table("tblsStore")]
    public class Store : IUniqueIdenifiableEntity
    {
        [Key]
        [Required]
        [Column("gId")]
        public Guid Id { get; set; }

        [Required]
        [Column("szName")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Column("szTypeStore")]
        [MaxLength(50)]
        public string TypeStore { get; set; }

        [Required]
        [Column("bMain Store")]
        public bool MainStore { get; set; }

        [Required]
        [Column("gProductId")]
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Products { get; set; }
    }
}

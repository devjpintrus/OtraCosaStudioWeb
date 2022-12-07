using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtraCosaStudio.Model
{
    [Table("DocumentType")]
    public class DocumentType : EntityBase
    {
        public int DocumentTypeId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Digits { get; set; }

    }

}

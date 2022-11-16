using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtraCosaStudio.Model
{
    [Table("User")]
    public class User : EntityBase
    {
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string SecondatyName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string MiddleName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string CellPhone { get; set; }

    }
}

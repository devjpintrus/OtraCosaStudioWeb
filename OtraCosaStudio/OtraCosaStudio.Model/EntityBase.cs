using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtraCosaStudio.Model
{
    public abstract partial class EntityBase
    {
        [Required]
        public bool FlagActive { get; set; }

        [Required]
        public bool FlagDelete { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string CreateBy { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }


        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        private Type GetUnproxiedType()
        {
            return GetType();
        }

        [NotMapped]
        public string State
        {
            get { return FlagActive ? "Activo" : "Inactivo"; }
        }

        [NotMapped]
        public string CreateDateStr
        {
            get { return this.CreateDate.ToString("dd/MM/yyyy"); }
        }
        [NotMapped]
        public string ModifyDateStr
        {
            get { return ModifyDate == null ? "" : this.ModifyDate.Value.ToString("dd/MM/yyyy"); }
        }
    }
}

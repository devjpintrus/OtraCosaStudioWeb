using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OtraCosaStudio.Model
{

    [Table("Film")]
    public class Film : EntityBase
    {
        public int FilmId { get; set; }
        public string Name { get; set; }


    }

  
}

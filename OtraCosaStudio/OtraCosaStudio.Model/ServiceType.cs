using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtraCosaStudio.Model
{
    [Table("ServiceType")]
    public class ServiceType : EntityBase
    {
        public int ServiceTypeId { get; set; }
        public string Name { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtraCosaStudio.Model.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string SecondaryName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }

        public string CellPhone { get; set; }
        public int DocumentTypeId { get; set; }

        public string DocumentStr { get; set; }

        public bool FlagActive { get; set; }

        public bool FlagDelete { get; set; }

        public string CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        public string State
        {
            get { return FlagActive ? "Activo" : "Inactivo"; }
        }

        public string CreateDateStr
        {
            get { return this.CreateDate.ToString("dd/MM/yyyy"); }
        }

    }

}

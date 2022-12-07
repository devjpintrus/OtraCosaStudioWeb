using OtraCosaStudio.Model;
using OtraCosaStudio.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtraCosaStudio.Services.Interfaces
{
    public abstract partial class UserSvc : ServiceProvider
    {
        public abstract List<UserDto> ToListUser();
        public abstract User FindUserById(int Id);
        public abstract int RegisterUser(User objUser);
        public abstract int UpdateUser(User objUser);
        public abstract int DeleteUser(int Id);
    }

}

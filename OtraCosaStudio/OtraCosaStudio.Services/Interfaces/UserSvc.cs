using OtraCosaStudio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtraCosaStudio.Services.Interfaces
{
    public abstract partial class UserSvc : ServiceProvider
    {
        public abstract List<User> ToListUser();
    }

}

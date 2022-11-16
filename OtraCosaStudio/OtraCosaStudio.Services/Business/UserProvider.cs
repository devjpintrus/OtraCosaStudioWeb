using OtraCosaStudio.Infrastructure.Persistence;
using OtraCosaStudio.Infrastructure.Repositories;
using OtraCosaStudio.Model;
using OtraCosaStudio.Services.Interfaces;
using OtraCosaStudio.Util.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtraCosaStudio.Services.Business
{
    class UserProvider: UserSvc
    {
        public override List<User> ToListUser()
        {
            try
            {
                using (var ctx = new ControlContext())
                {
                    IRepositorio<User> rep = new EfRepositorio<User>(ctx); 


                    var lista = (from a in rep.Table 
                                 select a).ToList();

                    return lista;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.ManageException(ex);
                throw new ITSException(ITSExceptionIds.ErrorAvatar
                        , "Error en el metodo: ListarBanner(string pagina)."
                        , new object[] { null });
            }
        }
    }
}

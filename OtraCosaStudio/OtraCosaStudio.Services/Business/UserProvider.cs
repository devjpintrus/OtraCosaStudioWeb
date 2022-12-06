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
                throw new ITSException(ITSExceptionIds.ErrorSistema
                        , "Error en el metodo: ToListUser()."
                        , new object[] { null });
            }
        }


        public override int RegisterUser(User objUser)
        {
            try
            {
                using (var ctx = new ControlContext())
                {
                    objUser.CreateBy = "admin";
                    objUser.FlagActive = true;
                    objUser.CreateDate = DateTime.Now;
                    ctx.Entry(objUser).State = System.Data.Entity.EntityState.Added;
                    ctx.Set<User>().Add(objUser);

                    ctx.SaveChanges();

                    return objUser.UserId;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.ManageException(ex);
                throw new ITSException(ITSExceptionIds.ErrorSistema
                        , "Error en el metodo:RegisterUser(User objUser)."
                        , new object[] { null });
            }
        }


    }
}

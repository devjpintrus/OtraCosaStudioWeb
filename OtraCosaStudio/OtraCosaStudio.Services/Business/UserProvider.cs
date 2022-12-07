using OtraCosaStudio.Infrastructure.Persistence;
using OtraCosaStudio.Infrastructure.Repositories;
using OtraCosaStudio.Model;
using OtraCosaStudio.Model.Dto;
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
        public override List<UserDto> ToListUser()
        {
            try
            {
                using (var ctx = new ControlContext())
                {
                    IRepositorio<User> rep = new EfRepositorio<User>(ctx); 
                    IRepositorio<DocumentType> repdoc = new EfRepositorio<DocumentType>(ctx); 

                    var list = (from a in rep.Table  
                                 join b in repdoc.Table on a.DocumentTypeId equals b.DocumentTypeId
                                 select new
                                 {
                                     a.UserId,
                                     a.FirstName,
                                     a.SecondaryName,
                                     a.LastName,
                                     a.MiddleName,
                                     a.Email,
                                     a.CellPhone,
                                     a.CreateBy,
                                     a.CreateDate,
                                     a.FlagActive,
                                     DocumentStr = b.Name,
                                     a.DocumentTypeId
                                 });

                    var listlast = (from a in list
                                    group a by new
                                    {
                                        a.UserId,
                                        a.FirstName,
                                        a.SecondaryName,
                                        a.LastName,
                                        a.MiddleName,
                                        a.Email,
                                        a.CellPhone,
                                        a.CreateBy,
                                        a.CreateDate,
                                        a.FlagActive,
                                        a.DocumentStr,
                                        a.DocumentTypeId
                                    } into grp
                                    select new UserDto
                                    {
                                        UserId         = grp.Key.UserId,
                                        FirstName      = grp.Key.FirstName,
                                        SecondaryName  = grp.Key.SecondaryName,
                                        LastName       = grp.Key.LastName,
                                        MiddleName     = grp.Key.MiddleName,
                                        Email          = grp.Key.Email,
                                        CellPhone      = grp.Key.CellPhone,
                                        CreateBy       = grp.Key.CreateBy,
                                        CreateDate     = grp.Key.CreateDate,
                                        FlagActive     = grp.Key.FlagActive,
                                        DocumentStr    = grp.Key.DocumentStr,
                                        DocumentTypeId = grp.Key.DocumentTypeId
                                    }).ToList();

                    return listlast;
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


        public override User FindUserById(int Id)
        {
            try
            {
                using (var ctx = new ControlContext())
                {
                    IRepositorio<User> rep = new EfRepositorio<User>(ctx);


                    var objBD = (from a in ctx.Set<User>()
                                 where a.UserId == Id
                                 select a).FirstOrDefault();

                    return objBD;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.ManageException(ex);
                throw new ITSException(ITSExceptionIds.ErrorSistema
                        , "Error en el metodo: FindUserById(int Id)."
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



        public override int UpdateUser(User objUser)
        {
            try
            {
                using (var ctx = new ControlContext())
                {
                    var objBD = FindUserById(objUser.UserId);

                    if (objBD != null)
                    { 
                        objBD.ModifyBy = "admin";
                        objBD.FlagActive = objUser.FlagActive;
                        objBD.ModifyDate = DateTime.Now;

                        objBD.FirstName = objUser.FirstName;
                        objBD.SecondaryName = objUser.SecondaryName;
                        objBD.LastName = objUser.LastName;
                        objBD.MiddleName = objUser.MiddleName;
                        objBD.Email = objUser.Email;
                        objBD.CellPhone = objUser.CellPhone;
                        objBD.DocumentTypeId = objUser.DocumentTypeId;
                        if (objBD.FlagActive)
                        {
                            objBD.FlagDelete = false;
                        }

                        ctx.Entry(objBD).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                    }

                    return objUser.UserId;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.ManageException(ex);
                throw new ITSException(ITSExceptionIds.ErrorSistema
                        , "Error en el metodo:UpdateUser(User objUser)."
                        , new object[] { null });
            }
        }



        public override int DeleteUser(int Id)
        {
            try
            {
                using (var ctx = new ControlContext())
                {
                    IRepositorio<User> rep = new EfRepositorio<User>(ctx);

                    var objBD = FindUserById(Id);

                    if (objBD != null)
                    {
                        objBD.ModifyBy = "admin";
                        objBD.FlagActive = false;
                        objBD.FlagDelete = true;
                        objBD.ModifyDate = DateTime.Now;

                        ctx.Entry(objBD).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                    }

                    return Id;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.ManageException(ex);
                throw new ITSException(ITSExceptionIds.ErrorSistema
                        , "Error en el metodo:DeleteUser(int id)."
                        , new object[] { null });
            }
        }


    }
}

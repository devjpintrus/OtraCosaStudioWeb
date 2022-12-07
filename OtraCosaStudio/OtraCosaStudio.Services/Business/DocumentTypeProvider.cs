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
    class DocumentTypeProvider: DocumentTypeSvc
    {
        public override List<DocumentType> ToListDocumentType()
        {
            try
            {
                using (var ctx = new ControlContext())
                {
                    IRepositorio<DocumentType> rep = new EfRepositorio<DocumentType>(ctx); 

                    var lista = (from a in rep.Table  
                                 select a).ToList();

                    return lista;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.ManageException(ex);
                throw new ITSException(ITSExceptionIds.ErrorSistema
                        , "Error en el metodo: ToListDocumentType()."
                        , new object[] { null });
            }
        }


        public override DocumentType FindDocumentTypeById(int Id)
        {
            try
            {
                using (var ctx = new ControlContext())
                {
                    IRepositorio<DocumentType> rep = new EfRepositorio<DocumentType>(ctx);


                    var objBD = (from a in ctx.Set<DocumentType>()
                                 where a.DocumentTypeId == Id
                                 select a).FirstOrDefault();

                    return objBD;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.ManageException(ex);
                throw new ITSException(ITSExceptionIds.ErrorSistema
                        , "Error en el metodo: FindDocumentTypeById(int Id)."
                        , new object[] { null });
            }
        }
        


        public override int RegisterDocumentType(DocumentType objDocumentType)
        {
            try
            {
                using (var ctx = new ControlContext())
                {
                    objDocumentType.CreateBy = "admin";
                    objDocumentType.FlagActive = true;
                    objDocumentType.CreateDate = DateTime.Now;
                    ctx.Entry(objDocumentType).State = System.Data.Entity.EntityState.Added;
                    ctx.Set<DocumentType>().Add(objDocumentType);

                    ctx.SaveChanges();

                    return objDocumentType.DocumentTypeId;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.ManageException(ex);
                throw new ITSException(ITSExceptionIds.ErrorSistema
                        , "Error en el metodo:RegisterDocumentType(DocumentType objDocumentType)."
                        , new object[] { null });
            }
        }



        public override int UpdateDocumentType(DocumentType objDocumentType)
        {
            try
            {
                using (var ctx = new ControlContext())
                {
                    var objBD = FindDocumentTypeById(objDocumentType.DocumentTypeId);

                    if (objBD != null)
                    { 
                        objBD.ModifyBy = "admin";
                        objBD.FlagActive = objDocumentType.FlagActive;
                        objBD.ModifyDate = DateTime.Now;

                        objBD.Name = objDocumentType.Name;
                        objBD.Digits = objDocumentType.Digits;

                        if (objBD.FlagActive)
                        {
                            objBD.FlagDelete = false;
                        }

                        ctx.Entry(objBD).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                    }

                    return objDocumentType.DocumentTypeId;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.Instance.ManageException(ex);
                throw new ITSException(ITSExceptionIds.ErrorSistema
                        , "Error en el metodo:UpdateDocumentType(DocumentType objDocumentType)."
                        , new object[] { null });
            }
        }



        public override int DeleteDocumentType(int Id)
        {
            try
            {
                using (var ctx = new ControlContext())
                {
                    IRepositorio<DocumentType> rep = new EfRepositorio<DocumentType>(ctx);

                    var objBD = FindDocumentTypeById(Id);

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
                        , "Error en el metodo:DeleteDocumentType(int id)."
                        , new object[] { null });
            }
        }


    }
}

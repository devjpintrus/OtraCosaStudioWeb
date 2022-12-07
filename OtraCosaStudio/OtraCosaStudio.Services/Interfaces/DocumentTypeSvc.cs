using OtraCosaStudio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtraCosaStudio.Services.Interfaces
{
    public abstract partial class DocumentTypeSvc : ServiceProvider
    {
        public abstract List<DocumentType> ToListDocumentType();
        public abstract DocumentType FindDocumentTypeById(int Id);
        public abstract int RegisterDocumentType(DocumentType objDocumentType);
        public abstract int UpdateDocumentType(DocumentType objDocumentType);
        public abstract int DeleteDocumentType(int Id);
    }

}

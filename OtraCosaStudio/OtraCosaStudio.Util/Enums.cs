using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtraCosaStudio.Util
{
    public enum ESesion : int
    {
        SessionCaducada = 401,
    }
    public enum CodigoRetorno : int
    {
        SinDatos = -1,
        [Description("Se produjo un error al {0}.")]
        Error = 0,
        [Description("El {0} se {1} con éxito.")]
        Exito = 1,
        [Description("El {0} ingresado no existe.")]
        RegistroNoExiste = 2,
        [Description("El {0} ingresado no se encuentra activo.")]
        RegistroInactivo = 3,
        [Description("El {0} ingresado existe.")]
        RegistroExiste = 4,
    }
}

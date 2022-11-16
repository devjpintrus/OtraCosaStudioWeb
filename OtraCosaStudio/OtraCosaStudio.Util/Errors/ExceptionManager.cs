using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtraCosaStudio.Util.Errors
{
    public sealed class ExceptionManager
    {
        private static readonly Lazy<ExceptionManager> lazy =
            new Lazy<ExceptionManager>(() => new ExceptionManager());

        /// <summary>
        /// Asociado a la entrada Errores.RutaArchivo en la sección appSettings
        /// </summary>
        private static string _RutaFichero = Util.Get<string>("Aplication.Log");
        /// <summary>
        /// Asociado a la entrada Errores.NombreSource en la sección appSettings
        /// </summary>
        private static string _NombreSource = Util.Get<string>("Errores.NombreSource");
        /// <summary>
        /// Asociado a la entrada Errores.RegistroEventos en la sección appSettings
        /// </summary>
        private static bool _RegistroHabilitado = Util.Get<bool>("Errores.RegistroEventos");

        private static string _NombreEvent = "Application";

        public static ExceptionManager Instance { get { return lazy.Value; } }

        private ExceptionManager()
        {

        }

        public void ManageException(Exception ex)
        {
            if (_RegistroHabilitado)
            {

                ObtenerInformacionExcepcion(ex);
            }
        }

        //public ITSCapacitacionesException GetITSCapacitacionesException(Exception ex)
        //{
        //    if(_RegistroHabilitado)
        //    {
        //        ObtenerInformacionExcepcion(ex);
        //    }
        //    return new ITSCapacitacionesException(ex
        //        , (int)Identificadores.ErrorAplicativo
        //        , ex.Message
        //        , null);
        //}

        private void ObtenerInformacionExcepcion(Exception ex)
        {
            if (ex.Message != "Thread was being aborted.")
            {
                FormatMessage mensaje = new FormatMessage();
                mensaje.Titulo = "Se ha producido un error en la aplicación";
                mensaje.Detalle = "Se ha producido un error en un componente de la aplicación.";
                mensaje.Acciones = "Revise el log de errores para un mayor detalle del mismo, y para que pueda iniciar acciones para su pronta corrección.";

                this.AgregarInformacionException(mensaje, ex);

                this.RegistrarArchivo(mensaje);
            }
        }

        private void AgregarInformacionException(FormatMessage mensaje
                , Exception excepcion)
        {
            int contExcepcionInterna = 0;
            Exception excepcionInterna;
            string tituloExcepcionInterna;

            mensaje.AgregarDatoAdicional("Exception.Type", excepcion.GetType().Name.ToString());
            mensaje.AgregarDatoAdicional("Exception.Message", excepcion.Message);
            mensaje.AgregarDatoAdicional("Exception.Source", excepcion.Source);

            excepcionInterna = excepcion.InnerException;
            while (excepcionInterna != null)
            {
                contExcepcionInterna++;

                tituloExcepcionInterna = string.Format("Exception.InnerException{0}", contExcepcionInterna);

                mensaje.AgregarDatoAdicional(tituloExcepcionInterna + ".Type", excepcion.InnerException.GetType().Name);
                mensaje.AgregarDatoAdicional(tituloExcepcionInterna + ".Message", excepcion.InnerException.Message.ToString());
                mensaje.AgregarDatoAdicional(tituloExcepcionInterna + ".Source", excepcion.InnerException.Source != null ? excepcion.InnerException.Source.ToString() : "");

                excepcionInterna = excepcionInterna.InnerException;
            }

            mensaje.AgregarDatoAdicional("Exception.StackTrace", excepcion.StackTrace.ToString());
        }

        private void RegistrarEventLog(FormatMessage mensaje)
        {
            using (var log = new EventLog(_NombreEvent, ".", _NombreSource))
            {
                log.Close();
            }
        }

        private void RegistrarArchivo(FormatMessage mensaje)
        {
            string archivoLog = string.Format("ITSException_Logs_{0}{1}{2}.txt", System.DateTime.Now.Year.ToString(), System.DateTime.Now.Month.ToString("00"), System.DateTime.Now.Day.ToString("00"));
            string rutaArchivo = string.Concat(_RutaFichero, archivoLog);

            using (StreamWriter sw = new StreamWriter(rutaArchivo, true))
            {
                sw.WriteLine(mensaje.ToString());
                sw.WriteLine();
                sw.Flush();
                sw.Close();
            }
        }
    }
}

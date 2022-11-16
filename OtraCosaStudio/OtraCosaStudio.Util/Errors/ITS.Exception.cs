using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtraCosaStudio.Util.Errors
{
   public enum ITSExceptionIds : int
    {
        ErrorParticipante = 1,
        ErrorLiga = 2,
        ErrorBono = 3,
        ErrorForo = 4,
        ErrorNotificacion = 5,
        ErrorCompetencia = 6,
        ErrorAvatar = 7,
        ErrorLogin = 8,
        ErrorPronostico = 9,
    }

    [Serializable]
    public class ITSException : Exception
    {
        
       /// <summary>
        /// Obtiene o establece el id del ITSExceptionIds lanzado
        /// </summary>
        public ITSExceptionIds Id { get; set; }

        /// <summary>
        /// Obtiene o establece el arreglo de datos adicionales que se pueden agregar al detalle de la excepción
        /// </summary>
        public object[] Datos { get; set; }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ITSException() { }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="id">Tipo de excepción</param>
        /// <param name="message">Mensaje informativo de la excepción</param>
        /// <param name="datos">Datos adicionales de la excepción</param>
        public ITSException(ITSExceptionIds id, string message, object[] datos) : this(id, message, datos, null) { }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="id">Tipo de excepción</param>
        /// <param name="message">Mensaje informativo de la excepción</param>
        /// <param name="datos">Datos adicionales de la excepción</param>
        /// <param name="inner">Excepción base generada</param>
        public ITSException(ITSExceptionIds id, string message, object[] datos, Exception inner)
            : base(message, inner)
        {
            Id = id;
            Datos = datos;
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="info">SerializationInfo</param>
        /// <param name="context">StreamingContext</param>
        protected ITSException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }   
}

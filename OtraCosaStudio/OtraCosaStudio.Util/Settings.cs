using Microsoft.Security.Application;
using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection; 

namespace OtraCosaStudio.Util
{
    public class Settings
    {
        public static T Get<T>(string key)
        {
            var appSetting = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrWhiteSpace(appSetting)) return default(T);

            var converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)(converter.ConvertFromInvariantString(appSetting));
        }

        public static string GetConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["BDModel"].ConnectionString;
            }
        }

        public static string GetDirectory(string key)
        {
            var ruta = Settings.Get<string>("RutaCarpetaLogGeneral");
            Directory.CreateDirectory(ruta);
            return ruta;
        }


        public T EncodeEntity<T>(object obj)
        {

            Type firstType = obj.GetType();

            foreach (PropertyInfo propertyInfo in firstType.GetProperties())
            {
                if (propertyInfo.CanRead && propertyInfo.CanWrite && propertyInfo.PropertyType == typeof(string))
                {
                    object value = propertyInfo.GetValue(obj, null);
                    if (value != null)
                    {
                        //propertyInfo.SetValue(obj, Encoder.HtmlEncode(value.ToString()));
                        propertyInfo.SetValue(obj, "");
                    }
                }
            }
            return (T)obj;
        }

        public static string EncodeString(string str)
        {
            if (str != null)
            {
                //var nuevostring = Encoder.HtmlEncode(str.ToString());

                //if (nuevostring.ToUpper().Contains("HTTPS"))
                //{
                //    nuevostring = nuevostring.Replace("https", "https  ");
                //}

                //if (nuevostring.ToUpper().Contains("WWW"))
                //{
                //    nuevostring = nuevostring.ToLower().Replace("www", "www  ");
                //}
                return "";
            }
            else
            {
                return "";
            }
        }

        public static string ReplaceLinkString(string str)
        {
            if (str != null)
            {
                if (str.ToUpper().Contains("HTTPS"))
                {
                    str = str.Replace("https", "https  ");

                }

                if (str.ToUpper().Contains("WWW"))
                {
                    str = str.ToLower().Replace("www", "www  ");
                }

                return str;
            }
            else
            {
                return "";
            }
        }

        public string EncodeEntity(object obj, string columna)
        {
            var strTexto = "";
            Type firstType = obj.GetType();

            foreach (PropertyInfo propertyInfo in firstType.GetProperties())
            {
                if (propertyInfo.CanRead && propertyInfo.CanWrite)
                {
                    if (propertyInfo.Name == columna)
                    {
                        //strTexto = propertyInfo.Get(columna, null);
                        //if (value != null)
                        //{
                        //    propertyInfo.SetValue(obj, Encoder.HtmlEncode(value.ToString()));
                        //}
                    }
                }
            }
            return strTexto;
        }

    }
}

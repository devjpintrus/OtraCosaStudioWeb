using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace OtraCosaStudio.Util
{
    public class Util
    {
        public static IEnumerable<T> EnumToList<T>()
        {
            Type enumType = typeof(T);

            // Can't use generic type constraints on value types,
            // so have to do check like this
            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T must be of type System.Enum");

            Array enumValArray = Enum.GetValues(enumType);
            List<T> enumValList = new List<T>(enumValArray.Length);

            foreach (int val in enumValArray)
            {
                enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
            }

            return enumValList;
        }
        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description.ToUpper() == description.ToUpper())
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description.ToUpper())
                        return (T)field.GetValue(null);
                }
            }
            //throw new ArgumentException("Not found.", "description");
            return default(T);
        }

        public static T Get<T>(string key)
        {
            var appSetting = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrWhiteSpace(appSetting)) return default(T);

            var converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)(converter.ConvertFromInvariantString(appSetting));
        }
        public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s)) { return string.Empty; }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
        public static int NumberOfWeeksBetweenDates(DateTime StarDate, DateTime EndDate)
        {
            if (StarDate > EndDate) return -1;

            int NumeroSemanas = 1;

            DateTime lunes = FirstDayOfWeek(StarDate).AddDays(7);

            while (lunes < EndDate)
            {
                lunes = lunes.AddDays(7);
                NumeroSemanas++;
            }

            return NumeroSemanas;
        }
        public static DateTime FirstDayOfWeek(DateTime date)
        {
            var candidateDate = date;
            while (candidateDate.DayOfWeek != DayOfWeek.Monday)
            {
                candidateDate = candidateDate.AddDays(-1);
            }
            return candidateDate;
        }
        public static DateTime EndDayOfWeek(DateTime date)
        {
            var candidateDate = date;
            while (candidateDate.DayOfWeek != DayOfWeek.Sunday)
            {
                candidateDate = candidateDate.AddDays(1);
            }
            return candidateDate;
        }

        public static int ObtenerMes(string nombreMes)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("ENERO", 1);
            dictionary.Add("FEBRERO", 2);
            dictionary.Add("MARZO", 3);
            dictionary.Add("ABRIL", 4);
            dictionary.Add("MAYO", 5);
            dictionary.Add("JUNIO", 6);
            dictionary.Add("JULIO", 7);
            dictionary.Add("AGOSTO", 8);
            dictionary.Add("SEPTIEMBRE", 9);
            dictionary.Add("OCTUBRE", 10);
            dictionary.Add("NOVIEMBRE", 11);
            dictionary.Add("DICIEMBRE", 12);

            var item = dictionary.FirstOrDefault(p => p.Key == nombreMes.ToUpper().Trim());
            return item.Value;
        }
        public static string ObtenerMesstring(int mes)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("ENERO", 1);
            dictionary.Add("FEBRERO", 2);
            dictionary.Add("MARZO", 3);
            dictionary.Add("ABRIL", 4);
            dictionary.Add("MAYO", 5);
            dictionary.Add("JUNIO", 6);
            dictionary.Add("JULIO", 7);
            dictionary.Add("AGOSTO", 8);
            dictionary.Add("SEPTIEMBRE", 9);
            dictionary.Add("OCTUBRE", 10);
            dictionary.Add("NOVIEMBRE", 11);
            dictionary.Add("DICIEMBRE", 12);

            var item = dictionary.FirstOrDefault(p => p.Value == mes);
            return item.Key;
        }


        public static string CadenaConexion
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["BDModel"].ConnectionString;
            }
        }

    }
}

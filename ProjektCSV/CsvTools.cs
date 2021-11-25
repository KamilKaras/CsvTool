using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjektCSV
{
    public static class CsvTools 
    {
        public static void AppendToCsvFile<T>(List<T> list, string filePath, string separator)
        {
            var fileHeaders = GetClassPropetiesString<T>(separator);
            File.WriteAllText(filePath, fileHeaders + Environment.NewLine);
            foreach(var line in list)
            {
                var dataToAppend = string.Empty;
                dataToAppend = string.Join(separator, GetColectionValues(line));
                File.AppendAllText(filePath, dataToAppend + Environment.NewLine);
            }
            
        }
        public static string ReadCsv(string filePath, string separator)
        {
            var sbRead = new StringBuilder();
            var lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (line == string.Empty)
                {
                    return "Csv file empty";
                }
                var cleanLine = line.Replace(separator, " ");
                sbRead.Append(cleanLine + "\n");
            }
            return sbRead.ToString();
        }
        private static string GetClassPropetiesString<T>(string separator)
        {
            var columnNames = typeof(T).GetProperties().Select(p => p.Name);
            var columnNamesString = string.Join(separator, columnNames);
            return columnNamesString;
        }
        private static List<string> GetColectionValues<T>(T element) 
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance); 
            var data = properties
                .Select(p => DataFormat(element, p))
                .ToList();
            return data;
        }
        private static string DataFormat<T>(T obiekt, PropertyInfo p)
        {
            var value = p.GetValue(obiekt, null);
            if (value == null)
            {
                return string.Empty;
            }

            var valueToReturn = (value is DateTime
                ? Convert.ToDateTime(value).ToString(format:"d")
                : value?.ToString())
                .Trim();

            return valueToReturn;
        }
    }    
}

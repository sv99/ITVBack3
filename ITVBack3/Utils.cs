using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ITVBack
{
    class Utils
    {
        // Формат даты в папке dd-mm-yy hh - hh это час начиная с 0-23 
        public static string getNormalFolderName(string folder)
        {
            string fileName = Path.GetFileName(folder);
            Debug.Assert(fileName != null, "fileName != null");
            return fileName.Substring(6, 2) + '-' + fileName.Substring(3, 2) + '-'
              + fileName.Substring(0, 2) + ' ' + fileName.Substring(9, 2);
        }

        public static string getFolderHour(string folder)
        {
            string fileName = Path.GetFileName(folder);
            Debug.Assert(fileName != null, "fileName != null");
            return fileName.Substring(9, 2);
        }

        public static DateTime getFolderDate(string folder)
        {
            string fileName = Path.GetFileName(folder);
            Debug.Assert(fileName != null, "fileName != null");
            return new DateTime(2000 + Int32.Parse(fileName.Substring(6, 2)), Int32.Parse(fileName.Substring(3, 2)), Int32.Parse(fileName.Substring(0, 2)));
        }

        public static string ArrayToStringGeneric<T>(IList<T> array, string delimeter)
        {
            string outputString = "";

            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] is IList<T>)
                {
                    //Recursively convert nested arrays to string
                    outputString += ArrayToStringGeneric<T>((IList<T>)array[i], delimeter);
                }
                else
                {
                    outputString += array[i];
                }

                if (i != array.Count - 1)
                    outputString += delimeter;
            }

            return outputString;
        }
    }
}

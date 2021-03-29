using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace WebApi.Common
{
    public static class CSVUtil
    {
        public static byte[] ToCsv<T>(this IEnumerable<T> collection)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(collection);
                } 

                return memoryStream.ToArray();
            }
        }
    }
}

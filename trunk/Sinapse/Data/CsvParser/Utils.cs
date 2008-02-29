/***************************************************************************
 * This class was based in a work from someone else. If you are the        *
 * author of this class, please email me so I can credit you properly      *
 *                                                                         *
 * http://sinapse.googlecode.com                 cesarsouza@gmail.com      *
 ***************************************************************************/

using System;
using System.IO;
using System.Text;

namespace Sinapse.Data.CsvParser
{
    public sealed class CsvUtils
    {

        public static CsvDelimiter DetectFieldDelimiterChar(string filename, System.Text.Encoding encoding)
        {
            TextReader textReader = null;
            CsvDelimiter delimiter;

            try
            {
                textReader = new StreamReader(filename, encoding);
                delimiter = DetectFieldDelimiterChar(textReader.ReadLine());

            }
            catch (Exception e)
            {
                delimiter = CsvDelimiter.Comma;
                throw e;
            }
            finally
            {
                if (textReader != null)
                {
                    textReader.Close();
                    textReader.Dispose();
                }
            }
           
            return delimiter;
        }

        public static CsvDelimiter DetectFieldDelimiterChar(string headerLine)
        {
            int maxCount = 0;
            int curCount = 0;
            CsvDelimiter maxDelimiter = CsvDelimiter.Comma;

            foreach (CsvDelimiter delimiter in Enum.GetValues(typeof(CsvDelimiter)))
            {
                
                curCount = headerLine.Split((char)delimiter).Length;
                if (curCount > maxCount)
                {
                    maxCount = curCount;
                    maxDelimiter = delimiter;
                }
            }

            return maxDelimiter;
        }


        //---------------------------------------------


        public static string[] GetHeaders(string filename, CsvDelimiter delimiter)
        {
            TextReader textReader = null;
            String textHeader;

            try
            {
                textReader = new StreamReader(filename, Encoding.Default);
                textHeader = textReader.ReadLine();
            }
            catch (Exception e)
            {
                textHeader = String.Empty;
                throw e;
            }
            finally
            {
                if (textReader != null)
                {
                    textReader.Close();
                    textReader.Dispose();
                }
            }

            while (textHeader.IndexOf('"') >= 0)
            {
                textHeader = textHeader.Remove(textHeader.IndexOf('"'), 1);
            }

            return textHeader.Split((char)delimiter);
        }

    }
}

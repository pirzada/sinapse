using System;
using System.IO;
using System.Data;

namespace cSouza.Framework.File.CSV
{

    public sealed class CsvWriter
    {
        public static string WriteToString(DataTable table, bool header, bool quoteall, char delimiter)
        {
            StringWriter writer = new StringWriter();
            WriteToStream(writer, table, header, quoteall, delimiter);
            return writer.ToString();
        }

        public static void WriteToFile(DataTable table, bool header, bool quoteall, char delimiter, string filename, bool append, System.Text.Encoding encoding)
        {
            TextWriter tr = null;
            try
            {
                tr = new StreamWriter(filename, append, encoding);
                tr.Write(WriteToString(table, header, quoteall, delimiter));
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (tr != null)
                {
                    tr.Close();
                    tr.Dispose();
                }
            }
        }

        public static void WriteToStream(TextWriter stream, DataTable table, bool header, bool quoteall, char delimiter)
        {
            if (header)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    WriteItem(stream, table.Columns[i].Caption, quoteall);
                    if (i < table.Columns.Count - 1)
                        stream.Write(delimiter);
                    else
                        stream.Write('\n');
                }
            }
            //foreach (DataRow row in table.Rows)
            for (int j = 0;j<table.Rows.Count;j++)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                	WriteItem(stream, table.Rows[j][i], quoteall);
                    if (i < table.Columns.Count - 1)
                        stream.Write(delimiter);
                    else
                        stream.Write('\n');
                }
            }
        }

        private static void WriteItem(TextWriter stream, object item, bool quoteall)
        {
            if (item == null)
                return;
            string s = item.ToString();
            if (quoteall || s.IndexOfAny("\",\x0A\x0D".ToCharArray()) > -1)
                stream.Write("\"" + s.Replace("\"", "\"\"") + "\"");
            else
                stream.Write(s);
        }
    }
}




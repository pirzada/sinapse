using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Data.CsvParser
{

    public sealed class CsvFileParserOptions
    {

        public CsvFileParserOptions(string filename)
        {
            this.Filename = filename;
            this.Encoding = System.Text.Encoding.Default;
            this.AutoDetectCsvDelimiter = false;
            this.CsvDelimiter = CsvDelimiter.Comma;
            this.HeadersAction = CsvHeadersAction.UseAsColumnNames;
        }

        public string Filename;
        public System.Text.Encoding Encoding;
        public CsvHeadersAction HeadersAction;
        public CsvDelimiter CsvDelimiter;
        public bool AutoDetectCsvDelimiter;

    }

    public sealed class CsvFileWriterOptions
    {
        public CsvFileWriterOptions(string filename)
        {

        }
    }

    public enum CsvHeadersAction
    {
        SkipHeaderLine,
        UseAsColumnNames,
        UseAsContent,
    }

    public enum CsvDelimiter
    {
        Comma = ',',
        SemiColon = ';',
        Space = ' ',
        Tabulation = '\t',
    }
    
}

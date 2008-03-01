/***************************************************************************
 * This class was based in a work from someone else. If you are the        *
 * author of this class, please email me so I can credit you properly      *
 *                                                                         *
 * http://sinapse.googlecode.com                 cesarsouza@gmail.com      *
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Utils.CsvParser
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
        Semicolon = ';',
        Space = ' ',
        Tabulation = '\t',
    }
    
}

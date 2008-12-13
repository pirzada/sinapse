/***************************************************************************
 * This class was based in a work from someone else. If you are the        *
 * author of this class, please email me so I can credit you properly      *
 *                                                                         *
 *  This said, this project license does not apply to this library.        *
 *  Please contact the class author for more info about licensing          *
 *                                                                         *
 * http://sinapse.googlecode.com                 cesarsouza@gmail.com      *
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace Sinapse.Databases.Csv
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

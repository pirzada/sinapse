using System;

namespace cSouza.Framework.File.CSV
{
	/// <summary>
	/// Description of Options.
	/// </summary>
	public sealed class CsvFileParserOptions {

		public CsvFileParserOptions(string filename) {
			this.Filename = filename;
			this.Encoding = System.Text.Encoding.Default;
            this.AutoDetectCsvDelimiter = false;
			this.CsvDelimiter = '\t';
			this.HeadersAction = HeadersAction.UseAsColumnNames;
		}
        		
		public string Filename;
		public System.Text.Encoding Encoding;
		public CSV.HeadersAction HeadersAction;
		public char CsvDelimiter;
        public bool AutoDetectCsvDelimiter;
	
	}
	
	public sealed class CsvFileWriterOptions {
		public CsvFileWriterOptions(string filename) {
			
		}
	}

	public enum HeadersAction {
        SkipHeaderLine,
        UseAsColumnNames,
        UseAsContent,
    }
}

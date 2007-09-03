using System;
using System.IO;
using System.Text;

namespace cSouza.Framework.File.CSV
{
    public sealed class CsvUtils
    {

        public static char DetectFieldDelimiterChar(string filename, System.Text.Encoding encoding)
        {
            TextReader tr = null;
            Char delimiter;
            try
            {
                tr = new StreamReader(filename, encoding);
                delimiter = DetectFieldDelimiterChar(tr.ReadLine());

            }
            catch (Exception e)
            {
                delimiter = '\t';
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
            return delimiter;
        }
    	
    	public static string[] getHeaders(string filename, System.Text.Encoding encoding) {
    		TextReader tr = null;
            String Headers;
            try
            {
                tr = new StreamReader(filename, encoding);
                Headers = tr.ReadLine();
            }
            catch (Exception e)
            {
                Headers = "";
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

    		while (Headers.IndexOf('"')>=0){
    			Headers = Headers.Remove(Headers.IndexOf('"'),1);
    		}
    		
    		char delimiter = DetectFieldDelimiterChar(Headers);

    		return Headers.Split(delimiter);
    	}
    	
    	public static char DetectFieldDelimiterChar(string Headers){
    		char FieldDelimiter = '\t';
            if (Headers.Contains(","))
            {
                FieldDelimiter = ',';
            }
            else if (Headers.Contains(";"))
            {
                FieldDelimiter = ';';
            }
            else if (Headers.Contains("."))
            {
                FieldDelimiter = '.';
            }
            return FieldDelimiter;
        
    	}
        	

        
    }
}

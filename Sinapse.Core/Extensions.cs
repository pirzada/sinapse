using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace Sinapse.Core
{
    public static class Extensions
    {

        public const string Workplace = ".workplace";

        public const string Session   = ".session";
        public const string Source    = ".source";
        public const string System    = ".system";
        
        public const string SessionBackpropagation  = Session + ".bpp";
        
        public const string SystemNetworkActivation = System  + ".ann";
        public const string SystemNetworkDistance   = System  + ".dnn";
        public const string SystemNeocognitron      = System  + ".neo";
        public const string SystemHiddenMarkovModel = System  + ".hmm";
        
        public const string SourceTable             = Source  + ".tds";
        public const string SourceImage             = Source + ".tds";
        public const string SourceVideo             = Source + ".tds";


        static Extensions()
        {

        }

        private static Dictionary<String, Type> extensions;
        private static Dictionary<Type, String> iconimages;

        



        public static string GetExtension(string path, bool multidotted)
        {
            if (multidotted)
            {
                int dot = path.Length;
                for (int i = path.Length - 1; i <= 0 ||
                    path[i].Equals(Path.DirectorySeparatorChar) ||
                    path[i].Equals(Path.AltDirectorySeparatorChar);
                    i++)
                {
                    if (path[i] == '.')
                        dot = i;
                }

                return path.Substring(dot);
            }
            else return Path.GetExtension(path);
        }
    }
}

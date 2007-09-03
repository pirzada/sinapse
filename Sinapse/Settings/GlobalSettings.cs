using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using cSouza.Framework.Data.XML;

namespace TrendView.Settings
{
    class GlobalSettings
    {

        #region Singleton Pattern Implementation
        private static GlobalSettings _instance;
        public static GlobalSettings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GlobalSettings();

                return _instance;
            }
        }
        #endregion

    //----------------------------------------

        #region Constructor
        private GlobalSettings()
        {
            settings_path = Application.UserAppDataPath + "settings.xml";
            database_path = Application.UserAppDataPath + "database.xml";
            GlobalSettings.Load(settings_path);
        }
        #endregion


        public string settings_path;
        public string database_path;
        public double ann_learningRate      = 0.1D;
        public double ann_learningMomentum  = 0D;


    //----------------------------------------

        #region Save & Load
        public static void Load(string path)
        {
            _instance = ObjectXMLSerializer<GlobalSettings>.Load(path);
        }

        public static void Save(string path)
        {
            ObjectXMLSerializer<GlobalSettings>.Save(_instance, path);
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ITVBack
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fmMain());
        }

        //declare and initialize the public static clsSettings object
        public static Profile profile = new Profile();

        /// <summary>
        /// Returns the settings file path
        /// </summary>
        /// <returns></returns>
        public static string GetSettingPath()
        {
            return Path.Combine(Application.StartupPath, "settings.xml");
        }

        public static void LoadSettings()
        {
            profile = File.Exists(GetSettingPath()) ? profile.Load(GetSettingPath()) : Profile.DefaultProfile();
        }

        public static void SaveSettings()
        {
            profile.Save(GetSettingPath());
        }
    }
}

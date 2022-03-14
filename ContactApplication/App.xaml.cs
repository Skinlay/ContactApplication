using System;
using System.Windows;

namespace ContactApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Link naar database
        static string strDatabaseName = "Contacts.db";
        static string strFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string strDatabasePath = System.IO.Path.Combine(strFolderPath, strDatabaseName);
    }
}

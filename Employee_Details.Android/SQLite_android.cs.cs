using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.IO;
using Employee_Details;
using Xamarin.Forms;

[assembly: Dependency(typeof(Employee_Details.Droid.SQLite_android))]
namespace Employee_Details.Droid
{

    public class SQLite_android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string filename = "Employee1.db";
            string dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            string path = Path.Combine(dbpath, filename);
            SQLiteConnection con = new SQLiteConnection(path);
            
            return con;
        }
    }
}
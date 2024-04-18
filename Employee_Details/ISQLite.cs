using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Employee_Details
{
    public interface ISQLite
    {
        
         SQLiteConnection GetConnection();



        
    }
}

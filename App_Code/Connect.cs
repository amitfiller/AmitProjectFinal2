using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

public class Connect
{
    const string FILE_NAME = "Matnas_Database.accdb";
    public static string GetConnectionString()
    {
        string location = HttpContext.Current.Server.MapPath("~/App_Data/" + FILE_NAME);
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; data source =" + location;
        return connectionString;
    }
}
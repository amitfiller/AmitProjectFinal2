using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WorkersPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            GridViewGuides.AllowPaging = true;
            GridViewGuides.PageSize = 5;
        }
    }
    public void BindTheGridView()
    {
        const string FILE_NAME = "Matnas_Database.accdb";
        string location = HttpContext.Current.Server.MapPath("~/App_Data/" + FILE_NAME);
        string connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0; data source=" + location;

       // string sql = "SELECT "
    }
       

    protected void Timetable_Click(object sender, EventArgs e)
    {
        Server.Transfer("TimetableGuide.aspx");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SetGuideToCourse_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == true)
        {
            DataService d = new DataService();
            d.SetGuideToCourse(GuideNameID.SelectedItem.Value.ToString(), CourseNameID.SelectedItem.Value.ToString());
            Server.Transfer("CoverPage.aspx");
        }
        else
        {
            message.Visible = true;
            message.Text = "Page is not valid";
            message.ForeColor = System.Drawing.Color.OrangeRed;
        }
    }
  
}
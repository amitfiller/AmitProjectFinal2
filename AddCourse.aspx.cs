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

    protected void AddCourse_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == true)
        {
            DataService d = new DataService();

            if (!d.IsCourseAlreadyExist(CourseName.Text))
            {
                d.AddCourse(CourseName.Text, Price.Text, Description.Text, RoomType.SelectedItem.Value.ToString());
                Server.Transfer("CoverPage.aspx");
            }
            else
            {
                message.Visible = true;
                message.Text = "Course name already exist.";
                message.ForeColor = System.Drawing.Color.OrangeRed;
            }
        }
        else
        {
            message.Visible = true;
            message.Text = "Page is not valid";
            message.ForeColor = System.Drawing.Color.OrangeRed;
        }
    }

    protected void AccessDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
}
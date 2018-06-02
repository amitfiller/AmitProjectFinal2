using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RankCourse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void CoursesList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataService d = new DataService();
        CourseDescription.Text = "Descroption: " + d.CourseDescriptionByCourseName(CoursesList.SelectedValue);
        NumParticipants.Text = "Number of Participants: " + d.NumParticipants(CoursesList.SelectedValue);
    }

    protected void SaveRank_Click(object sender, EventArgs e)
    {
        DataService d = new DataService();
        int courseCode = d.CourseCodeByCourseName(CoursesList.SelectedValue);     
    }
}
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
            BindGuideCourseGridView();
        }
    }
    public void BindGuideCourseGridView()
    {
        int guideCode = -1;
        if (Session["LoggedInGuideCode"] != null)
            guideCode = (int)Session["LoggedInGuideCode"];

        AccessDataSource DS = new AccessDataSource();
        DS.DataFile = "~/App_Data/Matnas_Database.accdb";

        DS.SelectCommand = @"SELECT Courses.CourseName, Rooms.RoomName, WorkingDays.Name, WorkingHours.HourName
                            FROM (((((TimeTable INNER JOIN
                         Rooms ON TimeTable.RoomCode = Rooms.RoomCode) INNER JOIN
                         WorkingDays ON TimeTable.[Day] = WorkingDays.DayCode) INNER JOIN
                         WorkingHours ON TimeTable.[Hour] = WorkingHours.HourCode) INNER JOIN
                         GuidesInCourses ON TimeTable.GuideCourseCode = GuidesInCourses.GuideCourseCode) INNER JOIN
                         Courses ON GuidesInCourses.CourseCode = Courses.CourseCode)
                         WHERE GuidesInCourses.GuideCode = " + guideCode + "";

        GridViewGuides.DataSource = DS;
        GridViewGuides.DataBind();

        if (GridViewGuides.Rows.Count > 0)
        {
            GridViewGuides.HeaderRow.Cells[0].Text = "Course Name";
            GridViewGuides.HeaderRow.Cells[1].Text = "Room name";
            GridViewGuides.HeaderRow.Cells[2].Text = "Day";
            GridViewGuides.HeaderRow.Cells[3].Text = "Hour"; 

        }

    }
       

    protected void Timetable_Click(object sender, EventArgs e)
    {
        Server.Transfer("TimetableGuide.aspx");
    }

    protected void GridViewGuides_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewGuides.PageIndex = e.NewPageIndex;
        BindGuideCourseGridView();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ParticipantsPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindStudentCourseGridView();
    }

    protected void JoinCourse_Click(object sender, EventArgs e)
    {
        Server.Transfer("JoinCourse.aspx");
    }
    
    protected void Rank_Click(object sender, EventArgs e)
    {
        Server.Transfer("RankCourse.aspx");
    }

    public void BindStudentCourseGridView()
    {
        int studentCode = -1;
        if (Session["LoggedInStudentCode"] != null) ;
            studentCode = (int)Session["LoggedInStudentCode"];

        AccessDataSource DS = new AccessDataSource();
        DS.DataFile = "~/App_Data/Matnas_Database.accdb";
        DS.SelectCommand = @"SELECT Courses.CourseName, Guides.FirstName, Guides.LastName, Rooms.RoomName, WorkingHours.HourName, WorkingDays.Name
                            FROM (((((((Courses INNER JOIN
                         GuidesInCourses ON Courses.CourseCode = GuidesInCourses.CourseCode) INNER JOIN
                         Guides ON GuidesInCourses.GuideCode = Guides.GuideCode) INNER JOIN
                         TimeTable ON GuidesInCourses.GuideCourseCode = TimeTable.GuideCourseCode) INNER JOIN
                         Rooms ON TimeTable.RoomCode = Rooms.RoomCode) INNER JOIN
                         WorkingDays ON TimeTable.[Day] = WorkingDays.DayCode) INNER JOIN
                         WorkingHours ON TimeTable.[Hour] = WorkingHours.HourCode) INNER JOIN
                         StudentsInCourse ON TimeTable.CourseTimeCode = StudentsInCourse.CourseTimeCode)
                        WHERE StudentsInCourse.StudentCode = " + studentCode + "";

        StudentCoursesGridView.DataSource = DS;
        StudentCoursesGridView.DataBind();
    }

    protected void StudentCoursesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        StudentCoursesGridView.PageIndex = e.NewPageIndex;
        BindStudentCourseGridView();
    }

    protected void StudentCoursesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
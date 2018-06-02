using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserLoggedIn"] != null)
        {
            signUp.Visible = false;
            logIn.Visible = false;
            logout.Visible = true;

            HelloUser.Visible = true;
            HelloUser.Text = "Hello, " + Session["UserLoggedIn"];

            string loginType = Session["loginType"].ToString();
            if (loginType == "AdminCode")
            {
                AddRoomID.Visible = true;
                AddCourseID.Visible = true;
                SetGuideToCourse.Visible = true;
                Timetable.Visible = true;
                GuidePage.Visible = false;
                StudentRegistration.Visible = false;

            }
            else if (loginType == "GuideCode")
            {
                AddRoomID.Visible = false;
                AddCourseID.Visible = false;
                Timetable.Visible = false;
                GuidePage.Visible = true;
                StudentRegistration.Visible = false;
            }
            else if (loginType == "StudentCode")
            {
                AddRoomID.Visible = false;
                Timetable.Visible = false;
                GuidePage.Visible = false;
                StudentRegistration.Visible = true;
                AddCourseID.Visible = false;
            }
            else
            {
                /// Error !!
            }            
        }
        else
        {
            signUp.Visible = true;
            logIn.Visible = true;
            logout.Visible = false;
            HelloUser.Visible = false;
        }
    }

    protected void LogIn_Click(object sender, EventArgs e)
    {
        if (Session["UserLoggedIn"] == null)
        {
            Server.Transfer("Login.aspx");
        }
        else
        {
            // log out 
            Session["UserLoggedIn"] = null;
            Server.Transfer("CoverPage.aspx");
        }
    }    
}

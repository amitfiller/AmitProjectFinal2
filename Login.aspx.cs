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

    protected void Login_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid == true)
        {
            DataService d = new DataService();
            string loginType = LogInTypesID.SelectedItem.Value.ToString();
            string userName = "";
            int studentCode = -1;
            int guideCode = -1;
            if (loginType == "AdminCode")
            {
                if(d.IsAdminExist(EmailTextBox.Text, PasswordTextBox.Text, out userName))
                {
                    Session["UserLoggedIn"] = userName;
                    Session["loginType"] = loginType;
                    Server.Transfer("CoverPage.aspx");
                }
                else
                {
                    message.Visible = true;
                    message.Text = "User name doesn't exist / password is incorrect!";
                    message.ForeColor = System.Drawing.Color.OrangeRed;
                }
            }
            else if (loginType == "GuideCode")
            {
                if (d.IsGuideExist(EmailTextBox.Text, PasswordTextBox.Text, out userName, out guideCode))
                {
                    Session["UserLoggedIn"] = userName;
                    Session["loginType"] = loginType;
                    Session["LoggedInGuideCode"] = guideCode;
                    Server.Transfer("CoverPage.aspx");
                }
                else
                {
                    message.Visible = true;
                    message.Text = "User name doesn't exist / password is incorrect!";
                    message.ForeColor = System.Drawing.Color.OrangeRed;
                }
            }
            else if (loginType == "StudentCode")
            {
                if (d.IsStudentExist(EmailTextBox.Text, PasswordTextBox.Text, out userName, out studentCode))
                {
                    Session["UserLoggedIn"] = userName;
                    Session["loginType"] = loginType;
                    Session["LoggedInStudentCode"] = studentCode;
                    Server.Transfer("CoverPage.aspx");
                }
                else
                {
                    message.Visible = true;
                    message.Text = "User name doesn't exist / password is incorrect!";
                    message.ForeColor = System.Drawing.Color.OrangeRed;
                }
            }                
            Session["IsGuide"] = false;
            Session["IsStudent"] = true;
        }        
        else
        {
            message.Visible = true;
            message.Text = "Is not valid!";
            message.ForeColor = System.Drawing.Color.OrangeRed;
         }
    }
}
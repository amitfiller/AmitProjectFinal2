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

    protected void createTimeTable_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == true)
        {
            DataService d = new DataService();


            if (!d.IsTimeTableAlreadySet(GuideCourseID.SelectedItem.Value.ToString(), DayID.SelectedItem.Value.ToString(), HourID.SelectedItem.Value.ToString()))
            {
                if (!d.IsRoomFree(RoomNameID.SelectedItem.Value.ToString(), DayID.SelectedItem.Value.ToString(), HourID.SelectedItem.Value.ToString()))
                {
                    d.SetTimeTable(GuideCourseID.SelectedItem.Value.ToString(), RoomNameID.SelectedItem.Value.ToString(), DayID.SelectedItem.Value.ToString(), HourID.SelectedItem.Value.ToString());
                    Server.Transfer("CoverPage.aspx");
                }
                else
                {
                    message.Visible = true;
                    message.Text = "The selected room is already busy for the selected time";
                    message.ForeColor = System.Drawing.Color.OrangeRed;
                }
            }
            else
            {
                message.Visible = true;
                message.Text = "The course date and time is alreay set.";
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


    protected void GuideCourseID_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
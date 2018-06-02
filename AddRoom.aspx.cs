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

    protected void AddRoom_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == true)
        {
            DataService d = new DataService();
            if (d.RoomNameNotExist(RoomName.Text))
            {
                d.AddRoom(RoomName.Text, RoomType.SelectedItem.Value.ToString());
                message.Visible = true;
                message.Text = "Room name " + RoomName.Text + " added successfully";
                message.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                message.Visible = true;
                message.Text = "Room name " + RoomName.Text + " is already exist";                
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
}
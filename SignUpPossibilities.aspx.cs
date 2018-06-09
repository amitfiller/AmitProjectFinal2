using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CoverPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SignUpParticipant_Click(object sender, EventArgs e)
    {
        Server.Transfer("SignUpStudents.aspx");
    }
    protected void SignUpWorker_Click(object sender, EventArgs e)
    {
        Server.Transfer("SignUpWorkers.aspx");
    }
}
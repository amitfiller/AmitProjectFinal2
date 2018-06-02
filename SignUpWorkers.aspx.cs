using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignUpWorkers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    
    protected void FunctionID_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (IDNumber.Text.Length == 9)
        {
            string text = IDNumber.Text;
            int sum = 0;
            for (int index = 0; index < 9; index++)
            {
                int id = (int)Char.GetNumericValue(text[index]);

                int multy = 0;
                if (index % 2 == 0)
                    multy = id;
                else
                    multy = 2 * id;

                int result = (multy / 10) + (multy % 10);
                sum = sum + result;
            }

            args.IsValid = (sum % 10 == 0);
        }
        else
        {
            args.IsValid = false;
        }
    }


    protected void SignUp_Click(object sender, EventArgs e)
    {

        if (Page.IsValid == true)
        {
            message.Visible = false;
            if (PassTextBox.Text == ReTypeTextBox.Text)
            {
                DataService d = new DataService();
                if (d.NoCodeWorkerTogetherWithEmail(Email.Text))
                {
                    d.InsertGuidsDetails(FirstName.Text, LastName.Text, IDNumber.Text, Birthdate.Text, Cellphone.Text, Address.Text, Email.Text, PassTextBox.Text);
                    Server.Transfer("Login.aspx");
                }
                else
                {
                    message.Visible = true;
                    message.Text = "Email address already exists!";
                    message.ForeColor = System.Drawing.Color.OrangeRed;
                }
            }
            else
            {
                message.Visible = true;
                message.Text = "Password are not the same!";
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


    protected void ReTypeTextBox_TextChanged(object sender, EventArgs e)
    {

    }
}

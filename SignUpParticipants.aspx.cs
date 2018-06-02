using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignUpParticipants : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void FunctionID_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = Validator.ValidateUserIDNumber(IDNumber.Text);     
    }
        
   
    protected void SignUp_Click(object sender, EventArgs e)
    {
        //GAGAGAG
        //Gamit hoshev she hoo hahi hacham ba olam noder 
        if (Page.IsValid == true)
        {
            message.Visible = false;
            if (PassTextBox.Text == ReTypeTextBox.Text)
            {
                DataService d = new DataService();
                if (d.NoUsernameStudent(email.Text))
                {
                    d.EnterDetailsStudent(IDNumber.Text, FirstName.Text, LastName.Text, Birthdate.Text, Gender.SelectedItem.Text, Cellphone.Text, Address.Text, email.Text, PassTextBox.Text);                               
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
    
}


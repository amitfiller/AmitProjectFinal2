<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SignUpStudents.aspx.cs" Inherits="SignUpParticipants" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <h3>
        <asp:Label ID="LabelSignupID" runat="server"  Text="Signup Student"></asp:Label>
    </h3>

      <br/>
    <table  class="most_tables">
        <tr>
            <td>ID Number:</td>
            <td >
                <asp:TextBox ID="IDNumber"  runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionVIDNumber" runat="server" ControlToValidate="IDNumber" ErrorMessage="Regular Expression ID Number" ValidationExpression="\d{9}"></asp:RegularExpressionValidator>
                <asp:CustomValidator ID="FunctionID" runat="server" ErrorMessage="Number id is not valid" OnServerValidate="FunctionID_ServerValidate" ClientValidationFunction="FunctionID_ServerValidate"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td>First Name:</td>
            <td>
                <asp:TextBox ID="FirstName"  runat="server"></asp:TextBox>
            </td>
            <td class="auto-style23">
                <asp:RegularExpressionValidator ID="RegularExpressionFirstName" runat="server" ControlToValidate="FirstName" ErrorMessage="Regular Expression First Name" ValidationExpression="[a-zA-Z._^%$#!~@,-]+."></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Last Name:</td>
            <td >
                <asp:TextBox ID="LastName"  runat="server" required="true"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionLastName" runat="server" ControlToValidate="LastName" ErrorMessage="Regular Expression Last Name" ValidationExpression="[a-zA-Z._^%$#!~@,-]+."></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Birth Date:</td>  
                      
            <td><asp:TextBox ID="Birthdate"  runat="server" type="Date"  required="true"/></td>

        </tr>
        <tr>
            <td>Gender:</td>
            <td>
                <asp:DropDownList ID="Gender" runat="server" required="true">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Cellphone:</td>
            <td>
                <asp:TextBox ID="Cellphone"  runat="server" required="true"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionCellphone" runat="server" ControlToValidate="Cellphone" ErrorMessage="Regular Expression Cellphone" ValidationExpression="0\d{9}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Address:</td>
            <td>
                <asp:TextBox ID="Address"  runat="server" required="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Job:</td>
            <td>
                <asp:DropDownList ID="Job"  runat="server" required="true">
                    <asp:ListItem>Student</asp:ListItem>
                    <asp:ListItem>Employee</asp:ListItem>
                    <asp:ListItem>Idependent</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Email</td>
            <td >
                <asp:TextBox ID="email" runat="server" required="true"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionUsername" runat="server" ErrorMessage="Invalid email address" ControlToValidate="email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Password:</td>
            <td>
                <asp:TextBox ID="PassTextBox" runat="server" TextMode="Password"  required="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>ReType Password</td>
            <td>
                <asp:TextBox ID="ReTypeTextBox" runat="server" TextMode="Password" required="true"></asp:TextBox>
            </td>
        </tr>
    </table>
    <p>
        <asp:Button ID="SignUp" CssClass="page_button" runat="server" onclick="SignUp_Click" 
            style="text-align: center" Text="Sign Up" />
        <asp:Label ID="message" runat="server" Visible="False"></asp:Label>
    </p>
   
</asp:Content>


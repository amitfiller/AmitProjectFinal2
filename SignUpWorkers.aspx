<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SignUpWorkers.aspx.cs" Inherits="SignUpWorkers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <h3>
        <asp:Label ID="LabelSignupID" runat="server" Text="Signup Guilde"></asp:Label>
    </h3>
    <br />
    <table class="most_tables">
        <tr>
            <td>First Name:</td>
            <td>
                <asp:TextBox ID="FirstName" runat="server" required="true"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td>Last Name:</td>
            <td>
                <asp:TextBox ID="LastName" runat="server" required="true"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td>ID Number:</td>
            <td>
              <asp:TextBox ID="IDNumber" runat="server" required="true" ></asp:TextBox>
                   </td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionVIDNumber" runat="server" ControlToValidate="IDNumber" ErrorMessage="Id number must contains 9 digits. " ValidationExpression="\d{9}"></asp:RegularExpressionValidator>
                <asp:CustomValidator ID="FunctionID" runat="server" ErrorMessage="Control digit is incorrect. " OnServerValidate="FunctionID_ServerValidate" ClientValidationFunction="FunctionID_ServerValidate"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td>Birth Date:</td>
            <td>
                <asp:TextBox ID="Birthdate" CssClass="birth_date" runat="server" type="Date" required="true" /></td>
        </tr>
        <tr>
            <td>Cellphone:</td>
            <td>
                <asp:TextBox ID="Cellphone" runat="server" required="true"></asp:TextBox>
            </td>

            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionCellphone" runat="server" ControlToValidate="Cellphone" ErrorMessage="Regular Expression Cellphone" ValidationExpression="0\d{9}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Address:</td>
            <td>
                <asp:TextBox ID="Address" runat="server" required="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Email:</td>
            <td>
                <asp:TextBox ID="Email" runat="server" required="true"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionUsername" runat="server" ErrorMessage="Invalid email address" ControlToValidate="email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>

        </tr>
        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="PassTextBox" runat="server" TextMode="Password" required="true"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>Retype Password</td>
            <td>
                <asp:TextBox ID="ReTypeTextBox" runat="server" TextMode="Password" OnTextChanged="ReTypeTextBox_TextChanged" required="true"></asp:TextBox>
            </td>
        </tr>
    </table>
    <p>
        <asp:Button ID="SignUp" CssClass="page_button" runat="server" OnClick="SignUp_Click"
            Style="text-align: center" Text="Sign Up" Width="73px" />
        <asp:Label ID="message" runat="server" Visible="False"></asp:Label>
    </p>
</asp:Content>


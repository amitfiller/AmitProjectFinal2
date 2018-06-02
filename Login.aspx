<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table id="login">
        <tr>
            <td >
                <asp:DropDownList ID="LogInTypesID" runat="server">
                    <asp:ListItem Value="StudentCode">Student</asp:ListItem>
                    <asp:ListItem Value="GuideCode">Guide</asp:ListItem>
                    <asp:ListItem Value="AdminCode">Admin</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>.

        <tr>
            <td >Email: <br />
                <asp:TextBox ID="EmailTextBox" runat="server" required="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td >Password: <br />
                <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" required ="true"></asp:TextBox>
            </td>
        </tr>
    </table>
    <center><asp:Button ID="Login" CssClass="page_button" runat="server" OnClick="Login_Click" Text="Login" />

        <br /> <br />
        <asp:Label ID="message" style="color:black; font-family:Verdana" runat="server" Text="Label" Visible="False"></asp:Label>
    </center>
</asp:Content>



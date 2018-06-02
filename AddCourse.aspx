<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddCourse.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <br /><br />
      <table class="most_tables">
        <tr>
            <td >Course Name:</td>
            <td>
                <asp:TextBox ID="CourseName" runat="server" required ="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Price:</td>
            <td class="auto-style7">
                <asp:TextBox ID="Price" runat="server" required="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td >Description:</td>
            <td>
                <asp:TextBox ID="Description" runat="server" required="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Room Type:</td>
            <td>
                <asp:DropDownList ID="RoomType" runat="server" DataSourceID="AccessDataSource1" DataTextField="TypeName" DataValueField="RoomTypeCode">
                    <asp:ListItem Value="-1">-- Select one option --</asp:ListItem>
                </asp:DropDownList>
                <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/Matnas_Database.accdb" SelectCommand="SELECT [TypeName], [RoomTypeCode] FROM [RoomTypes]" OnSelecting="AccessDataSource1_Selecting"></asp:AccessDataSource>
            </td>
        </tr>     
    </table>
    <br />
      <asp:Button ID="Add"  CssClass="page_button" runat="server" onclick="AddCourse_Click" Text="Add course" />
        <asp:Label ID="message" runat="server" Visible="False"></asp:Label>
</asp:Content>


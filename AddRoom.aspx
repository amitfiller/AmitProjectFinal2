<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddRoom.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style8 {
            width: 122px;
        }
        .auto-style9 {
            width: 252px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br />
      <table class="most_tables" >
        <tr>
            <td >Room Name:</td>
            <td>
                <asp:TextBox ID="RoomName" runat="server" required="true"></asp:TextBox>
            </td>
        </tr>     
        <tr>
            <td>Room Type:</td>
            <td>
                <asp:DropDownList ID="RoomType" runat="server" DataSourceID="AccessDataSource1" DataTextField="TypeName" DataValueField="RoomTypeCode">              
                </asp:DropDownList>
                <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/Matnas_Database.accdb" SelectCommand="SELECT [TypeName], [RoomTypeCode] FROM [RoomTypes]"></asp:AccessDataSource>
            </td>
        </tr>            
    </table>
    
    <br />

      <asp:Button ID="Add"  CssClass="page_button" runat="server" onclick="AddRoom_Click" Text="Add Room" />
      <asp:Label ID="message" runat="server" Visible="False">   </asp:Label> 


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SetGuideToCourse.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style8 {
            width: 115px;
        }
        .auto-style9 {
            width: 235px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br />
     <table class="most_tables">
        <tr>
            <td>Guide Name:</td>           
           <td>
              <asp:DropDownList ID="GuideNameID" runat="server" DataSourceID="Guides_DS" DataTextField="FullName" DataValueField="GuideCode">              
                </asp:DropDownList>
                <asp:AccessDataSource ID="Guides_DS" runat="server" DataFile="~/App_Data/Matnas_Database.accdb" SelectCommand="SELECT [GuideCode], ['GuideName'] As FullName FROM [GuidesFullNameView]"></asp:AccessDataSource>             
            </td>
        </tr>     
        <tr>
            <td>Course:</td>
           <td>
                <asp:DropDownList ID="CourseNameID" runat="server" DataSourceID="CourseName_DS" DataTextField="CourseName" DataValueField="CourseCode">              
                </asp:DropDownList>
                <asp:AccessDataSource ID="CourseName_DS" runat="server" DataFile="~/App_Data/Matnas_Database.accdb" SelectCommand="SELECT [CourseName], [CourseCode] FROM [Courses]"></asp:AccessDataSource>
            </td>
        </tr>     
    </table>
    <br />
      <asp:Button ID="Set"  CssClass="page_button" runat="server" onclick="SetGuideToCourse_Click" Text="Set Guide in Course" />
        <asp:Label ID="message" runat="server" Visible="False"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>


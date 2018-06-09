<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentPage.aspx.cs" Inherits="ParticipantsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <asp:Label ID="Hello" runat="server" Text="Student Active Courses" ></asp:Label> 
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
  
        <asp:GridView ID="StudentCoursesGridView" runat="server" AllowPaging="True" PageSize="3" OnPageIndexChanging="StudentCoursesGridView_PageIndexChanging" OnRowDeleting="StudentCoursesGridView_RowDeleting">
            <Columns>
                <asp:CommandField DeleteText="Leave Course" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>        
   
    <br /><br />
    <asp:Button CssClass="menu_buttons" ID="JoinCourse" runat="server" OnClick="JoinCourse_Click" Text="Join" /> 
    </asp:Content>


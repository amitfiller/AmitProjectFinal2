<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RankCourse.aspx.cs" Inherits="RankCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <p>
    <asp:Label ID="CorseName" runat="server" Text="Course Name:"></asp:Label>
<asp:DropDownList ID="CoursesList" runat="server" OnSelectedIndexChanged="CoursesList_SelectedIndexChanged">
            <asp:ListItem>Science</asp:ListItem>
            <asp:ListItem>Krav Maga</asp:ListItem>
            <asp:ListItem>Judo</asp:ListItem>
            <asp:ListItem>Karate</asp:ListItem>
            <asp:ListItem>Electricity</asp:ListItem>
            <asp:ListItem>Basketball</asp:ListItem>
            <asp:ListItem>Painting</asp:ListItem>
            <asp:ListItem>Balet</asp:ListItem>
            <asp:ListItem>Trampoline</asp:ListItem>
        </asp:DropDownList>
</p>
<p>
    <asp:Label ID="CourseDescription" runat="server" Text="Description:"></asp:Label>
</p>
<p>
    <asp:Label ID="NumParticipants" runat="server" Text="Number of Participants:"></asp:Label>
</p>
<p>
    <asp:Label ID="Rank" runat="server" Text="Rank:"></asp:Label>
&nbsp;&nbsp;
    <asp:DropDownList ID="Rankings" runat="server">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="SaveRank" runat="server" Text="Save Ranking" OnClick="SaveRank_Click" />
    <br />
</p>
</asp:Content>


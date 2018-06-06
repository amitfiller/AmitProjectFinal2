<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SetTimeTable.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br /><br />
    <table class="most_tables">
        <tr>
            <td>Guide and Course:</td>
            <td>
                <asp:DropDownList ID="GuideCourseID" runat="server" DataSourceID="GuidesCourse_DS" DataTextField="column1"
                    DataValueField="GuideCourseCode"
                    AppendDataBoundItems="true" OnSelectedIndexChanged="GuideCourseID_SelectedIndexChanged" required="true">
                    <asp:ListItem Value="-1">-- Select one option --</asp:ListItem>
                </asp:DropDownList>
                <asp:AccessDataSource ID="GuidesCourse_DS" runat="server" DataFile="~/App_Data/Matnas_Database.accdb" SelectCommand="SELECT [GuideCourseCode], ['CourseAndGuide'] AS column1 FROM [GuideInCourseView]"></asp:AccessDataSource>
            </td>
        </tr>
        <tr>
            <td>Room Name:</td>
            <td>
                <asp:DropDownList ID="RoomNameID" runat="server" DataSourceID="Rooms_DS" DataTextField="RoomName" DataValueField="RoomCode"
                    AppendDataBoundItems="true" required="true">
                    <asp:ListItem Value="-1">-- Select one option --</asp:ListItem>
                </asp:DropDownList>
                <asp:AccessDataSource ID="Rooms_DS" runat="server" DataFile="~/App_Data/Matnas_Database.accdb" SelectCommand="SELECT [RoomName], [RoomCode] FROM [Rooms]"></asp:AccessDataSource>
            </td>
        </tr>
        <tr>
            <td>Day:</td>
            <td>
                <asp:DropDownList ID="DayID" runat="server" DataSourceID="Days_DS" DataTextField="Name" DataValueField="DayCode"
                    AppendDataBoundItems="true" required="true">
                    <asp:ListItem Value="-1">-- Select one option --</asp:ListItem>
                </asp:DropDownList>
                <asp:AccessDataSource ID="Days_DS" runat="server" DataFile="~/App_Data/Matnas_Database.accdb" SelectCommand="SELECT [Name], [DayCode] FROM [WorkingDays]"></asp:AccessDataSource>
            </td>            
        </tr>
        <tr>
            <td>Hour:</td>
            <td>
                <asp:DropDownList ID="HourID" runat="server" DataSourceID="Hours_DS" DataTextField="HourName" DataValueField="HourCode" AppendDataBoundItems="true" required="true">
                    <asp:ListItem Value="-1">-- Select one option --</asp:ListItem>
                </asp:DropDownList>
                <asp:AccessDataSource ID="Hours_DS" runat="server" DataFile="~/App_Data/Matnas_Database.accdb" SelectCommand="SELECT [HourName], [HourCode] FROM [WorkingHours]"></asp:AccessDataSource>
            </td>
        </tr>

    </table>
    <br />
    <center>
        <asp:Button ID="Button1" CssClass="page_button"  runat="server" OnClick="createTimeTable_Click" Text="Add to Time Table" />
    </center>


     <asp:Label ID="message" runat="server" Visible="False" ></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>


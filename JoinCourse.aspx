<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="JoinCourse.aspx.cs" Inherits="JoinCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table class="most_tables" style=" border-spacing: 15px">
            <tr>
                <td>
                    <asp:Label ID="ChooseCourseID" runat="server" Text="Choose Course:"></asp:Label>
                    <br />
                </td>
                <td>
                    <asp:DropDownList ID="CourseNameID" runat="server" DataSourceID="CourseNames_DS" DataTextField="CourseName" DataValueField="CourseCode"
                        OnSelectedIndexChanged="ChooseCourse_SelectedChanged"
                        AppendDataBoundItems="true" AutoPostBack="True">
                        <asp:ListItem Value="-1">-- Select one option --</asp:ListItem>
                    </asp:DropDownList>
                    <asp:AccessDataSource ID="CourseNames_DS" runat="server" DataFile="~/App_Data/Matnas_Database.accdb" SelectCommand="SELECT [CourseName], [CourseCode] FROM [TimeTableCourseNameView]"></asp:AccessDataSource>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="ChooseGuideID" runat="server" Text="Choose Guide:"></asp:Label>
                    <br />
                </td>
                <td>
                    <asp:DropDownList ID="GuideNameID" runat="server"
                        OnSelectedIndexChanged="ChooseGuide_SelectedChanged"
                        AppendDataBoundItems="true" Enabled="False" AutoPostBack="True">
                        <asp:ListItem Value="-1">-- Select one option --</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="ChooseTime" runat="server" Text="Choose Time:"></asp:Label>
                    <br />
                </td>
                <td>
                    <asp:DropDownList ID="CourseTimeID" runat="server"
                        AppendDataBoundItems="true" Enabled="False" AutoPostBack="True">
                        <asp:ListItem Value="-1">-- Select one option --</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <br />
        <asp:Button CssClass="page_button" ID="JoinId" runat="server" OnClick="Join_Click" Text="Add" Enabled="False" />
    </div>

    <div>
        <br />
        <asp:GridView ID="AddedCoursesGridView" runat="server" AllowPaging="True" OnRowDeleting="AddedCoursesGridView_RowDeleting">
            <Columns>
                <asp:CommandField DeleteText="Remove" ShowDeleteButton="True" />
            </Columns>
            
        </asp:GridView>
    </div>

    <br />
    <table>
        <tr>
            <td>
                <asp:Button CssClass="page_button" ID="ContToPayID" runat="server" OnClick="ContinueToPayment"
                    Text="Continue To Payment" Visible="False" />
            </td>
            <td>
           
                <asp:Label ID="totalPriceLabel" runat="server" Text="Total Price:" Visible="False"></asp:Label></td>
            <td>
                <asp:Label ID="totalPriceText" runat="server" Text="0.0" Visible="False"></asp:Label></td>
            <td>
                <asp:DropDownList ID="CurrencyDropDown" runat="server"
                    AutoPostBack="True" Visible="False" OnSelectedIndexChanged="CurrencyDropDown_SelectedIndexChanged">
                    <asp:ListItem Value="he-IL">NIS</asp:ListItem>
                    <asp:ListItem Value="en-US">USD</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table>
        <tr>
            <td>
                <asp:Label ID="LabelCreditCardType" runat="server" Text="Credit card type:" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="CreditCradTypeID" runat="server" Visible="False">
                    <asp:ListItem Value="-1">-- Select one option --</asp:ListItem>
                    <asp:ListItem>Visa</asp:ListItem>
                    <asp:ListItem>MasterCard</asp:ListItem>
                    <asp:ListItem>American Express</asp:ListItem>
                    <asp:ListItem>Isracard</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelCreditCardNum" runat="server" Text="Credit card number:" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxCreditCardNum" runat="server" Height="16px" Visible="False" Width="125px"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxCreditCardNum" ErrorMessage="Card number must contains 16 digits" ValidationExpression="\d{16}" Visible="False">Must be 16 numbers!</asp:RegularExpressionValidator>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="LabelIDNumber" runat="server" Text="ID number:" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxIDNumber" runat="server" Visible="False"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelMonthValidity" runat="server" Text="Month validity" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListMonth" runat="server" Visible="False">
                    <asp:ListItem Value="-1">-- Select one option --</asp:ListItem>
                    <asp:ListItem Value="1">January </asp:ListItem>
                    <asp:ListItem Value="2">February</asp:ListItem>
                    <asp:ListItem Value="3">March</asp:ListItem>
                    <asp:ListItem Value="4">April</asp:ListItem>
                    <asp:ListItem Value="5">May</asp:ListItem>
                    <asp:ListItem Value="6">June</asp:ListItem>
                    <asp:ListItem Value="7">July</asp:ListItem>
                    <asp:ListItem Value="8">August</asp:ListItem>
                    <asp:ListItem Value="9">September</asp:ListItem>
                    <asp:ListItem Value="10">October</asp:ListItem>
                    <asp:ListItem Value="11">November</asp:ListItem>
                    <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelYearValidity" runat="server" Text="Year validity" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListYear" runat="server" Visible="false">
                </asp:DropDownList>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Button CssClass="page_button" ID="PayBtnID" runat="server" OnClick="PayBtnID_Click" Text="Pay" Visible="False" />
            </td>
        </tr>
    </table>
    <asp:Label ID="MessageID" runat="server" Visible="False"></asp:Label>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SignUpPossibilities.aspx.cs" Inherits="CoverPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <center>       
      <div style="line-height:800%">
    <asp:Button CssClass="page_button" ID="SignUpParticipant" runat="server" OnClick="SignUpParticipant_Click" Text="Sign Up As a Student" />
    <asp:Button CssClass="page_button" ID="SignUpWorker" runat="server" Text="Sign Up As a Guide" 
        onclick="SignUpWorker_Click" />
          </div>
   </center>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="signUp.aspx.cs" Inherits="client.userPages.signUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    UserName: <asp:TextBox ID="UserNameBox" runat="server"></asp:TextBox> <br />
    Email: <asp:TextBox ID="EmailBox" runat="server"></asp:TextBox> <br />
    Password: <asp:TextBox ID="PasswordBox" runat="server"></asp:TextBox> <br />
    <asp:Button ID="SignUpButton" runat="server" Text="Sign Up" OnClick="SignUpButton_Click" /> <br />
    <%=errorMessage %>
</asp:Content>

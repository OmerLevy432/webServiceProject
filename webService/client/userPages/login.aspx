<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="client.userPages.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Login</h1>
    Email: <asp:TextBox ID="EmailBox" runat="server"></asp:TextBox> <br />
    Password: <asp:TextBox ID="PasswordBox" runat="server"></asp:TextBox> <br />
    <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" /> <br />
    <%=errorMessage %>
</asp:Content>

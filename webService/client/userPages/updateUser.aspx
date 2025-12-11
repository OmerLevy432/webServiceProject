<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="updateUser.aspx.cs" Inherits="client.updateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Update user</h1>
    <asp:Literal ID="UserIdLiteral" runat="server"></asp:Literal> <br />
    Username: <asp:TextBox ID="UsernameBox" runat="server"></asp:TextBox> <br />
    Password: <asp:TextBox ID="PasswordBox" runat="server"></asp:TextBox> <br />
    Email: <asp:TextBox ID="EmailBox" runat="server"></asp:TextBox> <br />
    Role:  <asp:DropDownList ID="DDLRole" runat="server"></asp:DropDownList>
    <asp:Button ID="UpdateUserButton" runat="server" Text="Update" OnClick="UpdateUserButton_Click"/>
</asp:Content>

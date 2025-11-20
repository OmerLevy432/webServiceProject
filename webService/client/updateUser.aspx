<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="updateUser.aspx.cs" Inherits="client.updateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Update user</h1>
    UserId: <asp:TextBox ID="UserIdBox" runat="server"></asp:TextBox>
    <asp:Button ID="GetUserButton" runat="server" Text="Get Data" OnClick="GetUserButton_Click" /> <br />

    Username: <asp:TextBox ID="UsernameBox" runat="server"></asp:TextBox> <br />
    Password: <asp:TextBox ID="PasswordBox" runat="server"></asp:TextBox> <br />
    Email: <asp:TextBox ID="EmailBox" runat="server"></asp:TextBox> <br />
    RoleId: <asp:TextBox ID="RoleIdBox" runat="server"></asp:TextBox> <br />
    <asp:Button ID="UpdateUserButton" runat="server" Text="Update" OnClick="UpdateUserButton_Click"/>
</asp:Content>

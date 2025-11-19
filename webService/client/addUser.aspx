<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="addUser.aspx.cs" Inherits="client.addUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Add user</h1>
    Username: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> <br />
    Password: <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox> <br />
    Email: <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox> <br />
    RoleId: <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox> <br />
</asp:Content>

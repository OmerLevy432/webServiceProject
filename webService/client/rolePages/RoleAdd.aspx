<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="RoleAdd.aspx.cs" Inherits="client.rolePages.RoleAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Add Role</h1>
     Role ID: <asp:TextBox ID="RoleIdBox" runat="server"></asp:TextBox> <br />
     Role Tag: <asp:TextBox ID="RoleTagBox" runat="server"></asp:TextBox> <br />
     <asp:Button ID="AddRoleButton" runat="server" Text="Add" OnClick="AddRoleButton_Click"/>
</asp:Content>

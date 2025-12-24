<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="RoleUpdate.aspx.cs" Inherits="client.rolePages.RoleUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Update Role</h1>
    Role ID: <asp:TextBox ID="RoleIdBox" runat="server"></asp:TextBox> <br />
    Role Tag: <asp:TextBox ID="RoleTagBox" runat="server"></asp:TextBox> <br />

    <asp:Button ID="UpdateRoleButton" runat="server" Text="Update" OnClick="UpdateRoleButtonClick"/>
</asp:Content>

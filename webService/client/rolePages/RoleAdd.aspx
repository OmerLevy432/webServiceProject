<%@ Page Title="Add New Role" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="RoleAdd.aspx.cs" Inherits="client.rolePages.RoleAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/stylesheets/roleAddStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="page-container">
        <div class="page-header">
            <h1>Create System Role</h1>
            <p class="subtitle">Assign a new ID and unique tag for system permissions</p>
        </div>

        <div class="form-card">
            <div class="form-group">
                <label>Role ID</label>
                <asp:TextBox ID="RoleIdBox" runat="server" CssClass="form-control" placeholder="e.g., 101"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Role Tag</label>
                <asp:TextBox ID="RoleTagBox" runat="server" CssClass="form-control" placeholder="e.g., Admin_Full_Access"></asp:TextBox>
            </div>

            <div class="form-actions">
                <asp:Button ID="AddRoleButton" runat="server" Text="Create Role" CssClass="btn btn-primary btn-full-width" OnClick="AddRoleButton_Click"/>
            </div>
        </div>
    </div>

</asp:Content>
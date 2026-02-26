<%@ Page Title="Update User" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="updateUser.aspx.cs" Inherits="client.updateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/stylesheets/updateUserStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="page-container">
        <div class="page-header">
            <h1>Edit User Account</h1>
            <p class="subtitle">Modify credentials and system permissions</p>
        </div>

        <div class="form-card">
            <div class="user-id-banner">
                User ID: <strong><asp:Literal ID="UserIdLiteral" runat="server"></asp:Literal></strong>
            </div>

            <div class="form-group">
                <label>Username</label>
                <asp:TextBox ID="UsernameBox" runat="server" CssClass="form-control" placeholder="Enter username"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Password</label>
                <asp:TextBox ID="PasswordBox" runat="server" CssClass="form-control" TextMode="Password" placeholder="••••••••"></asp:TextBox>
                <small class="form-help">Leave blank to keep current password</small>
            </div>

            <div class="form-group">
                <label>Email Address</label>
                <asp:TextBox ID="EmailBox" runat="server" CssClass="form-control" TextMode="Email" placeholder="user@example.com"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>System Role</label>
                <asp:DropDownList ID="DDLRole" runat="server" CssClass="form-control ddl-style"></asp:DropDownList>
            </div>

            <div class="form-actions">
                <asp:Button ID="UpdateUserButton" runat="server" Text="Save Changes" CssClass="btn btn-primary btn-full-width" OnClick="UpdateUserButton_Click"/>
                <a href="UserList.aspx" class="btn-link">Cancel and Return</a>
            </div>
        </div>
    </div>

</asp:Content>
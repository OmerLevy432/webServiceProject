<%@ Page Title="Create User" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="addUser.aspx.cs" Inherits="client.addUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/stylesheets/addUserStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="page-container">
        <div class="page-header">
            <h1>Add New User</h1>
            <p class="subtitle">Register a new account and assign system permissions</p>
        </div>

        <div class="form-card">
            <div class="form-group">
                <label>Username</label>
                <asp:TextBox ID="UsernameBox" runat="server" CssClass="form-control" placeholder="Enter full name or handle"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Email Address</label>
                <asp:TextBox ID="EmailBox" runat="server" CssClass="form-control" TextMode="Email" placeholder="user@example.com"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Initial Password</label>
                <asp:TextBox ID="PasswordBox" runat="server" CssClass="form-control" TextMode="Password" placeholder="••••••••"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Assign Role</label>
                <asp:DropDownList ID="DDLRole" runat="server" CssClass="form-control ddl-style"></asp:DropDownList>
            </div>

            <div class="form-actions">
                <asp:Button ID="AddUserButton" runat="server" Text="Create Account" CssClass="btn btn-primary btn-full-width" OnClick="AddUserButton_Click"/>
                <a href="UserList.aspx" class="btn-link">Back to User Directory</a>
            </div>
        </div>
    </div>

</asp:Content>
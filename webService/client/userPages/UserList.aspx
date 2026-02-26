<%@ Page Title="User Directory" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="client.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../stylesheets/userListStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-container">
        <div class="page-header">
            <h1>User Directory</h1>
            <a href="AddUser.aspx" class="btn-add-new">Add User +</a>
        </div>

        <div class="user-grid">
            <asp:Repeater ID="userRepeater" runat="server">
                <ItemTemplate>
                    <div class="user-card">
                        <div class="card-main">
                            <span class="role-label"><%# Eval("RoleTag.RoleTag") %></span>
                            <h2 class="user-name"><%# Eval("UserName") %></h2>
                            <span class="user-id">User ID: #<%# Eval("UserId") %></span>
                        </div>

                        <div class="card-footer">
                            <a href='UserProfile.aspx?userId=<%# Eval("UserId") %>' class="footer-link">Profile</a>
                            <a href='OrderFood.aspx?roleId=<%# Eval("RoleTag.RoleId") %>&userId=<%# Eval("UserId") %>' class="footer-link">Order</a>
                            <asp:LinkButton ID="btnLoginAs" runat="server" 
                                CssClass="footer-link btn-login-action" 
                                CommandName="LoginAs" 
                                CommandArgument='<%# Eval("UserId") %>' 
                                OnCommand="HandleUserCommand">Login</asp:LinkButton>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
<%@ Page Title="User Directory" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="client.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/stylesheets/userListStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="page-container">
        <div class="page-header">
            <div class="header-title">
                <h1>User Directory</h1>
                <p class="subtitle">Manage and view all registered accounts</p>
            </div>
            <a href="AddUser.aspx" class="btn btn-add">+ Add New User</a>
        </div>

        <div class="user-grid">
            <asp:Repeater ID="userRepeater" runat="server">
                <ItemTemplate>
                    <div class="user-card">
                        <div class="user-card-header">
                            <span class="id-badge">ID #<%# Eval("UserId") %></span>
                        </div>
                        
                        <div class="user-card-body">
                            <div class="role-tag-display">
                                <%# Eval("RoleTag.RoleTag") %>
                            </div>
                            <h3><%# Eval("UserName") %></h3>
                        </div>

                        <div class="user-card-actions">
                            <a href='UserProfile.aspx?userId=<%# Eval("UserId") %>' class="btn-view">
                                🔍 View Profile
                            </a>
                            <a href='OrderFood.aspx?roleId=<%# Eval("RoleTag.RoleId") %>&userId=<%# Eval("UserId") %>' class="btn-order">
                                🛒 Create Order
                            </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>
<%@ Page Title="Role List" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="RoleList.aspx.cs" Inherits="client.rolePages.RoleList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/stylesheets/roleListStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="page-container">
        <div class="page-header">
            <h1>System Roles</h1>
            <a href="RoleAdd.aspx" class="btn btn-success">+ Add New Role</a>
        </div>

        <div class="table-card">
            <table class="role-table">
                <thead>
                    <tr>
                        <th>Role ID</th>
                        <th>Role Tag</th>
                        <th class="text-right">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="roleRepeater" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="role-id">#<%# Eval("RoleId") %></td>
                                <td class="role-tag">
                                    <span class="tag-badge"><%# Eval("RoleTag") %></span>
                                </td>
                                <td class="text-right">
                                    <a href='RoleUpdate.aspx?roleId=<%# Eval("RoleId") %>' class="btn-link">Update</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>

</asp:Content>
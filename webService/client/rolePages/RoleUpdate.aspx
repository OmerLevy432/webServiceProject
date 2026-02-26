<%@ Page Title="Update Role" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="RoleUpdate.aspx.cs" Inherits="client.rolePages.RoleUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/stylesheets/roleUpdateStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="page-container">
        <div class="page-header">
            <h1>Update System Role</h1>
            <p class="subtitle">Modify the tag for the existing role ID</p>
        </div>

        <div class="form-card">
            <div class="form-group readonly-group">
                <label>Role ID</label>
                <div class="static-value">
                    <asp:Label ID="RoleIdLabel" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="form-group">
                <label>Role Tag</label>
                <asp:TextBox ID="RoleTagBox" runat="server" CssClass="form-control" placeholder="e.g., Senior_Editor"></asp:TextBox>
            </div>

            <div class="form-actions">
                <asp:Button ID="UpdateRoleButton" runat="server" Text="Save Changes" CssClass="btn btn-primary btn-full-width" OnClick="UpdateRoleButtonClick"/>
                <a href="RoleList.aspx" class="btn-cancel">Back to List</a>
            </div>
        </div>
    </div>

</asp:Content>
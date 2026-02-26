<%@ Page Title="Login" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="client.userPages.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/stylesheets/loginStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="auth-container">
        <div class="auth-card">
            <div class="auth-header">
                <div class="lock-icon">🔒</div>
                <h2>Welcome Back</h2>
                <p>Please enter your credentials to access your account</p>
            </div>

            <% if (!string.IsNullOrEmpty(errorMessage)) { %>
                <div class="error-alert">
                    <%=errorMessage %>
                </div>
            <% } %>

            <div class="form-group">
                <label>Email Address</label>
                <asp:TextBox ID="EmailBox" runat="server" CssClass="form-control" TextMode="Email" placeholder="email@example.com"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Password</label>
                <asp:TextBox ID="PasswordBox" runat="server" CssClass="form-control" TextMode="Password" placeholder="••••••••"></asp:TextBox>
            </div>

            <div class="form-actions">
                <asp:Button ID="LoginButton" runat="server" Text="Sign In" CssClass="btn btn-primary btn-full" OnClick="LoginButton_Click" />
            </div>

            <div class="auth-footer">
                Don't have an account? <a href="signUp.aspx">Create one here</a>
            </div>
        </div>
    </div>

</asp:Content>
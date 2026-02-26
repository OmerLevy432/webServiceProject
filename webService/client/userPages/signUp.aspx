<%@ Page Title="Create Account" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="signUp.aspx.cs" Inherits="client.userPages.signUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/stylesheets/signUpStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="auth-container">
        <div class="auth-card">
            <div class="auth-header">
                <h2>Create Account</h2>
                <p>Join us to start ordering your favorite food</p>
            </div>

            <% if (!string.IsNullOrEmpty(errorMessage)) { %>
                <div class="error-alert">
                    <%=errorMessage %>
                </div>
            <% } %>

            <div class="form-group">
                <label>Username</label>
                <asp:TextBox ID="UserNameBox" runat="server" CssClass="form-control" placeholder="Choose a username"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Email Address</label>
                <asp:TextBox ID="EmailBox" runat="server" CssClass="form-control" TextMode="Email" placeholder="name@example.com"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Password</label>
                <asp:TextBox ID="PasswordBox" runat="server" CssClass="form-control" TextMode="Password" placeholder="••••••••"></asp:TextBox>
            </div>

            <div class="form-actions">
                <asp:Button ID="SignUpButton" runat="server" Text="Sign Up" CssClass="btn btn-primary btn-full" OnClick="SignUpButton_Click" />
            </div>

            <div class="auth-footer">
                Already have an account? <a href="login.aspx">Log In</a>
            </div>
        </div>
    </div>

</asp:Content>
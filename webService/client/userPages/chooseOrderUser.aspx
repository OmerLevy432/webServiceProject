<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="chooseOrderUser.aspx.cs" Inherits="client.userPages.chooseOrderUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Email:  <asp:TextBox ID="userEmail" runat="server"></asp:TextBox> <br />
    Password: <asp:TextBox ID="userPassword" runat="server"></asp:TextBox> <br />
    <asp:Button ID="order" runat="server" Text="Make Order" OnClick="order_Click" />
    <br />
    <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label>
</asp:Content>

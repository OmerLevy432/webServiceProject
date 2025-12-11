<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="client._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Admin</h1>
    <a href="userPages/UserList.aspx">User List</a>
    <br />
    <a href="userPages/UpdateUser.aspx">Update Lser</a>
    <br />
    <a href="FoodPages/FoodList.aspx">Food List</a>
    <br />
    <a href="FoodPages/FoodUpdate.aspx">Update Food</a>
    <br />
    <a href="FoodPages/FoodAdd.aspx">Add Food</a>
</asp:Content>

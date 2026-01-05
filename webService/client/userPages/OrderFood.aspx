<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="OrderFood.aspx.cs" Inherits="client.userPages.OrderFood" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Order Food</h1> <br />
    <%=ordersLink %> <br />

    Food ID: <asp:TextBox ID="itemIdEntry" runat="server"></asp:TextBox>
    <asp:Button ID="addFoodToOrder" runat="server" Text="Add" /> <br />
     <asp:Button ID="SubmitOrder" runat="server" Text="Order" /> <br />
</asp:Content>

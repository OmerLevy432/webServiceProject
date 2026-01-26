<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="OrderFood2.aspx.cs" Inherits="client.userPages.OrderFood2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ID="ItemListDDL" runat="server"></asp:DropDownList> 
    <asp:TextBox ID="QuantityTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="AdditemToList" runat="server" Text="Add" />
    <br />
    <asp:ListView ID="ListView1" runat="server"></asp:ListView> <br />
    <asp:Button ID="UpdateItemInList" runat="server" Text="Update" />
    <asp:Button ID="DeleteItemInList" runat="server" Text="Delete" />

    <asp:Button ID="SaveOrderButton" runat="server" Text="Save" />


</asp:Content>

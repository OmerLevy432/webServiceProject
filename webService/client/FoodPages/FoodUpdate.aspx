<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="FoodUpdate.aspx.cs" Inherits="client.FoodPages.FoodUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Update Food</h1>
    Item ID: <asp:TextBox ID="ItemIdBox" runat="server"></asp:TextBox> <br />
    Creator ID: <asp:TextBox ID="ItemCreatorIdBox" runat="server"></asp:TextBox> <br />
    Price: <asp:TextBox ID="ItemPriceBox" runat="server"></asp:TextBox> <br />
    Description: <asp:TextBox ID="ItemDescriptionBox" runat="server"></asp:TextBox> <br />

    <asp:Button ID="UpdateFoodButton" runat="server" Text="Update" OnClick="UpdateFoodButtonClick"/>
</asp:Content>

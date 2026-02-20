<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="FoodAdd.aspx.cs" Inherits="client.FoodPages.FoodAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <h1>Add Food Item</h1>
   Description: <asp:TextBox ID="DescriptionBox" runat="server"></asp:TextBox> <br />
   Price: <asp:TextBox ID="PriceBox" runat="server"></asp:TextBox> <br />
   Creator ID: <asp:TextBox ID="CreatorIdBox" runat="server"></asp:TextBox> <br />
   Image Url: <asp:TextBox ID="ImageUrlBox" runat="server"></asp:TextBox> <br />
   <asp:Button ID="AddFoodButton" runat="server" Text="Add" OnClick="AddFoodButton_Click"/>
</asp:Content>

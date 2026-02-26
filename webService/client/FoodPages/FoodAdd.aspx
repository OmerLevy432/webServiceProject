<%@ Page Title="Add New Food" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="FoodAdd.aspx.cs" Inherits="client.FoodPages.FoodAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/stylesheets/foodAddStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="page-container">
        <div class="page-header">
            <h1>Add New Food Item</h1>
            <p class="subtitle">Fill in the details to add a new item to the menu</p>
        </div>

        <div class="form-card">
            <div class="form-group">
                <label>Description</label>
                <asp:TextBox ID="DescriptionBox" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" placeholder="Enter food name and details..."></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Price ($)</label>
                <asp:TextBox ID="PriceBox" runat="server" CssClass="form-control" placeholder="0.00"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Creator ID</label>
                <asp:TextBox ID="CreatorIdBox" runat="server" CssClass="form-control" placeholder="User ID"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Image URL</label>
                <asp:TextBox ID="ImageUrlBox" runat="server" CssClass="form-control" placeholder="https://example.com/image.jpg"></asp:TextBox>
            </div>

            <div class="form-actions">
                <asp:Button ID="AddFoodButton" runat="server" Text="Add to Menu" CssClass="btn btn-success btn-full-width" OnClick="AddFoodButton_Click"/>
            </div>
        </div>
    </div>

</asp:Content>
<%@ Page Title="Update Food Item" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="FoodUpdate.aspx.cs" Inherits="client.FoodPages.FoodUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/stylesheets/foodUpdateStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="page-container">
        <div class="page-header">
            <h1>Update Food Item</h1>
        </div>

        <div class="form-card">
            
            <div class="form-group">
                <label>Item ID</label>
                <asp:TextBox ID="ItemIdBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Creator ID</label>
                <asp:TextBox ID="ItemCreatorIdBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Price ($)</label>
                <asp:TextBox ID="ItemPriceBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Description</label>
                <asp:TextBox ID="ItemDescriptionBox" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Image URL</label>
                <asp:TextBox ID="ImageUrlBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-actions">
                <asp:Button ID="UpdateFoodButton" runat="server" Text="Update Item" CssClass="btn btn-primary btn-full-width" OnClick="UpdateFoodButtonClick"/>
            </div>

        </div>
    </div>

</asp:Content>
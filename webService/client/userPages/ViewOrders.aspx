<%@ Page Title="Ready Orders" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="ViewOrders.aspx.cs" Inherits="client.userPages.ViewOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/stylesheets/viewOrdersStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="page-container">
        <div class="page-header">
            <div class="header-content">
                <span class="status-indicator"></span>
                <h1>Orders Ready for Pickup</h1>
            </div>
            <p class="subtitle">The following orders have been completed and are ready to go.</p>
        </div>

        <div class="orders-grid">
            <asp:Repeater ID="repeaterOrders" runat="server">
                <ItemTemplate>
                    <div class="order-card">
                        <div class="order-icon">📦</div>
                        <div class="order-details">
                            <span class="label">Order ID</span>
                            <span class="order-number">#<%# Eval("OrderId") %></span>
                        </div>
                        <div class="order-status">Ready</div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <asp:PlaceHolder ID="phNoOrders" runat="server" Visible="false">
            <div class="empty-orders">
                <p>No orders are currently ready.</p>
            </div>
        </asp:PlaceHolder>
    </div>

</asp:Content>
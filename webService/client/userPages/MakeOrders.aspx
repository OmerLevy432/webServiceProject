<%@ Page Title="Workers Area" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="MakeOrders.aspx.cs" Inherits="client.userPages.MakeOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/stylesheets/makeOrdersStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="page-container">
        <div class="page-header">
            <div class="header-main">
                <h1>Workers Area</h1>
                <span class="live-tag">Live Queue</span>
            </div>
            <h3>Pending Orders</h3>
        </div>

        <div class="queue-container">
            <div class="action-bar">
                <asp:Button ID="MakeOrderButton" runat="server" Text="Complete Next Order" OnClick="MakeOrderButton_Click" CssClass="btn btn-make" />
                <asp:Label ID="noOrdersLable" runat="server" CssClass="status-msg" Text=""></asp:Label>
            </div>

            <div class="orders-list">
                <asp:Repeater ID="repeaterOrders" runat="server">
                    <ItemTemplate>
                        <div class="order-ticket">
                            <div class="ticket-id">
                                <span class="hash">#</span><%# Eval("OrderId") %>
                            </div>
                            <div class="ticket-status">
                                <span class="dot pulse"></span> Pending
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

</asp:Content>
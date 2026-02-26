<%@ Page Title="Order Food" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="OrderFood.aspx.cs" Inherits="client.userPages.OrderFood" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/stylesheets/orderFoodStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-container">
        <div class="page-header">
            <h1>Place Your Order</h1>
            <div class="orders-link-wrapper">
                <%=ordersLink %>
            </div>
        </div>

        <div class="selection-card">
            <div class="selection-grid">
                <div class="selection-group">
                    <label>Select Food Item</label>
                    <asp:DropDownList ID="FoodItemsList" runat="server" CssClass="form-control ddl-style"></asp:DropDownList>
                </div>

                <div class="selection-group">
                    <label>Quantity</label>
                    <input id="FoodQuantity" type="number" runat="server" min="1" max="100" value="1" class="form-control qty-input"/>
                </div>

                <div class="selection-actions">
                    <asp:Button ID="addFoodToOrder" runat="server" Text="Add to Cart" OnClick="addFoodToOrder_Click" CssClass="btn btn-secondary" />
                </div>
            </div>
        </div>

        <div class="cart-section">
            <div class="cart-header">
                <h3>Your Current Selection</h3>
                <asp:Button ID="SubmitOrder" runat="server" Text="Confirm & Order" OnClick="SubmitOrder_Click" CssClass="btn btn-primary" />
            </div>

            <div class="table-card">
                <asp:ListView ID="ListView1" runat="server" DataKeyNames="ItemId" OnItemCommand="ListView1_ItemCommand">
                    <LayoutTemplate>
                        <table class="cart-table">
                            <thead>
                                <tr>
                                    <th>Description</th>
                                    <th>Price</th>
                                    <th>Quantity</th>
                                    <th class="text-right">Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                            </tbody>
                        </table>
                    </LayoutTemplate>

                    <ItemTemplate>
                        <tr>
                            <td class="item-desc"><%# Eval("ItemDescription") %></td>
                            <td class="item-price">$<%# Eval("ItemPrice") %></td>
                            <td>
                                <input type="number" id="ItemQuantity" runat="server" min="1" max="100" 
                                       value='<%# GetItemCount(Container.DisplayIndex) %>' class="form-control table-qty" />
                            </td>
                            <td class="text-right">
                                <asp:Button ID="ModifyItemQuntity" runat="server" Text="Update" 
                                            CommandName="ModifyItem" CommandArgument='<%# Eval("ItemId") %>' CssClass="btn-action btn-modify" />
                                
                                <asp:Button ID="DeleteItemButton" runat="server" Text="Remove" 
                                            CommandName="DeleteItem" CommandArgument='<%# Eval("ItemId") %>' CssClass="btn-action btn-delete" />
                            </td>
                        </tr>
                    </ItemTemplate>

                    <EmptyDataTemplate>
                        <div class="empty-cart">
                            <p>Your cart is currently empty. Start adding some delicious food!</p>
                        </div>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>

</asp:Content>
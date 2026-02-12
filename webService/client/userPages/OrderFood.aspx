<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="OrderFood.aspx.cs" Inherits="client.userPages.OrderFood" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Order Food</h1> 
    <br />

    <%=ordersLink %> 
    <br />

    Food ID:
    <asp:DropDownList ID="FoodItemsList" runat="server"></asp:DropDownList>

    Quantity:
    <input id="FoodQuantity" type="number" runat="server" min="1" max="100" value="1"/>

    <asp:Button ID="addFoodToOrder" runat="server" Text="Add" OnClick="addFoodToOrder_Click" />
    <br />

    <asp:Button ID="SubmitOrder" runat="server" Text="Order" OnClick="SubmitOrder_Click" />
    <br /><br />

    <hr />

    <asp:ListView ID="ListView1" runat="server"
        DataKeyNames="ItemId"
        OnItemCommand="ListView1_ItemCommand">

        <LayoutTemplate>
            <table border="1" cellpadding="5">
                <tr>
                    <th>Description</th>
                    <th>Price</th>
                    <th>Quantity</th>
                    <th>Action</th>
                </tr>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>

        <ItemTemplate>
            <tr>
                <td><%# Eval("ItemDescription") %></td>
                <td><%# Eval("ItemPrice") %></td>

                <!-- 🔹 UPDATED QUANTITY COLUMN -->
                <td>
                    <input type="number"
                           id="ItemQuantity"
                           runat="server"
                           min="1"
                           max="100"
                           value='<%# GetItemCount(Container.DisplayIndex) %>' />
                </td>

                <td>
                    <asp:Button ID="DeleteItemButton"
                        runat="server"
                        Text="Delete"
                        CommandName="DeleteItem"
                        CommandArgument='<%# Eval("ItemId") %>' />

                    <asp:Button ID="ModifyItemQuntity"
                        runat="server"
                        Text="Modify"
                        CommandName="ModifyItem"
                        CommandArgument='<%# Eval("ItemId") %>' />
                </td>
            </tr>
        </ItemTemplate>

        <EmptyDataTemplate>
            <p>No items in order.</p>
        </EmptyDataTemplate>

    </asp:ListView>

</asp:Content>

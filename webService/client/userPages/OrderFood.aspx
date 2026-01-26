<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="OrderFood.aspx.cs" Inherits="client.userPages.OrderFood" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Order Food</h1> <br />
    <%=ordersLink %> <br />

    Food ID: <asp:DropDownList ID="FoodItemsList" runat="server"></asp:DropDownList>
    Quantity: <asp:TextBox ID="FoodQuantity" runat="server" TextMode="Number" Text="1"></asp:TextBox>
    <asp:Button ID="addFoodToOrder" runat="server" Text="Add" OnClick="addFoodToOrder_Click" /> <br />
     <asp:Button ID="SubmitOrder" runat="server" Text="Order" OnClick="SubmitOrder_Click" /> <br />

     <asp:Repeater ID="foodRepeater" runat="server">
     <ItemTemplate>

        Description : <%#Eval("ItemDescription") %>
        Price: <%#Eval("ItemPrice") %>
        Quantity: <%# GetItemCount(Container.ItemIndex) %>

     </ItemTemplate>

     <SeparatorTemplate>
         <br />
     </SeparatorTemplate>

 </asp:Repeater>

    <hr />
    <asp:ListView ID="ListView1" runat="server"></asp:ListView>
    <asp:Button ID="UpdateItemButton" runat="server" Text="Update" />
    <asp:Button ID="DeleteItemButton" runat="server" Text="Delete" />
</asp:Content>

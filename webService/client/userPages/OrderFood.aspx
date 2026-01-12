<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="OrderFood.aspx.cs" Inherits="client.userPages.OrderFood" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Order Food</h1> <br />
    <%=ordersLink %> <br />

    Food ID: <asp:TextBox ID="itemIdEntry" runat="server"></asp:TextBox>
    <asp:Button ID="addFoodToOrder" runat="server" Text="Add" OnClick="addFoodToOrder_Click" /> <br />
     <asp:Button ID="SubmitOrder" runat="server" Text="Order" OnClick="SubmitOrder_Click" /> <br />

     <asp:Repeater ID="foodRepeater" runat="server">
     <ItemTemplate>

         Price: <%#Eval("ItemPrice") %> <br />
         Description : <%#Eval("ItemDescription") %>
     </ItemTemplate>

     <SeparatorTemplate>
         <br />
     </SeparatorTemplate>

 </asp:Repeater>
</asp:Content>

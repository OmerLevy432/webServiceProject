<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="userPurchaseHistory.aspx.cs" Inherits="client.userPurchaseHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Purchase History</h2>

    <asp:Repeater ID="repeaterPurchases" runat="server">

        <ItemTemplate>
            <div>
                Items:
                <%# Eval("FoodItems") %> - <%# Eval("OrderDate") %>
                Amounts:
            </div>
        </ItemTemplate>

        <SeparatorTemplate>
            <br />
        </SeparatorTemplate>

    </asp:Repeater>

</asp:Content>

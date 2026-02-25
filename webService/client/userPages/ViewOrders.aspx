<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="ViewOrders.aspx.cs" Inherits="client.userPages.ViewOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <h3>Orders Ready</h3>


    <asp:Repeater ID="repeaterOrders" runat="server">

    <ItemTemplate>
        <div>
            Order <%#Eval("OrderId") %> <br />
        </div>

    </ItemTemplate>

    <SeparatorTemplate>
        <br />
    </SeparatorTemplate>

    </asp:Repeater>
</asp:Content>

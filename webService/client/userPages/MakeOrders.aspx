<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="MakeOrders.aspx.cs" Inherits="client.userPages.MakeOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Workers Area</h1> <br />
    <h3>Orders Not Ready</h3>


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

    <asp:Label ID="noOrdersLable" runat="server" Text=""></asp:Label> <br />
    <asp:Button ID="MakeOrderButton" runat="server" Text="Make" OnClick="MakeOrderButton_Click" />

</asp:Content>

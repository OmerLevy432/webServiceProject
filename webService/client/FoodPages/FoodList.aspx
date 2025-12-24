<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="FoodList.aspx.cs" Inherits="client.FoodPages.FoodList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Food lists</h1> <br />
<a href="FoodAdd.aspx">Add food item</a> <br />
 
 <asp:Repeater ID="foodRepeater" runat="server">
     <ItemTemplate>

         Item ID: <%#Eval("ItemId")%>) <br />
         Creator ID: <%#Eval("UserId") %> <br />
         Price: <%#Eval("ItemPrice") %> <br />
         Description : <%#Eval("ItemDescription") %>
        <a href='FoodUpdate.aspx?itemId=<%# Eval("ItemId") %>'>update</a>
     </ItemTemplate>

     <SeparatorTemplate>
         <br />
     </SeparatorTemplate>

 </asp:Repeater>
</asp:Content>

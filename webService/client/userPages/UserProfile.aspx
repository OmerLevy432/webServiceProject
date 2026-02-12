<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="client.userPages.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Profile</h2>

   <asp:Repeater ID="userRepeater" runat="server">
    <ItemTemplate>

        User ID : <%#Eval("UserId")%> 
        <%#Eval("UserName") %> - Email : <%#Eval("UserEmail") %>, Password : <%#Eval("UserPassword") %>,
        Role ID : <%#Eval("RoleTag.RoleTag")%>
        <br />
        <a href='updateUser.aspx?userId=<%# Eval("UserId") %>'>Update User</a> <br />
        <a href='OrderFood.aspx?roleId=<%# Eval("RoleTag.RoleId") %>&userId=<%# Eval("UserId") %>'>Order</a>

    </ItemTemplate>

    <SeparatorTemplate>
        <br />
    </SeparatorTemplate>
    </asp:Repeater>

     <h3>Purchase History</h3>

     <asp:Repeater ID="repeaterPurchases" runat="server">

         <ItemTemplate>
             <div>
                 <asp:Repeater ID="InnerRepeater" runat="server" 
                 DataSource='<%# Eval("FoodItems") %>'>
                 <ItemTemplate>
                     <li>
                         </strong> <%# Eval("ItemDescription") %>: </strong> $<%# Eval("ItemPrice") %>
                     </li>
                 </ItemTemplate>
             </asp:Repeater>
             </div>

             <div>
                 Date: <%#Eval("OrderDate") %> <br />
                 Total Price:  <%#Eval("TotalPrice") %>$
             </div>

             <div>
                 Amounts: <%# String.Join(", ", (IEnumerable<int>)Eval("FoodAmounts")) %>
             </div>

         </ItemTemplate>

         <SeparatorTemplate>
             <br />
         </SeparatorTemplate>

     </asp:Repeater>

    <asp:Label ID="noOrdersLable" runat="server" Text=""></asp:Label>
</asp:Content>

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
                         Description:</strong> <%# Eval("ItemDescription") %> |
                         Price:</strong> $<%# Eval("ItemPrice") %>
                     </li>
                 </ItemTemplate>
             </asp:Repeater>
             </div>

             <div>
                 Date: <%#Eval("OrderDate") %>
             </div>

             <div>
                 Amounts: <%# String.Join(", ", (IEnumerable<int>)Eval("FoodAmounts")) %>
             </div>

         </ItemTemplate>

         <SeparatorTemplate>
             <br />
         </SeparatorTemplate>

     </asp:Repeater>
</asp:Content>

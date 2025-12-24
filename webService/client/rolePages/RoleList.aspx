<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="RoleList.aspx.cs" Inherits="client.rolePages.RoleList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Role list</h1> <br />
    <a href="RoleAdd.aspx">Add a role</a> <br />
 
     <asp:Repeater ID="roleRepeater" runat="server">
         <ItemTemplate>

             Role ID: <%#Eval("RoleId")%>) <br />
             Role Tag: <%#Eval("RoleTag") %> <br />
            <a href='RoleUpdate.aspx?roleId=<%# Eval("RoleId") %>'>update</a>
         </ItemTemplate>

         <SeparatorTemplate>
             <br />
         </SeparatorTemplate>

     </asp:Repeater>
</asp:Content>

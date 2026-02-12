<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="client.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>User lists</h1>
    <a href="AddUser.aspx">Add User</a>
    <hr />
    <asp:Repeater ID="userRepeater" runat="server">
        <ItemTemplate>


            UserId: <%#Eval("UserId")%>  <br />
            UserName: <%#Eval("UserName") %> <br />
            
            <a href='UserProfile.aspx?userId=<%# Eval("UserId") %>'>View</a> <br />
            <a href='OrderFood.aspx?roleId=<%# Eval("RoleTag.RoleId") %>&userId=<%# Eval("UserId") %>'>
                Go To Order</a>

            <hr />
        </ItemTemplate>

        <SeparatorTemplate>
            <br />
        </SeparatorTemplate>

    </asp:Repeater>
</asp:Content>

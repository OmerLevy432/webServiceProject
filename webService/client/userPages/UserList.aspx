<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="client.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>User lists</h1>
    <a href="AddUser.aspx">Add User</a>
    <hr />
    <asp:Repeater ID="userRepeater" runat="server">
        <ItemTemplate>
            <!--  Id) username - email, password, tah -->
            <!-- link to orders history  -->
            <%#Eval("UserId")%>) 
            <%#Eval("UserName") %> - Email : <%#Eval("UserEmail") %>, Password : <%#Eval("UserPassword") %>,
            Role ID : <%#Eval("RoleTag.RoleTag")%>
            <br />
            <a href='userPurchaseHistory.aspx?userId=<%# Eval("UserId") %>'>View Purchases</a>
            <a href='updateUser.aspx?userId=<%# Eval("UserId") %>'>Update User</a>
        </ItemTemplate>

        <SeparatorTemplate>
            <br />
        </SeparatorTemplate>

    </asp:Repeater>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="reviewList.aspx.cs" Inherits="client.userPages.reviewList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Reviews</h1> <br />

    <asp:Repeater ID="reviewsRepeater" runat="server">
        <ItemTemplate>
            <%#Eval("content") %> <br />
        </ItemTemplate>

        <SeparatorTemplate>
            <br />
        </SeparatorTemplate>

    </asp:Repeater>
</asp:Content>

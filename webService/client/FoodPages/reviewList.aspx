<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="reviewList.aspx.cs" Inherits="client.userPages.reviewList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Reviews</h1> <br />

    <asp:TextBox 
    ID="reviewTextBox" 
    runat="server" 
    TextMode="MultiLine" 
    Rows="5" 
    Columns="40">
    </asp:TextBox>
    <asp:Button ID="AddReviewButton" runat="server" Text="Add Review" OnClick="AddReviewButton_Click"/> <br />


    <asp:Repeater ID="reviewsRepeater" runat="server">
        <ItemTemplate>
            <%# Eval("content") %> <br />
        </ItemTemplate>
        <SeparatorTemplate>
            <br />
        </SeparatorTemplate>
    </asp:Repeater>

    <asp:Label ID="lblNoReviews" runat="server" Text="There Are No Reviews" Visible="false" />

</asp:Content>

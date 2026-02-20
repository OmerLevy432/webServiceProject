<%@ Page Title="" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="FoodList.aspx.cs" Inherits="client.FoodPages.FoodList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Food lists</h1> <br />
    <%=addString %>

<asp:Repeater ID="foodRepeater" runat="server" OnItemDataBound="foodRepeater_ItemDataBound">
    <ItemTemplate>
            <a href="#"><img src="<%# Eval("ImageUrl") %>" alt="Food Image" width="100" height="100" /></a><br />
            Creator ID: <%#Eval("UserId") %> <br />
            Price: <%#Eval("ItemPrice") %> <br />
            Description : <%#Eval("ItemDescription") %> <br />
            <asp:LinkButton ID="btnViewReviews" runat="server" CommandArgument="123" OnCommand="btnViewReviews_Command">View Reviews</asp:LinkButton>
            
            <asp:LinkButton ID="btnUpdateItem" runat="server" 
            Text="Update Item"
            Visible="false"
            CommandArgument='<%# Eval("ItemId") %>' 
            OnCommand="btnUpdateItem_Command">
        </asp:LinkButton>
          

        </ItemTemplate>

        <SeparatorTemplate>
            <br />
        </SeparatorTemplate>

    </asp:Repeater>

</asp:Content>

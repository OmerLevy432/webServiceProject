<%@ Page Title="Food Menu" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="FoodList.aspx.cs" Inherits="client.FoodPages.FoodList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/stylesheets/foodList.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="page-container">
        <div class="page-header">
            <h1>Our Menu</h1>
            <p class="status-message"><%=addString %></p>
        </div>

        <div class="menu-grid">
            <asp:Repeater ID="foodRepeater" runat="server" OnItemDataBound="foodRepeater_ItemDataBound">
                <ItemTemplate>
                    <div class="menu-card">
                        
                        <div class="menu-image">
                            <img src='<%# Eval("ImageUrl") %>' alt="Food Item" />
                        </div>
                        
                        <div class="menu-content">
                            <div class="menu-header">
                                <span class="menu-price">$<%# Eval("ItemPrice") %></span>
                                <span class="menu-creator">Chef ID: <%# Eval("UserId") %></span>
                            </div>
                            
                            <p class="menu-description">
                                <%# Eval("ItemDescription") %>
                            </p>
                            
                            <div class="menu-actions">
                                <asp:LinkButton ID="btnViewReviews" runat="server" 
                                    CssClass="btn btn-outline" 
                                    CommandArgument='<%# Eval("ItemId") %>' 
                                    OnCommand="btnViewReviews_Command">
                                    View Reviews
                                </asp:LinkButton>
                                
                                <asp:LinkButton ID="btnUpdateItem" runat="server" 
                                    CssClass="btn btn-primary" 
                                    Text="Update Item" 
                                    Visible="false" 
                                    CommandArgument='<%# Eval("ItemId") %>' 
                                    OnCommand="btnUpdateItem_Command">
                                </asp:LinkButton>
                            </div>
                        </div>

                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>
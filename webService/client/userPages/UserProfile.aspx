<%@ Page Title="My Profile" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="client.userPages.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/stylesheets/userProfileStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="page-container">
        
        <asp:Repeater ID="userRepeater" runat="server">
            <ItemTemplate>
                <div class="profile-card">
                    <div class="profile-main">
                        <div class="profile-avatar">
                            <%# Eval("UserName").ToString().Substring(0,1).ToUpper() %>
                        </div>
                        <div class="profile-info">
                            <h2><%# Eval("UserName") %></h2>
                            <p class="email"><%# Eval("UserEmail") %></p>
                            <span class="role-badge"><%# Eval("RoleTag.RoleTag") %></span>
                        </div>
                    </div>
                    <div class="profile-actions">
                        <a href="OrderFood.aspx" class="btn btn-primary">Order Food</a>
                        <a href="updateUser.aspx" class="btn btn-outline">Edit Account</a>
                    </div>
                    <div class="user-id-tag">UID: #<%# Eval("UserId") %></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <hr class="section-divider" />

        <div class="history-section">
            <div class="section-header">
                <h3>Purchase History</h3>
            </div>

            <div class="history-list">
                <asp:Repeater ID="repeaterPurchases" runat="server">
                    <ItemTemplate>
                        <div class="history-card">
                            <div class="history-top">
                                <div class="order-meta">
                                    <span class="order-date">🗓️ <%# Eval("OrderDate", "{0:MMM dd, yyyy}") %></span>
                                </div>
                                <div class="order-total">
                                    Total: <span>$<%# Eval("TotalPrice") %></span>
                                </div>
                            </div>
                            
                            <div class="order-items">
                                <ul>
                                    <asp:Repeater ID="InnerRepeater" runat="server" DataSource='<%# Eval("FoodItems") %>'>
                                        <ItemTemplate>
                                            <li>
                                                <span class="item-name"><%# Eval("ItemDescription") %></span>
                                                <span class="item-price">$<%# Eval("ItemPrice") %></span>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>

                            <div class="order-footer">
                                <small>Quantities: <%# String.Join(", ", (IEnumerable<int>)Eval("FoodAmounts")) %></small>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <asp:Label ID="noOrdersLable" runat="server" CssClass="empty-msg" Text=""></asp:Label>
        </div>
    </div>

</asp:Content>
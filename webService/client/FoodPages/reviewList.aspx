<%@ Page Title="Reviews" Language="C#" MasterPageFile="~/adminMaster.Master" AutoEventWireup="true" CodeBehind="reviewList.aspx.cs" Inherits="client.userPages.reviewList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/stylesheets/reviewsStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="page-container">
        
        <div class="page-header">
            <h1>Customer Reviews</h1>
        </div>

        <div class="review-form-container">
            <asp:TextBox 
                ID="reviewTextBox" 
                runat="server" 
                TextMode="MultiLine" 
                Rows="4" 
                CssClass="review-input"
                placeholder="Write your review here..."
                Visible="false">
            </asp:TextBox>
            
            <asp:Button 
                ID="AddReviewButton" 
                runat="server" 
                Text="Post Review" 
                CssClass="btn btn-primary submit-review-btn" 
                OnClick="AddReviewButton_Click" 
                Visible="false" />
        </div>

        <div class="reviews-list">
            <asp:Repeater ID="reviewsRepeater" runat="server">
                <ItemTemplate>
                    <div class="review-card">
                        <div class="review-avatar">👤</div>
                        <div class="review-content">
                            <p class="review-text">"<%# Eval("content") %>"</p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <asp:Label 
                ID="lblNoReviews" 
                runat="server" 
                Text="There are no reviews yet. Be the first to leave one!" 
                CssClass="empty-state" 
                Visible="false" />
        </div>

    </div>

</asp:Content>
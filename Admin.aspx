<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Assignment_3.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="gallerised/styles/forms.css" rel="stylesheet" />
    <link href="gallerised/styles/layout.css" rel="stylesheet" />
    <link href="gallerised/styles/navi.css" rel="stylesheet" />
    <link href="gallerised/styles/tables.css" rel="stylesheet" />

        <a class="fl_left"> <asp:Label ID="lblWelcome" runat="server" Text="Welcome Admin Client!"></asp:Label> </a><br /><br />
            <h2>
            <a href="ProductMgmt.aspx">Product Management - Add/Edit/Delete Products</a>
            </h2>
            <h2>
            <a href="Orders.aspx">View Orders</a>
            </h2>   
            <h2>
            <a href="SalesByCustomer.aspx">View Total Sales Per Customer.</a>
            </h2>
            <h2>
            <a href="SalesByItem.aspx">View Total Sales Per Item (in Dollars).</a>
            </h2>
            <h2>
            <a href="SalesByItemQuantity.aspx">View Units Sold Per Item.</a>
            </h2>

</asp:Content>


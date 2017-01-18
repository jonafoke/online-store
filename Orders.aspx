<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Assignment_3.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="gallerised/styles/forms.css" rel="stylesheet" />
    <link href="gallerised/styles/layout.css" rel="stylesheet" />
    <link href="gallerised/styles/navi.css" rel="stylesheet" />
    <link href="gallerised/styles/tables.css" rel="stylesheet" />

    <a class="fl_left"> <asp:Label ID="lblWelcome" runat="server" Text="Welcome Admin Client!"></asp:Label> </a><br /><br />
    <div class="wrapper">
        <asp:Button ID="btnBack" runat="server" Text="Back to Admin Home" OnClick="btnBack_Click" /><br /><br />
        <h1>View Orders</h1><br /><br />
        <asp:GridView ID="gvOrders" runat="server" AllowPaging="True" AllowSorting="True" DataKeyNames="OrderID" PageSize="5" AutoGenerateColumns="False" OnPageIndexChanging="gvOrders_PageIndexChanging" OnSorting="gvOrders_Sorting">
            <Columns>
                <asp:BoundField DataField="OrderID" HeaderText="Order Id" SortExpression="OrderID" />
                <asp:BoundField DataField="OrderDate" HeaderText="Order Date" SortExpression="OrderDate" />
                <asp:BoundField DataField="CustomerID" HeaderText="Customer Id" SortExpression="CustomerID" />
                <asp:BoundField DataField="LastName" HeaderText="Customer Last Name" SortExpression="LastName" />
                <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" SortExpression="TotalPrice" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>


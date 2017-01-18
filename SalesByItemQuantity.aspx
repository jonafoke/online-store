<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SalesByItemQuantity.aspx.cs" Inherits="Assignment_3.WebForm15" %>
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
        <h1>Quantity of each Item Sold (in Units)</h1><br /><br />

        <asp:GridView ID="gvItemQuantitySold" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gvItemQuantitySold_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Product Name" />
                <asp:BoundField DataField="Units_Sold" HeaderText="Quantity Sold" />
            </Columns>
        </asp:GridView>

    </div>

</asp:Content>


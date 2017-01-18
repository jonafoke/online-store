<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SalesByCustomer.aspx.cs" Inherits="Assignment_3.WebForm13" %>
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
        <h1>What Each Customer Has Spent</h1><br /><br />

        <asp:GridView ID="gvSalesCustomer" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="5" OnPageIndexChanging="gvSalesCustomer_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="Total_Spent" HeaderText="Total Spent" />
            </Columns>
        </asp:GridView>

    </div>

</asp:Content>


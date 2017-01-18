<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AllProducts.aspx.cs" Inherits="Assignment_3.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="gallerised/styles/forms.css" rel="stylesheet" />
    <link href="gallerised/styles/layout.css" rel="stylesheet" />
    <link href="gallerised/styles/navi.css" rel="stylesheet" />
    <link href="gallerised/styles/tables.css" rel="stylesheet" />
    
    <div class ="wrapper">    
        <h1>All Products</h1>
        <asp:DataList ID="dlProducts" runat="server" RepeatColumns="3" Width="950px" OnItemCommand="dlProducts_ItemCommand" OnSelectedIndexChanged="dlProducts_SelectedIndexChanged">

            <ItemTemplate>
            <div>
                <a'<%# Eval("ProductID", "ProductInfo.aspx?ProductID={0}") %>'>
                 <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("ImagePath") %>' style="width:110px;height:110px" />
                </a>
                <br />
                <b>Item:</b> <%#Eval("Name") %><br />
                <b>Price:</b><%#Eval("Price") %><br />
                <b>Description:</b><%#Eval("Description") %><br />
                <b>ProductID:</b><asp:label runat="server" ID="lblProductID" Text='<%#Eval("ProductID") %>'></asp:label><br />
                <asp:button id="btnAdd" runat="server" text="Add To Cart" CommandName="add" /><br /><br />
            </div>
        </ItemTemplate>

        </asp:DataList>
    </div>
</asp:Content>


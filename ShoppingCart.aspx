<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="Assignment_3.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     
    <link href="gallerised/styles/forms.css" rel="stylesheet" />
    <link href="gallerised/styles/layout.css" rel="stylesheet" />
    <link href="gallerised/styles/navi.css" rel="stylesheet" />
    <link href="gallerised/styles/tables.css" rel="stylesheet" />

    <div class="wrapper">
    <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" OnRowCommand="gvCart_RowCommand" OnRowDataBound="gvCart_RowDataBound" ShowFooter="True">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" SortExpression="ProductID" Visible="False" />
            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
            <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" SortExpression="Price" />
            <asp:TemplateField HeaderText="Quantity">
            
                <ItemTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox><br />
                    <asp:LinkButton ID="btnRemove" runat="server" CommandName="Remove" CommandArgument='<%# Bind("ProductID")%>'>Remove</asp:LinkButton>
                </ItemTemplate>
            
            </asp:TemplateField>
            <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" />
        </Columns>
    </asp:GridView><br />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="fl_left" OnClick="btnUpdate_Click" />
        <br /><br />
        <asp:Panel ID="PanelInput" runat="server">
    <p>Once your cart quantities are correct, please give us the following:</p>
    <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                </td>
                <td><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                </td>
                <td><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                <asp:Label ID="lblCityProv" runat="server" Text="City/Prov"></asp:Label></td>
               <td>
                    <asp:TextBox ID="txtCityProv" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                 <asp:Label ID="lblPostal" runat="server" Text="Postal Code"></asp:Label></td>
                 <td><asp:TextBox ID="txtPostal" runat="server"></asp:TextBox>
                </td>
            </tr>
    </table><br />
            </asp:Panel>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit Your Order!" OnClick="btnSubmit_Click"/>

        </div>

</asp:Content>

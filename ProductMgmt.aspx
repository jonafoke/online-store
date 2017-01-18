<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductMgmt.aspx.cs" Inherits="Assignment_3.WebForm8" %>
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
        <h1>Product Management</h1><br /><br />

        <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" OnRowCommand="gvProducts_RowCommand" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="gvProducts_PageIndexChanging" OnSorting="gvProducts_Sorting" PageSize="5">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Delete Product" Text="Delete" />
                <asp:ButtonField ButtonType="Button" CommandName="Edit Product" Text="Edit" />
                <asp:BoundField DataField="ProductID" HeaderText="Product Id" SortExpression="ProductID" />
                <asp:BoundField DataField="Name" HeaderText="Product Name" SortExpression="Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="ImagePath" HeaderText="ImageUrl" />
                <asp:BoundField DataField="CategoryID" HeaderText="Category Id" SortExpression="CategoryID" />
            </Columns>
        </asp:GridView>
        <br /><br />
        <asp:Button ID="btnAddNew" runat="server" Text="Add New Product" OnClick="btnAddNew_Click" />
        <asp:Panel ID="PanelInput" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Please include the product name.">*</asp:RequiredFieldValidator>
                </td>
                </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription" ErrorMessage="Please include a description of the product.">*</asp:RequiredFieldValidator>
                </td>
                </tr>
             <tr>
                <td>
                    <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter a product price." ControlToValidate="txtPrice">*</asp:RequiredFieldValidator>
                </td>
             </tr>
            
            <tr>
                <td>
                    <asp:Label ID="lblCategoryId" runat="server" Text="Category Id"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCategoryID" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCategoryID" ErrorMessage="Please include a Category Code (1-Footwear; 2-Clothing; 3-Sporting Goods.)">*</asp:RequiredFieldValidator>
                </td>
                </tr>
             <tr>
                <td>
                    <asp:Label ID="lblProductImage" runat="server" Text="Product Image to Upload"></asp:Label> 
                    <asp:FileUpload ID="uploadImage" runat="server" />
                </td>
            </tr>

             <tr>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="False" />
                </td>
                <td>
                     <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                </td>
             </tr>
           
        </table>
        </asp:Panel>
        <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="The following field(s) are required:" />


    </div>

</asp:Content>

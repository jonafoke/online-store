<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Assignment_3.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="gallerised/styles/forms.css" rel="stylesheet" />
    <link href="gallerised/styles/layout.css" rel="stylesheet" />
    <link href="gallerised/styles/navi.css" rel="stylesheet" />
    <link href="gallerised/styles/tables.css" rel="stylesheet" />
   
    
    <h2>Please log in to your account!</h2>
    <br />

<div>
<asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label><br />
    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="USERNAME REQUIRED!"></asp:RequiredFieldValidator>
    <br /><br />
    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label><br />
    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="PASSWORD REQUIRED!"></asp:RequiredFieldValidator>
    <br /><br />
    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /><br />
    </div>
    




</asp:Content>


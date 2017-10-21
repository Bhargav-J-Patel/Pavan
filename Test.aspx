<%@ Page Title="" Language="C#" MasterPageFile="~/PavanCourier.master" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
Select File:
<asp:FileUpload ID="FileUpload1" runat="server" />
<asp:Button ID="Button1" Text="Upload" runat="server"  />

<%--OnClick="Upload"--%>

<hr />
<asp:Label ID="lblText" runat="server" />

</asp:Content>


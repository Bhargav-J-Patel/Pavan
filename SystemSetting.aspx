<%@ Page Title="" Language="C#" MasterPageFile="~/PavanCourier.master" AutoEventWireup="true"
    CodeFile="SystemSetting.aspx.cs" Inherits="SystemSetting" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="success" runat="server" id="divsucess" visible="false">
        <asp:Label ID="lblsucess" runat="server" Text=""></asp:Label></div>
    <div class="warning" runat="server" id="DivWarning" visible="false">
        <asp:Label ID="LblWarning" runat="server" Text=""></asp:Label></div>
    <div class="error" runat="server" id="diverror" visible="false">
        <asp:Label ID="lblerror" runat="server" Text=""></asp:Label></div>
    <div class="row">
        <div class="col-xs-12 col-sm-11">
            <div class="widget-box">
                <div class="widget-header">
                    <div style="float: left">
                        <h4 class="widget-title">
                            System Setting</h4>
                    </div>
                    <div style="float: right;">
                    </div>
                </div>
                <div class="widget-body">
                    <table class="commontable">
                        <tr>
                            <th width="200px;">
                                Cash Booking Default Weight :
                            </th>
                            <td>
                                <asp:TextBox runat="server" TabIndex="1" ID="TxtCashWeight" class="txtbox bgcolrred"
                                    onkeypress="return validateKeyPress(event,validNums)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th width="200px;">
                                Credit Booking Default Weight :
                            </th>
                            <td>
                                <asp:TextBox runat="server" TabIndex="2" ID="TxtCreditWeight" class="txtbox bgcolrred"
                                    onkeypress="return validateKeyPress(event,validNums)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th width="200px;">
                                Service Tax No On Cash Booking Print :
                            </th>
                            <td>
                                <asp:DropDownList runat="server" ID="DDLServTaxNo">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Weight in Manifest Print :
                            </th>
                            <td>
                                <asp:DropDownList runat="server" ID="DDLManifestPrint">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnsubmit" Text="Submit" runat="server" class="btn btn-info" OnClick="btnsubmit_Click"
                                    ValidationGroup="Main" TabIndex="12" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

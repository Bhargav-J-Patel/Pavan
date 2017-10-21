<%@ Page Title="Stock Inward" Language="C#" MasterPageFile="~/PavanCourier.master"
    AutoEventWireup="true" CodeFile="TranStockInward.aspx.cs" Inherits="TranStockInward" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('input,.select,.buttoncss').bind('keypress', function (eInner) {
                if (eInner.keyCode == 13) //if its a enter key
                {
                    var tabindex = $(this).attr('tabindex');
                    tabindex++; //increment tabindex
                    //after increment of tabindex ,make the next element focus
                    if ($('[tabindex=' + tabindex + ']').is(':hidden') == true || $('[tabindex=' + tabindex + ']').is(':hidden') == undefined) {
                        tabindex++; //increment tabindex
                    }
                    $('[tabindex=' + tabindex + ']').focus();
                    return false; // to cancel out Onenter page postback in asp.net
                }
            });
            $("input:text").focus(function () {
                $(this).select();
            });
        });
    </script>
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
                            Stock Inward</h4>
                    </div>
                    <div style="float: right;">
                        <asp:Button ID="btnlist" Text="List" runat="server" class="btn btn-primary" TabIndex="8"
                            Style="margin-top: 4px; margin-right: 3px;" OnClick="btnlist_Click" UseSubmitBehavior="false" />
                    </div>
                </div>
                <div class="widget-body">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <table class="commontable">
                                <tr>
                                    <th width="100px;">
                                        Date :
                                    </th>
                                    <td width="190px;">
                                        <asp:TextBox ID="txtissuedate" runat="server" CssClass="txtbox date_picker" TabIndex="1"
                                            Width="120px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtfrom_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                            CssClass="cal_Theme1" TargetControlID="txtissuedate"></cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtissuedate"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                            InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        AWB No From:
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" class="txtbox bgcolrred" ID="txtfromawbno" Style="text-align: right"
                                            onkeypress="return validateKeyPress(event,validNums)" TabIndex="2" Width="150px" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfromawbno"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                            ValidationGroup="Main"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th width="100px;">
                                        AWB No To:
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" class="txtbox bgcolrred" ID="txttoawbno" AutoPostBack="true"
                                            onkeypress="return validateKeyPress(event,validNums)" TabIndex="3" Style="text-align: right"
                                            OnTextChanged="txttoamwno_TextChanged" Width="150px" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttoawbno"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                            ValidationGroup="Main"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Total
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" class="col-xs-8 txtbox" ID="txttotal" Enabled="false"
                                            Style="text-align: right" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddldelete" runat="server" Visible="false" TabIndex="5">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Button ID="btnsubmit" Text="Submit" runat="server" class="btn btn-info" OnClick="btnsubmit_Click"
                                               ValidationGroup="Main" TabIndex="4" />
                                        <asp:Button ID="btnreset" Text="Reset" runat="server" class="btn resetbtn" TabIndex="5"
                                            OnClick="btnreset_Click" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

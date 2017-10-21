<%@ Page Title="Copy Contract" Language="C#" MasterPageFile="~/PavanCourier.master"
    AutoEventWireup="true" CodeFile="TranCopyContract.aspx.cs" Inherits="TranCopyContract" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        function select_contract(sender, e) {
            var hd = $get("<%=HifContract.ClientID %>");
            hd.value = e.get_value();
        }
    </script>
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
    <asp:UpdatePanel ID="updatepanel5" runat="server">
        <ContentTemplate>
            <div class="success" runat="server" id="divsucess" visible="false">
                <asp:Label ID="lblsucess" runat="server" Text=""></asp:Label></div>
            <div class="warning" runat="server" id="DivWarning" visible="false">
                <asp:Label ID="LblWarning" runat="server" Text=""></asp:Label></div>
            <div class="error" runat="server" id="diverror" visible="false">
                <asp:Label ID="lblerror" runat="server" Text=""></asp:Label></div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="row">
        <div class="col-xs-12 col-sm-11">
            <div class="widget-box">
                <div class="widget-header">
                    <div style="float: left">
                        <h4 class="widget-title">
                            Copy Contract</h4>
                    </div>
                    <div style="float: right;">
                    </div>
                </div>
                <div class="widget-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table class="commontable">
                                <tr>
                                    <th style="width: 130px;">
                                        Contract :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtcontract" class="txtbox bgcolrgreen" TabIndex="1"
                                            Width="200px" />
                                        <cc1:AutoCompleteExtender ServiceMethod="SearchContract" MinimumPrefixLength="1"
                                            OnClientItemSelected="select_contract" CompletionInterval="100" EnableCaching="false"
                                            CompletionSetCount="10" TargetControlID="txtcontract" CompletionListCssClass="AutoComplete_completionListElement"
                                            CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem"
                                            ID="AutoCompleteExtender2" runat="server" FirstRowSelected="false">
                                        </cc1:AutoCompleteExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcontract"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                            ValidationGroup="Main"></asp:RequiredFieldValidator>
                                        <asp:HiddenField ID="HifContract" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Contract Name :
                                    </th>
                                    <td>
                                        <asp:TextBox ID="TxtNewConName" CssClass="txtbox" runat="server" Width="200px" TabIndex="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtNewConName"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='EDIT' alt='View' border='0'/&gt;"
                                            ValidationGroup="Main"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="btn btn-info" TabIndex="3"
                                            ValidationGroup="Main" OnClick="BtnSave_Click" />
                                        <asp:Button ID="Btnreset" Text="Reset" runat="server" class="btn resetbtn" OnClick="Btnreset_Click"
                                            TabIndex="4" />
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

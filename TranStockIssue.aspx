<%@ Page Title="Stock Issue" Language="C#" MasterPageFile="~/PavanCourier.master"
    AutoEventWireup="true" CodeFile="TranStockIssue.aspx.cs" Inherits="TranStockIssue" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function select_cus(sender, e) {
            var hd = $get("<%=HifCus.ClientID %>");
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                            Stock Issue</h4>
                    </div>
                    <div style="float: right;">
                        <asp:Button ID="btnlist" Text="List" runat="server" class="btn btn-primary" TabIndex="9"
                            Style="margin-top: 4px; margin-right: 3px;" OnClick="btnlist_Click" UseSubmitBehavior="false" />
                    </div>
                </div>
                <div class="widget-body">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <table class="commontable">
                                <tr>
                                    <th width="100px;">
                                        Issue To :
                                    </th>
                                    <td width="180px;">
                                        <asp:DropDownList runat="server" ID="ddlIssueTo" TabIndex="1">
                                            <asp:ListItem Value="c">Customer</asp:ListItem>
                                            <asp:ListItem Value="A">Agent</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <th width="100px;">
                                        Issue Date :
                                    </th>
                                    <td width="180px;">
                                        <asp:TextBox ID="txtissuedate" runat="server" CssClass="txtbox date_picker" TabIndex="2"
                                            Width="120px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtfrom_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                            CssClass="cal_Theme1" TargetControlID="txtissuedate"></cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtissuedate"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                            InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Customer :
                                    </th>
                                    <td colspan="3">
                                        <asp:TextBox runat="server" ID="txtcusname" class="txtbox bgcolrgreen" TabIndex="3"
                                            Width="200px" />
                                        <cc1:AutoCompleteExtender ServiceMethod="SearchCus" MinimumPrefixLength="1" OnClientItemSelected="select_cus"
                                            CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtcusname"
                                            ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false" CompletionListCssClass="AutoComplete_completionListElement"
                                            CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                        </cc1:AutoCompleteExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcusname"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                            InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                        <asp:HiddenField ID="HifCus" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        AWB No From :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" class="txtbox bgcolrred" ID="txtfromamwno" Style="text-align: right"
                                            TabIndex="4" Width="150px" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfromamwno"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                            InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        AWB No To :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" class="txtbox bgcolrred" ID="txttoamwno" TabIndex="5"
                                            AutoPostBack="true" Style="text-align: right" OnTextChanged="txttoamwno_TextChanged"
                                            Width="150px" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txttoamwno"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                            InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Total :
                                    </th>
                                    <td colspan="3">
                                        <asp:TextBox runat="server" class="col-xs-8 txtbox" ID="txttotal" Enabled="false"
                                            Width="100px" Style="text-align: right" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddldelete" runat="server" Visible="false" TabIndex="6">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Button ID="btnsubmit" Text="Submit" runat="server" class="btn btn-info" OnClick="btnsubmit_Click"
                                            ValidationGroup="Main" TabIndex="6" />
                                        <asp:Button ID="btnreset" Text="Reset" runat="server" class="btn resetbtn" TabIndex="7"
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

<%@ Page Title="Courier Master" Language="C#" MasterPageFile="~/PavanCourier.master"
    AutoEventWireup="true" CodeFile="MasterCourier.aspx.cs" Inherits="MasterCourier" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function select_name(sender, e) {
            var hd = $get("<%=HifCname.ClientID %>");
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
                            Delivery Boy</h4>
                    </div>
                    <div style="float: right;">
                        <asp:Button ID="btnlist" Text="List" runat="server" class="btn btn-primary" Style="margin-top: 4px;
                            margin-right: 3px;" OnClick="btnlist_Click" UseSubmitBehavior="false" />
                    </div>
                </div>
                <div class="widget-body">
                    <table class="commontable">
                        <tr>
                            <th width="100px;">
                                Sr No :
                            </th>
                            <td width="200px">
                                <asp:TextBox runat="server" ID="txtsrno" class="txtbox bgcolrblue" Width="80px" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <th width="100px;">
                                Code :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtcouriercode" class="txtbox bgcolrblue" Width="80px"
                                    TabIndex="1" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcouriercode"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Name :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtcouriername" class="txtbox bgcolrgreen" TabIndex="2" />
                                <cc1:AutoCompleteExtender ServiceMethod="SearchCName" MinimumPrefixLength="1" OnClientItemSelected="select_name"
                                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtcouriername"
                                    CompletionListCssClass="AutoComplete_completionListElement" CompletionListItemCssClass="AutoComplete_listItem"
                                    CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem" ID="AutoCompleteExtender1"
                                    runat="server" FirstRowSelected="false">
                                </cc1:AutoCompleteExtender>
                                <asp:HiddenField ID="HifCname" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcouriername"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                1kG Rate :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtcommission" class="txtbox bgcolrred" Style="text-align: right"
                                    onkeypress="return validateKeyPress(event,validNums)" TabIndex="3" />
                            </td>
                            <th>
                                Extra Rate :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="TxtExtraRate" class="txtbox bgcolrred" Style="text-align: right"
                                    onkeypress="return validateKeyPress(event,validNums)" TabIndex="4" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Mobile No :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtmobno" class="txtbox bgcolrblue" TabIndex="5" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:DropDownList ID="ddldelete" runat="server" Visible="false">
                                    <asp:ListItem>No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button ID="btnsubmit" Text="Submit" runat="server" class="btn btn-info" OnClick="btnsubmit_Click"
                                    ValidationGroup="Main" TabIndex="6" />
                                <asp:Button ID="Button2" Text="Reset" runat="server" class="btn resetbtn" OnClick="Button2_Click"
                                    TabIndex="7" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

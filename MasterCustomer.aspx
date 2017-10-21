<%@ Page Title="Customer Master" Language="C#" MasterPageFile="~/PavanCourier.master"
    AutoEventWireup="true" CodeFile="MasterCustomer.aspx.cs" Inherits="MasterCustomer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function select_location(sender, e) {
            var hd = $get("<%=HifLocation.ClientID %>");
            hd.value = e.get_value();
        }
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
    <div class="success" runat="server" id="divsucess" visible="false">
        <asp:Label ID="lblsucess" runat="server" Text=""></asp:Label>
    </div>
    <div class="warning" runat="server" id="DivWarning" visible="false">
        <asp:Label ID="LblWarning" runat="server" Text=""></asp:Label>
    </div>
    <div class="error" runat="server" id="diverror" visible="false">
        <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
    </div>
    <div class="row">
        <div class="col-xs-12 col-sm-11">
            <div class="widget-box">
                <div class="widget-header">
                    <div style="float: left">
                        <h4 class="widget-title">
                            Customer Master</h4>
                    </div>
                    <div style="float: right;">
                        <asp:Button ID="btnlist" Text="List" runat="server" class="btn btn-primary" TabIndex="15"
                            Style="margin-top: 4px; margin-right: 3px;" OnClick="btnlist_Click" UseSubmitBehavior="false" />
                    </div>
                </div>
                <div class="widget-body">
                    <table class="commontable" style="width: 100%;">
                        <tr>
                            <th width="100px;">
                                Code :
                            </th>
                            <td width="330px">
                                <asp:TextBox runat="server" ID="txtcuscode" class="txtbox bgcolrblue" TabIndex="1"
                                    Width="80px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtcuscode"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Name :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtcusname" class="txtbox bgcolrblue" TabIndex="2"
                                    Width="300px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcusname"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Address :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtaddress" class="bgcolrblue" TextMode="MultiLine"
                                    TabIndex="3" Height="95px" Width="300px" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Location :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtlocation" class="txtbox bgcolrgreen" TabIndex="4"
                                    Width="200px" />
                                <cc1:AutoCompleteExtender ServiceMethod="SearchLocation" MinimumPrefixLength="1"
                                    OnClientItemSelected="select_location" CompletionInterval="100" EnableCaching="false"
                                    CompletionSetCount="10" TargetControlID="txtlocation" CompletionListCssClass="AutoComplete_completionListElement"
                                    CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem"
                                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                </cc1:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtlocation"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="HifLocation" runat="server" />
                            </td>
                            <th>
                                Email Id :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtemailid" class="txtbox bgcolrblue" TabIndex="5"
                                    Width="300px" />
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtemailid"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Phone No :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="TxPhNo" class="txtbox bgcolrblue" TabIndex="6" Width="200px" />
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtmobile"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>--%>
                            </td>
                            <th>
                                Mobile No :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtmobile" class="txtbox bgcolrblue" TabIndex="7"
                                    Width="200px" />
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtmobile"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Birth Date :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtdob" class="txtbox date_picker" TabIndex="8" Width="150px" />
                                <cc1:CalendarExtender ID="txtfrom_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                    CssClass="cal_Theme1" TargetControlID="txtdob"></cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Payment Type :
                            </th>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlpaymenttype" TabIndex="9" Width="100px" CssClass="select">
                                    <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                    <asp:ListItem Value="Credit">Credit</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            
                        </tr>
                        <tr>
                            <th>
                                Charge :
                            </th>
                            <td>
                                <asp:Panel ID="PanelItem" runat="server" Height="100%" ScrollBars="Vertical" Style="overflow-x: hidden;
                                    overflow-y: auto;" TabIndex="11" Width="100%" CssClass="select">
                                    <asp:CheckBoxList ID="ChkCharge" runat="server" DataTextField="cChargeName" DataValueField="NID"
                                        RepeatColumns="7" Width="330px" CssClass="chkbox">
                                    </asp:CheckBoxList>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Contract :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtcontract" class="txtbox bgcolrgreen" TabIndex="12"
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
                            <td colspan="2">
                                <asp:DropDownList ID="ddldelete" runat="server" Visible="false" CssClass="common_select">
                                    <asp:ListItem>No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button ID="Button1" Text="Submit" runat="server" class="btn btn-info" ValidationGroup="Main"
                                    TabIndex="13" OnClick="Button1_Click" />
                                <asp:Button ID="Btnreset" Text="Reset" runat="server" class="btn resetbtn" OnClick="Btnreset_Click"
                                    TabIndex="14" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="Domestic Master" Language="C#" MasterPageFile="~/PavanCourier.master"
    AutoEventWireup="true" CodeFile="MasterDomestic.aspx.cs" Inherits="MasterDomestic" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function select_zone(sender, e) {
            var hd = $get("<%=HifZone.ClientID %>");
            hd.value = e.get_value();
        }
        function select_country(sender, e) {
            var hd = $get("<%=HifCountry.ClientID %>");
            hd.value = e.get_value();
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $('input,.select').bind('keypress', function (eInner) {
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
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
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
                            Destination Master</h4>
                    </div>
                    <div style="float: right;">
                        <asp:Button ID="btnlist" Text="List" runat="server" class="btn btn-primary" TabIndex="9"
                            Style="margin-top: 4px; margin-right: 3px;" OnClick="btnlist_Click" UseSubmitBehavior="false" />
                    </div>
                </div>
                <div class="widget-body">
                    <table class="commontable">
                        <tr>
                            <th width="130px;">
                                Sr No :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtsrno" class="txtbox bgcolrblue" Width="80px" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <th width="100px;">
                                Destination Code :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtdomesticcode" class="txtbox bgcolrblue" TabIndex="1"
                                    Width="80px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdomesticcode"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Destination Name :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtdomesticname" class="txtbox bgcolrblue" TabIndex="2" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdomesticname"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Contact Person Name :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="TxtCPersnName" class="txtbox bgcolrblue" TabIndex="3" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtCPersnName"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Phone No :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="TxtCNo" class="txtbox bgcolrblue" TabIndex="4" Width="180px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtCNo"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                         <tr>
                            <th>
                                Mobile No :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="TxtMobileNo" class="txtbox bgcolrblue" TabIndex="4" Width="180px" />
                                
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Address :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtdomesticaddress" class="bgcolrblue" TextMode="MultiLine"
                                    Height="80px" Width="170px" TabIndex="5" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Zone :
                            </th>
                            <td>
                                <asp:TextBox ID="txtzone" runat="server" class="txtbox bgcolrgreen" TabIndex="6"></asp:TextBox>
                                <cc1:AutoCompleteExtender ServiceMethod="SearchZone" MinimumPrefixLength="1" OnClientItemSelected="select_zone"
                                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtzone"
                                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false" CompletionListCssClass="AutoComplete_completionListElement"
                                    CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtzone"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="HifZone" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Country :
                            </th>
                            <td>
                                <asp:TextBox ID="txtcountry" runat="server" class="txtbox bgcolrgreen" TabIndex="7"></asp:TextBox>
                                <cc1:AutoCompleteExtender ServiceMethod="SearchCountry" MinimumPrefixLength="1" OnClientItemSelected="select_country"
                                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtcountry"
                                    ID="AutoCompleteExtender2" runat="server" FirstRowSelected="false" CompletionListCssClass="AutoComplete_completionListElement"
                                    CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtcountry"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="HifCountry" runat="server" />
                            </td>
                             <th>
                                        CSV File :&nbsp;&nbsp;
                                    </th>
                                     <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:FileUpload ID="FileUpload1" runat="server" Width="300px" ValidationGroup="FileUpload" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="FileUpload1"
                                                        ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                                        ValidationGroup="FileUpload" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnUpload" Text="Upload" runat="server" class="btn btn-info" ValidationGroup="FileUpload"
                                                        Width="70px" OnClick="BtnUpload_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:DropDownList ID="ddldelete" runat="server" Visible="false">
                                    <asp:ListItem>No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button ID="btnsubmit" Text="Submit" runat="server" class="btn btn-info" OnClick="btnsubmit_Click"
                                    ValidationGroup="Main" TabIndex="8" />
                                <asp:Button ID="btnreset" Text="Reset" runat="server" class="btn resetbtn" TabIndex="9" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

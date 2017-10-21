<%@ Page Title="" Language="C#" MasterPageFile="~/PavanCourier.master" AutoEventWireup="true"
    CodeFile="TranMultyCashBooking.aspx.cs" Inherits="TranMultyCashBooking" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                         Multy Cash Booking</h4>
                    </div>
                    <div style="float: right;">
                        <asp:Button ID="btnlist" Text="List" runat="server" class="btn btn-primary" TabIndex="12"
                            Style="margin-top: 4px; margin-right: 3px;" UseSubmitBehavior="false" />
                    </div>
                </div>
                <div class="widget-body">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <table class="commontable" width="100%">
                                <tr>
                                    <th style="width:100px">
                                        Date :
                                    </th>
                                    <td style="width:230px">
                                        <asp:TextBox ID="TxtDate" runat="server" CssClass="txtbox date_picker" Width="120px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtfrom_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                            CssClass="cal_Theme1" TargetControlID="TxtDate"></cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtDate"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                            InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                    </td>
                                    <th>
                                        Destination :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtdestination" class="txtbox bgcolrgreen" Width="200px"
                                            AutoPostBack="true" TabIndex="2" />
                                        <cc1:AutoCompleteExtender ServiceMethod="SearchDestination" MinimumPrefixLength="1"
                                            OnClientItemSelected="select_Destination" CompletionInterval="100" EnableCaching="false"
                                            CompletionSetCount="10" TargetControlID="txtdestination" ID="AutoCompleteExtender1"
                                            runat="server" FirstRowSelected="true" CompletionListCssClass="AutoComplete_completionListElement"
                                            CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                        </cc1:AutoCompleteExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdestination"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                            InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                        <asp:HiddenField ID="HifDestination" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Shipper :
                                    </th>
                                    <td>
                                        <asp:TextBox ID="TxtCustomer" runat="server" class="txtbox bgcolrblue" TabIndex="1"
                                            Width="200px" />
                                        <cc1:AutoCompleteExtender ServiceMethod="SearchCus" MinimumPrefixLength="1" CompletionInterval="100"
                                            EnableCaching="false" CompletionSetCount="10" TargetControlID="TxtCustomer" ID="AutoCompleteExtender3"
                                            runat="server" FirstRowSelected="true" CompletionListCssClass="AutoComplete_completionListElement"
                                            CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                        </cc1:AutoCompleteExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtCustomer"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                            InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                    </td>
                                    <th>
                                        Shipped To :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="TxtShippedTo" class="txtbox bgcolrblue" TabIndex="3"
                                            Width="200px" />
                                        <cc1:AutoCompleteExtender ServiceMethod="Searchrecv" MinimumPrefixLength="1" CompletionInterval="100"
                                            EnableCaching="false" CompletionSetCount="10" TargetControlID="TxtShippedTo"
                                            ID="AutoCompleteExtender4" runat="server" FirstRowSelected="true" CompletionListCssClass="AutoComplete_completionListElement"
                                            CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                        </cc1:AutoCompleteExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtShippedTo"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                            InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
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

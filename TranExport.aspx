<%@ Page Title="Export Data" Language="VB" MasterPageFile="~/PavanCourier.master" AutoEventWireup="false" CodeFile="TranExport.aspx.vb" Inherits="TranExport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                            <asp:Label ID="Lbltxt" runat="server" Text=""></asp:Label></h4>
                    </div>
                    <div style="float: right;">
                    </div>
                </div>
                <div class="widget-body">
                    <table class="commontable">
                        <tr id="trdate" runat="server">
                            <th width="70px;">
                                From Date :
                            </th>
                            <td width="180px">
                                <asp:TextBox runat="server" ID="txtfromdate" class="txtbox date_picker" TabIndex="1" />
                                <cc1:CalendarExtender ID="txtfrom_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                    TargetControlID="txtfromdate" CssClass="cal_Theme1">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtfromdate"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>
                            </td>
                            <th width="70px;">
                                To Date :
                            </th>
                            <td width="180px">
                                <asp:TextBox runat="server" ID="txttodate" class="txtbox date_picker" TabIndex="2" />
                                <cc1:CalendarExtender ID="txtto_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                    TargetControlID="txttodate" CssClass="cal_Theme1">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttodate"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr id="trcus" runat="server" visible="false">
                            <th width="70px;">
                                Customer
                            </th>
                            <td colspan="2">
                                <asp:TextBox runat="server" ID="txtcusname" class="txtbox bgcolrgreen" TabIndex="3"
                                    Width="180px" />
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
                        <%--<tr runat="server" id="trdestination" visible="false">
                            <th>
                                Destination :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtdestination" class="txtbox bgcolrgreen" Width="250px"
                                    TabIndex="4" />
                                <cc1:AutoCompleteExtender ServiceMethod="SearchDestination" MinimumPrefixLength="1"
                                    OnClientItemSelected="select_Destination" CompletionInterval="100" EnableCaching="false"
                                    CompletionSetCount="10" TargetControlID="txtdestination" ID="AutoCompleteExtender2"
                                    runat="server" FirstRowSelected="false" CompletionListCssClass="AutoComplete_completionListElement"
                                    CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdestination"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                    InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="HifDestination" runat="server" />
                            </td>
                        </tr>--%>
                      <%--  <tr id="trdrsmanifest" runat="server" visible="false">
                            <th width="70px;">
                                <asp:Label Text="" ID="lbldrsmanifest" runat="server" />
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtdrsno" CssClass="txtbox bgcolrred" onkeypress="return validateKeyPress(event,validNums)" />
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="4">
                               <asp:Button Text="Submit" runat="server" class="btn btn-info" ID="btnsubmit" ValidationGroup="Main"
                                    TabIndex="4" OnClick="btnsubmit_Click"  />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>



<%@ Page Title="Report" Language="C#" MasterPageFile="~/PavanCourier.master" AutoEventWireup="true"
    CodeFile="ReportOptionForm.aspx.cs" Inherits="ReportOptionForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        function SetTarget() {
            document.forms[0].target = "_blank";
        }

        function select_cus(sender, e) {
            var hd = $get("<%=HifCus.ClientID %>");
            hd.value = e.get_value();

        }
        function select_cus1(sender, e) {
            var hd = $get("<%=HifCus1.ClientID %>");
            hd.value = e.get_value();

        }
        function select_cou(sender, e) {
            var hd = $get("<%=HFCourier.ClientID %>");
            hd.value = e.get_value();

        }
        function select_Agent(sender, e) {
            var hd = $get("<%=HifAgent.ClientID %>");
            hd.value = e.get_value();

        }
        
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
                            <asp:Label ID="Lbltxt" runat="server" Text=""></asp:Label></h4>
                    </div>
                    <div style="float: right;">
                    </div>
                </div>
                <div class="widget-body">
                    <table class="commontable">
                        <tr id="trdate" runat="server" visible="false">
                            <th width="100px;">
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
                            <th width="100px;">
                                Customer
                            </th>
                            <td colspan="2">
                                <asp:TextBox runat="server" ID="txtcusname" class="txtbox bgcolrgreen" TabIndex="3" width="180px" />
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
                         <tr id="tr1" runat="server" visible="false">
                            <th width="100px;">
                                Customer
                            </th>
                            <td colspan="2">
                                <asp:TextBox runat="server" ID="TxtCust" class="txtbox bgcolrgreen" TabIndex="3" width="180px" />
                                <cc1:AutoCompleteExtender ServiceMethod="SearchCustmer" MinimumPrefixLength="1" OnClientItemSelected="select_cus1"
                                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="TxtCust"
                                    ID="AutoCompleteExtender4" runat="server" FirstRowSelected="false" CompletionListCssClass="AutoComplete_completionListElement"
                                    CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtcusname"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                    InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                    <asp:HiddenField ID="HifCus1" runat="server" />
                               
                            </td>
                        </tr>
                          <tr id="tragent" runat="server" visible="false">
                            <th width="100px;">
                                Agent / Customer
                            </th>
                            <td colspan="2">
                                <asp:TextBox runat="server" ID="TxtAgent" class="txtbox bgcolrgreen" TabIndex="3" width="180px" />
                                <cc1:AutoCompleteExtender ServiceMethod="SearchAgent" MinimumPrefixLength="1" OnClientItemSelected="select_Agent"
                                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="TxtAgent"
                                    ID="AutoCompleteExtender3" runat="server" FirstRowSelected="false" CompletionListCssClass="AutoComplete_completionListElement"
                                    CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtAgent"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                    InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="HifAgent" runat="server" />
                            </td>
                        </tr>
                        <tr id="trsummary" runat="server" visible="false">
                            <th>
                                Summary :
                            </th>
                            <td colspan="3">
                                <asp:CheckBox ID="chksummary" runat="server" />
                            </td>
                        </tr>
                        <tr id="trdrsmanifest" runat="server" visible="false">
                            <th width="70px;">
                                <asp:Label Text="" ID="lbldrsmanifest" runat="server" />
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtdrsno" CssClass="txtbox bgcolrred" onkeypress="return validateKeyPress(event,validNums)" />
                            </td>
                        </tr>

                        <tr id="trdeliveryboy" runat="server" visible="false">
                            <th width="100px;">
                                Delivery Boy
                            </th>
                            <td colspan="2">
                                <asp:TextBox runat="server" ID="TxtDeliveryBoy" class="txtbox bgcolrgreen" TabIndex="3" width="180px" />
                                <cc1:AutoCompleteExtender ServiceMethod="SearchCourier" MinimumPrefixLength="1" OnClientItemSelected="select_cou"
                                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="TxtDeliveryBoy"
                                    ID="AutoCompleteExtender2" runat="server" FirstRowSelected="false" CompletionListCssClass="AutoComplete_completionListElement"
                                    CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtDeliveryBoy"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                    InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="HFCourier" runat="server" />
                            </td>
                        </tr>

                        <tr>
                            <td colspan="4">
                                <asp:Button Text="Submit" runat="server" class="btn btn-info" ID="btnsubmit" ValidationGroup="Main"
                                    TabIndex="4" OnClick="btnsubmit_Click" OnClientClick="SetTarget();" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

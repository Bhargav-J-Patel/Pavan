<%@ Page Title="Credit Bill" Language="C#" MasterPageFile="~/PavanCourier.master" AutoEventWireup="true"
    CodeFile="TranCashCreditBill.aspx.cs" Inherits="TranCashCreditBill" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        function SetTarget() {
            document.forms[0].target = "_blank";
        }

        function select_boy(sender, e) {
            var hd = $get("<%=HifBoy.ClientID %>");
            hd.value = e.get_value();
        }
        function select_Destination(sender, e) {
            var hd = $get("<%=HifDestination.ClientID %>");
            hd.value = e.get_value();
        }
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
                            Credit Bill</h4>
                    </div>
                    <div style="float: right;">
                    </div>
                </div>
                <div class="widget-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table class="commontable">
                                <tr>
                                    <th width="100px;">
                                        From Date :
                                    </th>
                                    <td width="170px;">
                                        <asp:TextBox ID="TxtFromDt" runat="server" CssClass="txtbox date_picker" TabIndex="1"
                                            Width="120px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" CssClass="cal_Theme1"
                                            TargetControlID="TxtFromDt">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <th width="70px;">
                                        To Date :
                                    </th>
                                    <td width="150px;">
                                        <asp:TextBox ID="TxtToDt" runat="server" CssClass="txtbox date_picker" TabIndex="1"
                                            Width="120px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtfrom_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                            CssClass="cal_Theme1" TargetControlID="TxtToDt">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Customer :
                                    </th>
                                    <td colspan="3">
                                        <asp:TextBox runat="server" ID="txtboy" class="txtbox bgcolrgreen" TabIndex="3" Width="180px" />
                                        <cc1:AutoCompleteExtender ServiceMethod="SearchCus" MinimumPrefixLength="1" OnClientItemSelected="select_boy"
                                            CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtboy"
                                            ID="AutoCompleteExtender2" runat="server" FirstRowSelected="false" CompletionListCssClass="AutoComplete_completionListElement"
                                            CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                        </cc1:AutoCompleteExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtboy"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                            InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                        <asp:HiddenField ID="HifBoy" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Destination :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtdestination" class="txtbox bgcolrgreen" Width="250px"
                                            TabIndex="4" />
                                        <cc1:AutoCompleteExtender ServiceMethod="SearchDestination" MinimumPrefixLength="1"
                                            OnClientItemSelected="select_Destination" CompletionInterval="100" EnableCaching="false"
                                            CompletionSetCount="10" TargetControlID="txtdestination" ID="AutoCompleteExtender1"
                                            runat="server" FirstRowSelected="false" CompletionListCssClass="AutoComplete_completionListElement"
                                            CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                        </cc1:AutoCompleteExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdestination"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                            InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                        <asp:HiddenField ID="HifDestination" runat="server" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td colspan="2">
                                        
                                        <asp:Button ID="btnsubmit" Text="Submit" runat="server" class="btn btn-info" OnClick="btnsubmit_Click"
                                            ValidationGroup="Main" TabIndex="7" OnClientClick="SetTarget();" />
                                            
                                        
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

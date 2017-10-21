<%@ Page Title="" Language="C#" MasterPageFile="~/PavanCourier.master" AutoEventWireup="true"
    CodeFile="ManifestReport.aspx.cs" Inherits="ManifestReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

<script type="text/javascript">
    function select_Destination(sender, e) {
        var hd = $get("<%=HifDestination.ClientID %>");
        hd.value = e.get_value();
    }
    function SetTarget() {
        document.forms[0].target = "_blank";
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
                            Manifest Report</h4>
                    </div>
                    <div style="float: right;">
                    </div>
                </div>
                <div class="widget-body">
                    <table class="commontable">
                        <tr>
                            <th width="100px;">
                                From Date :
                            </th>
                            <td>
                                <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox date_picker" TabIndex="1"
                                    Width="120px"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtfrom_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                    CssClass="cal_Theme1" TargetControlID="txtfromdate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfromdate"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                    InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                            </td>
                            <th width="100px;">
                                To Date :
                            </th>
                            <td>
                                <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox date_picker" TabIndex="1"
                                    Width="120px"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtto_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                    CssClass="cal_Theme1" TargetControlID="txttodate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txttodate"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                    InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Vendor :
                            </th>
                            <td colspan="3">
                                <asp:TextBox runat="server" ID="txtvendor" class="txtbox bgcolrblue" TabIndex="2"
                                    Width="230px" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Destination :
                            </th>
                            <td colspan="3">
                                <asp:TextBox runat="server" ID="txtdestination" class="txtbox bgcolrgreen" Width="150px"
                                    TabIndex="2" />
                                <cc1:AutoCompleteExtender ServiceMethod="SearchDestination" MinimumPrefixLength="1"
                                    OnClientItemSelected="select_Destination" CompletionInterval="100" EnableCaching="false"
                                    CompletionSetCount="10" TargetControlID="txtdestination" ID="AutoCompleteExtender1"
                                    runat="server" FirstRowSelected="false" CompletionListCssClass="AutoComplete_completionListElement"
                                    CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdestination"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                    InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="HifDestination" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Summary :
                            </th>
                            <td colspan="3">
                                <asp:CheckBox id="chksummary"  runat="server" />
                                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button Text="Submit" runat="server" class="btn btn-info" ID="btnsubmit" OnClick="btnsubmit_Click"
                                    ValidationGroup="Main" TabIndex="4" OnClientClick="SetTarget();"/>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="Cash/Credit Report" Language="C#" MasterPageFile="~/PavanCourier.master" AutoEventWireup="true" CodeFile="CashCreditRpt.aspx.cs" Inherits="CashCreditRpt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                            Cash / Credit Report</h4>
                    </div>
                    <div style="float: right;">
                    </div>
                </div>
                <div class="widget-body">
                    <table class="commontable">
                        
                      
                        <tr>
                            <th>
                                Destination :&nbsp; 
                            </th>
                            <td colspan="3">
                                <asp:TextBox runat="server" ID="txtdestination" class="txtbox bgcolrgreen" Width="190px"
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



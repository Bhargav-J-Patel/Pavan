<%@ Page Title="Consignee Detail" Language="C#" MasterPageFile="~/PavanCourier.master"
    AutoEventWireup="true" CodeFile="ConsigneeDetail.aspx.cs" Inherits="ConsigneeDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            $('input,.select').on('keypress', function (eInner) {
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
                            Consignee Detail</h4>
                    </div>
                    <div style="float: right;">
                        <%--  <asp:Button ID="btnlist" Text="List" runat="server" class="btn btn-primary" Style="margin-top: 4px;
                            margin-right: 3px;" OnClick="btnlist_Click" TabIndex="8" />--%>
                    </div>
                </div>
                <div class="widget-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table class="commontable">
                                <tr>
                                    <th width="130px;">
                                        AWB No :
                                    </th>
                                    <td width="250px" colspan="2">
                                        <asp:TextBox runat="server" ID="txtawbno" class="txtbox bgcolrred" AutoPostBack="true"
                                            Style="text-align: right;" onkeypress="return validateKeyPress(event,validNums)"
                                            TabIndex="1" Width="180px" OnTextChanged="txtawbno_TextChanged" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtawbno"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                            ValidationGroup="Main"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Customer/Agent
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="TxtCustAgent" Enabled="false" class="txtbox bgcolrred"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th colspan="5" style="font-size: 14px">
                                        DRS Detail :
                                    </th>
                                </tr>
                                <tr>
                                    <th width="130px;">
                                        DRS No
                                    </th>
                                    <th width="160px;">
                                        Location
                                    </th>
                                    <th width="160px;">
                                        Date
                                    </th>
                                    <th width="160px;">
                                        Weight
                                    </th>
                                    <th width="160px;">
                                        PCS
                                    </th>
                                    <th width="120px;">
                                        Rate
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="HIFDRSID" runat="server" />
                                        <asp:HiddenField ID="HIFDrsCus" runat="server" />
                                        <asp:TextBox runat="server" ID="txtdrsno" class="txtbox bgcolrred" Enabled="false"
                                            Width="120px" onkeypress="return validateKeyPress(event,validNums)" TabIndex="1" />
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtlocation" class="txtbox bgcolrred" Enabled="false"
                                            onkeypress="return validateKeyPress(event,validNums)" TabIndex="1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdrsdate" runat="server" CssClass="txtbox date_picker" TabIndex="1"
                                            Enabled="false" Width="130px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtfrom_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                            CssClass="cal_Theme1" TargetControlID="txtdrsdate"></cc1:CalendarExtender>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtdrsweight" class="txtbox bgcolrred" AutoPostBack="true"
                                            Style="text-align: right" Width="130px" onkeypress="return validateKeyPress(event,validNums)"
                                            TabIndex="2" OnTextChanged="txtdrsweight_TextChanged" />
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtdrspcs" class="txtbox bgcolrred" Style="text-align: right"
                                            Width="130px" onkeypress="return validateKeyPress(event,validNums)" TabIndex="3" />
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtdrsrate" class="txtbox bgcolrred" Style="text-align: right"
                                            Width="100px" onkeypress="return validateKeyPress(event,validNums)" Enabled="false"
                                            TabIndex="1" />
                                    </td>
                                </tr>
                                <tr>
                                    <th colspan="5" style="font-size: 14px">
                                        Manifest Detail :
                                    </th>
                                </tr>
                                <tr>
                                    <th width="130px;">
                                        Manifest No
                                    </th>
                                    <th width="160px;">
                                        Destination
                                    </th>
                                    <th width="160px;">
                                        Date
                                    </th>
                                    <th width="160px;">
                                        Weight
                                    </th>
                                    <th width="160px;">
                                        PCS
                                    </th>
                                    <th width="120px;">
                                        Rate
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="HIFManifestID" runat="server" />
                                        <asp:HiddenField ID="HIFManifestCus" runat="server" />
                                        <asp:TextBox runat="server" ID="txtmanifestno" class="txtbox bgcolrred" Enabled="false"
                                            Width="120px" onkeypress="return validateKeyPress(event,validNums)" TabIndex="1" />
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtdestination" class="txtbox bgcolrred" Enabled="false"
                                            onkeypress="return validateKeyPress(event,validNums)" TabIndex="1" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtmanifestdt" runat="server" CssClass="txtbox date_picker" TabIndex="1"
                                            Enabled="false" Width="130px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" CssClass="cal_Theme1"
                                            TargetControlID="txtmanifestdt"></cc1:CalendarExtender>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtmanifestweight" class="txtbox bgcolrred" AutoPostBack="true"
                                            Style="text-align: right" Width="130px" onkeypress="return validateKeyPress(event,validNums)"
                                            TabIndex="4" OnTextChanged="txtmanifestweight_TextChanged" />
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtmanifestpcs" class="txtbox bgcolrred" Style="text-align: right"
                                            Width="130px" onkeypress="return validateKeyPress(event,validNums)" TabIndex="5" />
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtmanifestrate" class="txtbox bgcolrred" Style="text-align: right"
                                            Width="100px" onkeypress="return validateKeyPress(event,validNums)" Enabled="false"
                                            TabIndex="1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Button ID="btnsubmit" Text="Update" runat="server" class="btn btn-info" Width="70px"
                                            ValidationGroup="Main" TabIndex="10" OnClick="btnsubmit_Click" />
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

<%@ Page Title="" Language="C#" MasterPageFile="~/PavanCourier.master" AutoEventWireup="true"
    CodeFile="TranDRSRunsheetUpload.aspx.cs" Inherits="TranDRSRunsheetUpload" %>

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
                            Delivery Runsheet Image</h4>
                    </div>
                    <div style="float: right;">
                        <asp:Button ID="btnlist" Text="List" runat="server" class="btn btn-primary" Style="margin-top: 4px;
                            margin-right: 3px;" OnClick="btnlist_Click" TabIndex="6" UseSubmitBehavior="false" />
                    </div>
                </div>
                <div class="widget-body">
                    <table class="commontable">
                        <tr>
                            <th width="150px;">
                                Sr No :
                            </th>
                            <td width="250px">
                                <asp:TextBox runat="server" ID="txtsrno" class="txtbox bgcolrblue" Width="80px" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <th width="60px;">
                                Date :
                            </th>
                            <td width="150px;" colspan="3">
                                <asp:TextBox ID="txtdate" runat="server" CssClass="txtbox date_picker" TabIndex="1"
                                    Width="120px"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtfrom_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                    CssClass="cal_Theme1" TargetControlID="txtdate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdate"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                    InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th width="100px;">
                                Delivery Runshhet No :
                            </th>
                            <td width="200px">
                                <asp:TextBox runat="server" ID="TxtImgNo" class="txtbox bgcolrblue" TabIndex="2"
                                    Width="80px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtImgNo"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th width="100px;">
                                Select Image :
                            </th>
                            <td width="200px">
                                <asp:FileUpload ID="FileUpload1" runat="server"  TabIndex="3"/>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FileUpload1"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:DropDownList ID="ddldelete" runat="server" Visible="false" TabIndex="3">
                                    <asp:ListItem>No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button Text="Submit" runat="server" class="btn btn-info" ID="btnsubmit" OnClick="btnsubmit_Click"
                                    ValidationGroup="Main" TabIndex="4" />
                                <asp:Button Text="Reset" runat="server" class="btn resetbtn" ID="btnreset" TabIndex="5"
                                    OnClick="btnreset_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

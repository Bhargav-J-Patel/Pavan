﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PavanCourier.master" AutoEventWireup="true"
    CodeFile="MasterStatus.aspx.cs" Inherits="MasterStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                            Delivery Exception</h4>
                    </div>
                    <div style="float: right;">
                        <asp:Button ID="btnlist" Text="List" runat="server" class="btn btn-primary" Style="margin-top: 4px;
                            margin-right: 3px;" OnClick="btnlist_Click" TabIndex="7" UseSubmitBehavior="false" />
                    </div>
                </div>
                <div class="widget-body">
                    <table class="commontable">
                        <tr>
                            <th width="100px;">
                                Sr No :
                            </th>
                            <td width="200px">
                                <asp:TextBox runat="server" ID="txtsrno" class="txtbox bgcolrblue" Width="80px" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <th width="100px;">
                                Status Code :
                            </th>
                            <td width="200px">
                                <asp:TextBox runat="server" ID="txtstatuscode" class="txtbox bgcolrblue" TabIndex="1"
                                    Width="80px" />
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtstatuscode"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Status Detail :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtstatusdetail" class="txtbox bgcolrblue" TabIndex="2" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtstatusdetail"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                        <th>
                            Default (For Bill) :
                        </th>
                        <th>
                            <asp:CheckBox runat="server" id="ChkDefaultStatus" TabIndex="3" />
                        </th>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:DropDownList ID="ddldelete" runat="server" Visible="false">
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

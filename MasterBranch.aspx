<%@ Page Title="Branch Master" Language="C#" MasterPageFile="~/PavanCourier.master"
    AutoEventWireup="true" CodeFile="MasterBranch.aspx.cs" Inherits="MasterBranch" %>

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
                            Branch Master</h4>
                    </div>
                    <div style="float: right;">
                        <%--<asp:Button ID="btnlist" Text="List" runat="server" class="btn btn-primary" style="margin-top:4px;margin-right:3px;"/>--%>
                    </div>
                </div>
                <div class="widget-body">
                    <table class="commontable">
                        <tr>
                            <th width="100px;">
                                Company Name :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtcompname" class="txtbox bgcolrblue" Enabled="false"
                                    Width="230px" />
                            </td>
                        </tr>
                        <tr>
                            <th width="100px;">
                                Branch Code :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtbranchcode" class="txtbox bgcolrblue" Enabled="false"
                                    Width="80px" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Branch Name :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtbranchname" class="txtbox bgcolrblue" Enabled="false"
                                    Width="280px" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Address :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtaddress" class="bgcolrblue" TextMode="MultiLine"
                                    Height="80px" Width="185px" TabIndex="1" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                PIN Code No :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtpincodeno" class="txtbox bgcolrblue" TabIndex="2" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Contact No :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtcontactno" class="txtbox bgcolrblue" TabIndex="3" />
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcontactno"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                PAN No :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtpanno" class="txtbox bgcolrblue" TabIndex="4" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Service Tax No :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="TxtServiceTaxNo" class="txtbox bgcolrblue" TabIndex="5" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="Button1" Text="Submit" runat="server" class="btn btn-info" ValidationGroup="Main"
                                    TabIndex="6" OnClick="Button1_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

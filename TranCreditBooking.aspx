<%@ Page Title="Credit Booking" Language="C#" MasterPageFile="~/PavanCourier.master"
    AutoEventWireup="true" CodeFile="TranCreditBooking.aspx.cs" Inherits="TranCreditBooking" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function select_cus(sender, e) {
            var hd = $get("<%=HifCustomer.ClientID %>");
            hd.value = e.get_value();
        }
        function select_Destination(sender, e) {
            var hd = $get("<%=HifDestination.ClientID %>");
            hd.value = e.get_value();
        }
        function select_Product(sender, e) {
            var hd = $get("<%=HifProduct.ClientID %>");
            hd.value = e.get_value();
        }

       

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <script type="text/javascript">
                //        function tabE(obj, e) {
                //            var e = (typeof event != 'undefined') ? window.event : e; // IE : Moz 
                //            if (e.keyCode == 13) {
                //                var ele = document.forms[0].elements;
                //                for (var i = 0; i < ele.length; i++) {
                //                    var q = (i == ele.length - 1) ? 0 : i + 1; // if last element : if any other 
                //                    if (obj == ele[i]) {
                //                        ele[q].focus();
                //                        break
                //                    }
                //                }
                //                return false;
                //            }
                //        }


                //        $('input').keypress(function (e) {
                //            if (e.which == 13) {
                //                $("[tabindex='" + ($(this).attr("tabindex") + 1) + "']").focus();
                //                e.preventDefault();
                //            }
                //        });

                //                $(document).ready(function () {
                //                    EnterKeyTabNew();
                //                });

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




                //                function chnageWeight() {
                //                    __doPostBack("TxtWeight", "TextChanged");
                //                }

            </script>
            <script type="text/javascript">
                function SetContextKey() {
                    var ChkDestination = document.getElementById('<%=ChkDestination.ClientID%>');
                    var chk = -1;
                    if (ChkDestination.checked == true) {
                        chk = -1;
                    }
                    else {
                        chk = 0;
                    }
                    $find('<%=AutoCompleteExtender1.ClientID%>').set_contextKey(chk);
                }

                function ChkAWBNochange() {
                    var TxtAWBNo = document.getElementById('<%=TxtAWBNo.ClientID %>');
                    var ChkAWBNo = document.getElementById('<%=ChkAWBNo.ClientID %>');

                    if (ChkAWBNo.checked == true) {
                        TxtAWBNo.removeAttribute("onkeypress");
                    }
                    else {
                        TxtAWBNo.setAttribute("onkeypress", "return validateKeyPress(event,validNums)");
                    }
                }
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
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
                            Credit Booking</h4>
                    </div>
                    <div style="float: right;">
                        <asp:Button ID="btnlist" Text="List" runat="server" class="btn btn-primary" TabIndex="14"
                            Style="margin-top: 4px; margin-right: 3px;" OnClick="btnlist_Click" UseSubmitBehavior="false" />
                    </div>
                </div>
                <div class="widget-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table class="commontable" width="100%">
                                <tr>
                                    <th width="100px;">
                                        <%-- Booking No :--%>
                                        AWB No
                                    </th>
                                    <th style="width: 350px;">
                                        <asp:CheckBox ID="ChkAWBNo" runat="server" TabIndex="1" onchange="ChkAWBNochange();" />
                                        <asp:TextBox ID="TxtBookingNo" runat="server" CssClass="txtbox" Enabled="false" Style="display: none;"
                                            Width="90px"></asp:TextBox>
                                        <asp:TextBox runat="server" ID="TxtAWBNo" class="txtbox bgcolrred" onkeypress="return validateKeyPress(event,validNums)"
                                            TabIndex="2" Style="text-align: right" Width="150px" />
                                    </th>
                                    <th width="100px;">
                                        Last AWB No
                                    </th>
                                    <td>
                                        <asp:Label ID="LblLastEntry" runat="server"></asp:Label>
                                    </td>
                                    <%-- <th width="100px;">
                                      Last  AWB No :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="TxtAWBNo" class="txtbox bgcolrred" onkeypress="return validateKeyPress(event,validNums)"
                                            TabIndex="1" Style="text-align: right" Width="150px" />
                                    </td>--%>
                                </tr>
                                <tr>
                                    <th>
                                        Date :
                                    </th>
                                    <td>
                                        <asp:TextBox ID="TxtDate" runat="server" CssClass="txtbox date_picker" Width="120px"
                                            TabIndex="3"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtfrom_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                            CssClass="cal_Theme1" TargetControlID="TxtDate"></cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtDate"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                            InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                    </td>
                                    <th>
                                        Shipper :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="TxtCustomer" class="txtbox bgcolrgreen" TabIndex="4"
                                            Width="250px" />
                                        <cc1:AutoCompleteExtender ServiceMethod="SearchCus" MinimumPrefixLength="1" OnClientItemSelected="select_cus"
                                            CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="TxtCustomer"
                                            ID="AutoCompleteExtender2" runat="server" FirstRowSelected="false" CompletionListCssClass="AutoComplete_completionListElement"
                                            CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                        </cc1:AutoCompleteExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtCustomer"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                            InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                        <asp:HiddenField ID="HifCustomer" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Destination :
                                    </th>
                                    <td>
                                        <asp:CheckBox ID="ChkDestination" runat="server" TabIndex="5" />
                                        <asp:TextBox runat="server" ID="txtdestination" class="txtbox bgcolrgreen" Width="250px"
                                            AutoPostBack="true" TabIndex="6" OnTextChanged="txtdestination_TextChanged" onkeyup="SetContextKey()" />
                                        <cc1:AutoCompleteExtender ServiceMethod="SearchDestination" MinimumPrefixLength="1"
                                            OnClientItemSelected="select_Destination" CompletionInterval="100" EnableCaching="false"
                                            CompletionSetCount="10" TargetControlID="txtdestination" ID="AutoCompleteExtender1"
                                            runat="server" FirstRowSelected="false" CompletionListCssClass="AutoComplete_completionListElement"
                                            UseContextKey="true" CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                        </cc1:AutoCompleteExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdestination"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                            InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                        <asp:HiddenField ID="HifDestination" runat="server" />
                                    </td>
                                    <th>
                                        Shipped To :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="TxtShippedTo" class="txtbox bgcolrblue" TabIndex="7"
                                            Width="250px" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Contents :
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="DDlContent" runat="server" TabIndex="8" CssClass="select">
                                            <asp:ListItem Value="1">Document</asp:ListItem>
                                            <asp:ListItem Value="2">Non Document</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <th>
                                        No of Pkg :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="TxtNoOfPkg" class="txtbox bgcolrred" onkeypress="return validateKeyPress(event,validNums)"
                                            TabIndex="9" Style="text-align: right" Width="80px" Text="1" />
                                    </td>
                                </tr>
                                <tr runat="server" id="trprod" style="display: none">
                                    <th>
                                        Product :
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtproduct" runat="server" CssClass="txtbox bgcolrgreen" TabIndex="9"
                                            Width="200px"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ServiceMethod="SearchProduct" MinimumPrefixLength="1" OnClientItemSelected="select_Product"
                                            CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtproduct"
                                            ID="AutoCompleteExtender3" runat="server" FirstRowSelected="false" CompletionListCssClass="AutoComplete_completionListElement"
                                            CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                        </cc1:AutoCompleteExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtproduct"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                            InitialValue="" ValidationGroup="Child"></asp:RequiredFieldValidator>
                                        <asp:HiddenField ID="HifProduct" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Weight :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="TxtWeight" class="txtbox bgcolrred" AutoPostBack="true"
                                            onkeypress="return validateKeyPress(event,validNums)" TabIndex="10" Style="text-align: right"
                                            Width="110px" OnTextChanged="TxtWeight_TextChanged" />
                                    </td>
                                    <th>
                                        Amount :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="TxtAmt" class="txtbox bgcolrred" onkeypress="return validateKeyPress(event,validNums)"
                                            TabIndex="11" Style="text-align: right" Width="80px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddldelete" runat="server" Visible="false">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Button ID="btnsubmit" Text="Submit" runat="server" class="btn btn-info" OnClick="btnsubmit_Click"
                                            ValidationGroup="Main" TabIndex="12" />
                                        <asp:Button ID="btnreset" Text="Reset" runat="server" class="btn resetbtn" TabIndex="13"
                                            OnClick="btnreset_Click" />
                                    </td>
                                    <th>
                                        CSV File :
                                    </th>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:FileUpload ID="FileUpload1" runat="server" Width="300px" ValidationGroup="FileUpload" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUpload1"
                                                        ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                                        ValidationGroup="FileUpload" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Button ID="BtnUpload" Text="Upload" runat="server" class="btn btn-info" ValidationGroup="FileUpload"
                                                        Width="70px" OnClick="BtnUpload_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="TxtWeight" EventName="TextChanged" />
                            <asp:AsyncPostBackTrigger ControlID="txtdestination" EventName="TextChanged" />
                            <asp:PostBackTrigger ControlID="BtnUpload" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="DRS" Language="C#" MasterPageFile="~/PavanCourier.master" AutoEventWireup="true"
    CodeFile="TranDRS.aspx.cs" Inherits="TranDRS" %>

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



        function SetTarget() {
            document.forms[0].target = "_blank";
        }


        function Confirm_box() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to delete this Record ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

        function select_boy(sender, e) {
            var hd = $get("<%=HifBoy.ClientID %>");
            hd.value = e.get_value();
        }

        function select_route(sender, e) {
            var hd = $get("<%=HifRoute.ClientID %>");
            hd.value = e.get_value();
        }

        function select_loc(sender, e) {
            var hd = $get("<%=HifLoc.ClientID %>");
            hd.value = e.get_value();
        }


        function changePcs() {
            if (document.getElementById("<%=txtawbno.ClientID %>").value == '') {
                alert("Please enter AWBNo");
                document.getElementById("<%=txtawbno.ClientID %>").focus();
            }
            else if (document.getElementById("<%=txtweight.ClientID %>").value == '') {
                alert("Please Weight AWBNo");
                document.getElementById("<%=txtweight.ClientID %>").focus();
            }
            else if (document.getElementById("<%=txtpcs.ClientID %>").value == '') {
                alert("Please enter Pcs");
                document.getElementById("<%=txtpcs.ClientID %>").focus();
            }
            else {
                __doPostBack("txtpcs", "TextChanged");
                //                var txtBox = document.getElementById('<%= txtpcs.ClientID %>');
                //                var count = txtBox.value.length;
                //                if (count == 1) {
                //                    document.getElementById('<%= txtpcs.ClientID %>').focus();
                //                    return true;
                //                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updatepanel5" runat="server">
        <ContentTemplate>
            <div class="success" runat="server" id="divsucess" visible="false">
                <asp:Label ID="lblsucess" runat="server" Text=""></asp:Label>
            </div>
            <div class="warning" runat="server" id="DivWarning" visible="false">
                <asp:Label ID="LblWarning" runat="server" Text=""></asp:Label>
            </div>
            <div class="error" runat="server" id="diverror" visible="false">
                <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="row">
        <div class="col-xs-12 col-sm-11">
            <div class="widget-box">
                <div class="widget-header">
                    <div style="float: left">
                        <h4 class="widget-title">DRS</h4>
                    </div>
                    <div style="float: right;">
                        <asp:Button ID="btnlist" Text="List" runat="server" class="btn btn-primary" TabIndex="11"
                            Style="margin-top: 4px; margin-right: 3px;" OnClick="btnlist_Click" UseSubmitBehavior="false" />
                    </div>
                </div>
                <div class="widget-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table class="commontable">
                                <tr>
                                    <th width="100px;">DRS No :
                                    </th>
                                    <td width="150px;">
                                        <asp:TextBox runat="server" ID="txtdrsno" class="txtbox bgcolrgreen" Enabled="false"
                                            Style="text-align: right;" Width="80px" />
                                    </td>
                                    <th width="70px;">Date :
                                    </th>
                                    <td width="150px;">
                                        <asp:TextBox ID="txtdate" runat="server" CssClass="txtbox date_picker" TabIndex="1"
                                            Width="120px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtfrom_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                            CssClass="cal_Theme1" TargetControlID="txtdate"></cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdate"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                            InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Route :
                                    </th>
                                    <td colspan="3">
                                        <asp:TextBox runat="server" ID="txtroute" class="txtbox bgcolrgreen" TabIndex="2"
                                            Width="180px" />
                                        <cc1:AutoCompleteExtender ServiceMethod="SearchRoute" MinimumPrefixLength="1" OnClientItemSelected="select_route"
                                            CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtroute"
                                            ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false" CompletionListCssClass="AutoComplete_completionListElement"
                                            CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                        </cc1:AutoCompleteExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtroute"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                            InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                        <asp:HiddenField ID="HifRoute" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>Agent / Delivery Boy:
                                    </th>
                                    <td colspan="3">
                                        <asp:TextBox runat="server" ID="txtboy" class="txtbox bgcolrgreen" TabIndex="3" Width="180px" />
                                        <cc1:AutoCompleteExtender ServiceMethod="SearchCus" MinimumPrefixLength="2" OnClientItemSelected="select_boy"
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
                                    <th>Location :
                                    </th>
                                    <td colspan="3">
                                        <asp:TextBox runat="server" ID="txtlocation" class="txtbox bgcolrgreen" TabIndex="4"
                                            Width="180px" />
                                        <cc1:AutoCompleteExtender ServiceMethod="SearchLoc" MinimumPrefixLength="1" OnClientItemSelected="select_loc"
                                            CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtlocation"
                                            ID="AutoCompleteExtender3" runat="server" FirstRowSelected="false" CompletionListCssClass="AutoComplete_completionListElement"
                                            CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                        </cc1:AutoCompleteExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtlocation"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                            InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                        <asp:HiddenField ID="HifLoc" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>Origin
                                    </th>
                                    <td colspan="3">
                                        <asp:TextBox runat="server" ID="txtorigin" class="txtbox bgcolrgreen" Text="India"
                                            Enabled="false" Width="80px" />
                                    </td>
                                </tr>
                                <tr>
                                    <th width="100px;">Book Date :
                                    </th>
                                    <td>
                                        <asp:TextBox ID="txtbookdate" runat="server" CssClass="txtbox date_picker" TabIndex="5"
                                            Width="120px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtbookdate"
                                            CssClass="cal_Theme1"></cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtbookdate"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                            InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>CSV File :
                                    </td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:FileUpload ID="FileUpload1" runat="server" Width="300px" ValidationGroup="FileUpload" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="FileUpload1"
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
                                <tr>
                                    <td colspan="5">
                                        <table border="0" cellpadding="0" cellspacing="0" style="padding: none; margin: none;">
                                            <tr>
                                                <th>AWB No
                                                
                                                <th runat="server" id="thweight" visible="false">Weight
                                                </th>
                                                    <th runat="server" id="thpcs" visible="false">PCS
                                                    </th>
                                                    <th runat="server" id="threcv" visible="false">Receiver
                                                    </th>
                                                </th>
                                                <th rowspan="2" style="padding-top: 10px; padding-left: 80px;">
                                                    <button type="button" id="BtnMultiAWB" class="btn btn-info" style="width: 120px;"
                                                        data-toggle="modal" data-target="#ModelAWB">
                                                        Scan AWB</button>
                                                    <%--<asp:Button ID="BtnMultiAWB" Text="Scan AWB" runat="server" class="btn btn-info" 
                                                        Width="70px" />--%>

                                                </th>

                                            </tr>
                                            <tr>
                                                <td style="width: 180px;">
                                                    <asp:TextBox runat="server" class="txtbox bgcolrred" ID="txtawbno" TabIndex="6" AutoPostBack="true"
                                                        onkeypress="return validateKeyPress(event,validNums)" Style="text-align: right"
                                                        Width="160px" OnTextChanged="txtawbno_TextChanged" onfocus="this.select();" />
                                                </td>


                                                <td style="width: 100px;" runat="server" id="tdweight" visible="false">
                                                    <asp:TextBox runat="server" ID="txtweight" class="txtbox bgcolrred" TabIndex="8"
                                                        onkeypress="return validateKeyPress(event,validNums)" Style="text-align: right;" Width="90px" onfocus="this.select();" />
                                                </td>
                                                <td style="width: 110px;" runat="server" id="tdpcs" visible="false">
                                                    <asp:TextBox runat="server" ID="txtpcs" class="txtbox bgcolrred" TabIndex="9" onkeypress="return validateKeyPress(event,validNums)"
                                                        Style="text-align: right;" Width="100px" onlostfocus="changePcs();"
                                                        onfocus="this.select();" OnTextChanged="txtpcs_TextChanged"
                                                        ClientIDMode="Static" />
                                                </td>
                                                <td runat="server" id="tdrecv" visible="false">
                                                    <asp:TextBox runat="server" ID="TxtRecvrNm" class="txtbox bgcolrblue" TabIndex="7"
                                                        Width="210px" OnTextChanged="TxtRecvrNm_TextChanged" />
                                                    <cc1:AutoCompleteExtender ServiceMethod="Searchrecv" MinimumPrefixLength="1" CompletionInterval="100"
                                                        EnableCaching="false" CompletionSetCount="10" TargetControlID="TxtRecvrNm" ID="AutoCompleteExtender4"
                                                        runat="server" FirstRowSelected="false" CompletionListCssClass="AutoComplete_completionListElement"
                                                        CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                                    </cc1:AutoCompleteExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtRecvrNm"
                                                        ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                                        InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                                </td>
                                                <td id="tdbtnad" runat="server" visible="false">
                                                    <asp:ImageButton ID="ImgBtnAdd" ImageUrl="assets/img/add.png" runat="server" TabIndex="8"
                                                        ValidationGroup="Child" OnClick="ImgBtnAdd_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="GvAWBList" runat="server" AutoGenerateColumns="false" class="table table-striped table-bordered table-hover">
                                                    <Columns>
                                                        <asp:BoundField DataField="NID" HeaderText="" ItemStyle-Width="1px" ItemStyle-ForeColor="Transparent"
                                                            ItemStyle-Font-Size="1px" />
                                                        <asp:BoundField HeaderText="AWB No" DataField="nAWBNo" />
                                                        <asp:BoundField DataField="cParentId" Visible="false" />
                                                        <asp:BoundField HeaderText="Weight" DataField="cweight" />
                                                        <asp:BoundField HeaderText="PCS" DataField="cpcs" />
                                                        <asp:BoundField HeaderText="Receiver" DataField="cReceiverName" />
                                                        <%--<asp:BoundField HeaderText="Rate" DataField="nRate" />--%>
                                                        <asp:TemplateField HeaderText="Edit" ItemStyle-Width="5%">
                                                            <ItemTemplate>
                                                                <a href="TranDRS.aspx?id=<%# DataBinder.Eval(Container.DataItem,"cParentId")%>&cid=<%# DataBinder.Eval(Container.DataItem , "NID") %>">
                                                                    <asp:Image ID="ImgEdit" ImageUrl="assets/img/edit.png" runat="server" title="Edit" />
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-Width="5%">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgDelete1" ImageUrl="assets/img/delete.png" runat="server"
                                                                    title="Delete" OnClientClick="Confirm_box()" OnClick="ImgDelete1_Click" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:HiddenField ID="HIDPFID" runat="server" Value="0" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="txtawbno" EventName="TextChanged" />
                                                <asp:AsyncPostBackTrigger ControlID="txtpcs" EventName="TextChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align: right">
                                        <%--Total Rate--%>
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Label runat="server" ID="LblTotalRate" Style="display: none"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:DropDownList ID="ddldelete" runat="server" Visible="false" TabIndex="9">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Button ID="btnsubmit" Text="Submit" runat="server" class="btn btn-info" OnClick="btnsubmit_Click"
                                            ValidationGroup="Main" TabIndex="10" />
                                        <asp:Button ID="btnprint" Text="Print" runat="server" class="btn btn-sm btn-purple resetbtn"
                                            TabIndex="11" OnClick="btnprint_Click" OnClientClick="SetTarget();" />
                                        <asp:Button ID="btnreset" Text="Reset" runat="server" class="btn resetbtn" TabIndex="12"
                                            OnClick="btnreset_Click" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="txtawbno" EventName="TextChanged" />
                            <asp:PostBackTrigger ControlID="BtnUpload" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="ModelAWB" role="dialog">
        <div class="modal-dialog modal-sm vertical-align-center" style="width: 70%;">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Scan AWB No</h4>
                </div>
                <div class="modal-body" style="height: 420px;">
                    <table>
                        <tr>
                            <td>AWB No
                            </td>
                            <td style="padding-left: 40px;">
                                <asp:TextBox runat="server" class="txtbox bgcolrred" ID="TxtAWBNoPopup"
                                    onkeypress="return validateKeyPress(event,validNums)" Style="text-align: right"
                                    Width="160px" onfocus="this.select();" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" data-dismiss="modal" class="btn btn-default">Submite & Close</button>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

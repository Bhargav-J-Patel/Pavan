<%@ Page Title="Manifest" Language="C#" MasterPageFile="~/PavanCourier.master" AutoEventWireup="true"
    CodeFile="TranManifest.aspx.cs" Inherits="TranManifest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
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


        function select_Destination(sender, e) {
            var hd = $get("<%=HifDestination.ClientID %>");
            hd.value = e.get_value();
        }
        function select_Product(sender, e) {
            var hd = $get("<%=HifProduct.ClientID %>");
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
            else if (document.getElementById("<%=txtproduct.ClientID %>").value == '' || document.getElementById("<%=HifProduct.ClientID %>").value == '') {
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
                            Manifest</h4>
                    </div>
                    <div style="float: right;">
                        <asp:Button ID="btnlist" Text="List" runat="server" class="btn btn-primary" TabIndex="9"
                            Style="margin-top: 4px; margin-right: 3px;" OnClick="btnlist_Click" UseSubmitBehavior="false" />
                    </div>
                </div>
                <div class="widget-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table class="commontable">
                                <tr>
                                    <th width="100px;">
                                        Manifest No :
                                    </th>
                                    <td width="150px;">
                                        <asp:TextBox runat="server" ID="txtmanifest" class="txtbox bgcolrgreen" Enabled="false"
                                            Style="text-align: right;" Width="80px" />
                                    </td>
                                    <th width="60px;">
                                        Date :
                                    </th>
                                    <td width="150px;" colspan="3">
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
                                            InitialValue="" ValidationGroup="FileUpload"></asp:RequiredFieldValidator>
                                        <asp:HiddenField ID="HifDestination" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <th width="60px;">
                                        Vendor :
                                    </th>
                                    <td width="150px;" colspan="2">
                                        <asp:TextBox ID="txtvendor" runat="server" CssClass="txtbox bgcolrblue" Width="260px"
                                            Enabled="false"></asp:TextBox>
                                    </td>
                                    <th>
                                        CSV File :&nbsp;&nbsp;
                                    </th>
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
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <th width="200px">
                                                    AWB No :
                                                </th>
                                                <%--<th width="300px">
                                                    Product :
                                                </th>--%>
                                                <th width="150px">
                                                    Weight :
                                                </th>
                                                <th width="200px" colspan="2">
                                                    Pcs :
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtawbno" runat="server" CssClass="txtbox bgcolrred" TabIndex="4"
                                                        AutoPostBack="true" onkeypress="return validateKeyPress(event,validNums)" Style="text-align: right"
                                                        Width="160px" OnTextChanged="txtawbno_TextChanged"></asp:TextBox>
                                                </td>
                                                <td runat="server" id="tdproduct" style="display: none;">
                                                    <asp:TextBox ID="txtproduct" runat="server" CssClass="txtbox bgcolrgreen" TabIndex="3"
                                                        Width="250px"></asp:TextBox>
                                                    <cc1:AutoCompleteExtender ServiceMethod="SearchProduct" MinimumPrefixLength="1" OnClientItemSelected="select_Product"
                                                        CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtproduct"
                                                        ID="AutoCompleteExtender2" runat="server" FirstRowSelected="false" CompletionListCssClass="AutoComplete_completionListElement"
                                                        CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                                    </cc1:AutoCompleteExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtproduct"
                                                        ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='' alt='View' border='0'/&gt;"
                                                        InitialValue="" ValidationGroup="Child"></asp:RequiredFieldValidator>
                                                    <asp:HiddenField ID="HifProduct" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtweight" runat="server" CssClass="txtbox bgcolrred" TabIndex="5"
                                                        Text="100" onkeypress="return validateKeyPress(event,validNums)" Style="text-align: right"
                                                        Width="100px"></asp:TextBox>
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="txtpcs" runat="server" CssClass="txtbox bgcolrred" TabIndex="6"
                                                        Text="1" onkeypress="return validateKeyPress(event,validNums)" Style="text-align: right"
                                                        Width="80px" onlostfocus="changePcs();" onfocus="this.select();" OnTextChanged="txtpcs_TextChanged"
                                                        AutoPostBack="true" ClientIDMode="Static"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="GvManifestList" runat="server" AutoGenerateColumns="false" class="table table-striped table-bordered table-hover">
                                                    <Columns>
                                                        <asp:BoundField DataField="NID" HeaderText="" ItemStyle-Width="1px" ItemStyle-ForeColor="Transparent"
                                                            ItemStyle-Font-Size="1px" />
                                                        <asp:BoundField DataField="cParentId" Visible="false" />
                                                        <asp:BoundField HeaderText="AWB No" DataField="nAWBNo" />
                                                        <asp:BoundField HeaderText="Weight" DataField="nWeight" />
                                                        <%--<asp:BoundField HeaderText="Product" DataField="product" />--%>
                                                        <asp:BoundField HeaderText="Pcs" DataField="nPcs" />
                                                        <asp:BoundField HeaderText="Customer" DataField="cusname" />
                                                        <%--<asp:BoundField HeaderText="Rate" DataField="nrate" />--%>
                                                        <asp:TemplateField HeaderText="Edit" ItemStyle-Width="5%">
                                                            <ItemTemplate>
                                                                <a href="TranManifest.aspx?id=<%# DataBinder.Eval(Container.DataItem,"cParentId")%>&cid=<%# DataBinder.Eval(Container.DataItem , "NID") %>">
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
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddldelete" runat="server" Visible="false" TabIndex="6">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Button ID="btnsubmit" Text="Submit" runat="server" class="btn btn-info" OnClick="btnsubmit_Click"
                                            ValidationGroup="Main" TabIndex="7" />
                                        <asp:Button ID="btnprint" Text="Print" runat="server" class="btn btn-sm btn-purple resetbtn"
                                            TabIndex="8" OnClick="btnprint_Click" UseSubmitBehavior="false" />
                                        <asp:Button ID="btnreset" Text="Reset" runat="server" class="btn resetbtn" TabIndex="9"
                                            OnClick="btnreset_Click" UseSubmitBehavior="false" />
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
</asp:Content>

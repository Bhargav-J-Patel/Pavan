<%@ Page Title="Contract Master" Language="C#" MasterPageFile="~/PavanCourier.master"
    AutoEventWireup="true" CodeFile="MasterContract.aspx.cs" Inherits="MasterContract" %>

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


        function select_zone(sender, e) {
            var hd = $get("<%=HifZone.ClientID %>");
            hd.value = e.get_value();
        }

        function select_product(sender, e) {
            var hd = $get("<%=HifProduct.ClientID %>");
            hd.value = e.get_value();
        }

    </script>
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
                            Contract Master</h4>
                    </div>
                    <div style="float: right;">
                        <asp:Button ID="btnlist" Text="List" runat="server" class="btn btn-primary" TabIndex="12"
                            Style="margin-top: 4px; margin-right: 3px; top: 0px; left: 0px;" UseSubmitBehavior="false"
                            OnClick="btnlist_Click" />
                    </div>
                </div>
                <div class="widget-body">
                    <table class="commontable">
                        <tr>
                            <th width="100px;">
                               <%-- Contract Code :--%>
                                Contract Name :
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtcontractcode" class="txtbox bgcolrblue" TabIndex="1" style="display:none"
                                    Width="80px" />
                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtcontractcode"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>--%>

                                     <asp:TextBox runat="server" ID="txtcontractname" class="txtbox bgcolrblue" TabIndex="2" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcontractname"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>

                            </td>
                            <%--<th width="100px;">
                                Contract Name :
                            </th>
                            <td width="200px;">
                                <asp:TextBox runat="server" ID="txtcontractname" class="txtbox bgcolrblue" TabIndex="2" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcontractname"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Main"></asp:RequiredFieldValidator>
                            </td>--%>
                            <th width="100px;">
                                Type :
                            </th>
                            <td width="200px;">
                                <asp:DropDownList ID="DDLCType" runat="server" TabIndex="3" CssClass="select">
                                    <asp:ListItem Value="0">Credit</asp:ListItem>
                                    <asp:ListItem Value="1">Cash</asp:ListItem>
                                    <asp:ListItem Value="2">Vendor</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Product :
                            </th>
                            <td width="200px;">
                                <asp:TextBox runat="server" ID="txtproduct" class="txtbox bgcolrgreen" TabIndex="4" />
                                <cc1:AutoCompleteExtender ServiceMethod="SearchProduct" MinimumPrefixLength="1" OnClientItemSelected="select_product"
                                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtproduct"
                                    CompletionListCssClass="AutoComplete_completionListElement" CompletionListItemCssClass="AutoComplete_listItem"
                                    CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem" ID="AutoCompleteExtender1"
                                    runat="server" FirstRowSelected="false">
                                </cc1:AutoCompleteExtender>
                                <asp:HiddenField ID="HifProduct" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtproduct"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Child"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                    <table class="commontable">
                        <tr>
                            <th>
                                Zone
                            </th>
                            <th>
                                From weight
                            </th>
                            <th>
                                To weight
                            </th>
                            <th>
                                Rate
                            </th>
                            <th>
                                Type
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtzone" runat="server" class="txtbox bgcolrgreen" TabIndex="5"></asp:TextBox>
                                <cc1:AutoCompleteExtender ServiceMethod="SearchZone" MinimumPrefixLength="1" OnClientItemSelected="select_zone"
                                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtzone"
                                    ID="AutoCompleteExtender2" runat="server" FirstRowSelected="true" CompletionListCssClass="AutoComplete_completionListElement"
                                    CompletionListItemCssClass="AutoComplete_listItem" CompletionListHighlightedItemCssClass="AutoComplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtzone"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Child"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="HifZone" runat="server" />
                            </td>
                            <td width="130px">
                                <asp:TextBox ID="txtfromweight" runat="server" CssClass="txtbox bgcolrred" TabIndex="6"
                                    Width="100px" onkeypress="return validateKeyPress(event,validNums)" Style="text-align: right"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtfromweight"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Child"></asp:RequiredFieldValidator>
                            </td>
                            <td width="130px">
                                <asp:TextBox ID="txttoweight" runat="server" CssClass="txtbox bgcolrred" TabIndex="7"
                                    Width="100px" onkeypress="return validateKeyPress(event,validNums)" Style="text-align: right"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txttoweight"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Child"></asp:RequiredFieldValidator>
                            </td>
                            <td width="130px">
                                <asp:TextBox ID="txtrate" runat="server" CssClass="txtbox bgcolrred" TabIndex="8"
                                    Width="100px" onkeypress="return validateKeyPress(event,validNums)" Style="text-align: right"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtrate"
                                    ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                    ValidationGroup="Child"></asp:RequiredFieldValidator>
                            </td>
                            <td width="120px">
                                <asp:DropDownList runat="server" ID="DDLType" Width="90px" TabIndex="9" CssClass="select">
                                    <asp:ListItem Value="1">Regular</asp:ListItem>
                                    <asp:ListItem Value="2">Addtional</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImgBtnAdd" ImageUrl="assets/img/add.png" runat="server" TabIndex="10"
                                    ValidationGroup="Child" OnClick="ImgBtnAdd_Click" CssClass="buttoncss" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <asp:GridView ID="GvRateList" runat="server" AutoGenerateColumns="false" class="table table-striped table-bordered table-hover">
                                    <Columns>
                                        <asp:BoundField DataField="NID" HeaderText="" ItemStyle-Width="1px" ItemStyle-ForeColor="Transparent"
                                            ItemStyle-Font-Size="1px" />
                                        <asp:BoundField DataField="NParentID" Visible="false" />
                                        <asp:BoundField HeaderText="From Weight" DataField="nFromWeight" />
                                        <asp:BoundField HeaderText="To Weight" DataField="nToWeight" />
                                        <asp:BoundField HeaderText="Rate" DataField="nRate" />
                                        <asp:BoundField HeaderText="Type" DataField="ratecharge" />
                                        <asp:BoundField HeaderText="Zone Name" DataField="cZoneName" />
                                        <asp:TemplateField HeaderText="Edit" ItemStyle-Width="5%">
                                            <ItemTemplate>
                                                <a href="MasterContract.aspx?id=<%# DataBinder.Eval(Container.DataItem,"NParentID")%>&cid=<%# DataBinder.Eval(Container.DataItem , "NID") %>">
                                                    <asp:Image ID="ImgEdit" ImageUrl="assets/img/edit.png" runat="server" title="Edit" />
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgDelete1" ImageUrl="assets/img/delete.png" runat="server"
                                                    title="Delete" OnClientClick="Confirm_box()" OnClick="ImgDelete1_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:DropDownList ID="ddldelete" runat="server" Visible="false">
                                    <asp:ListItem>No</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button ID="btnsubmit" Text="Submit" runat="server" class="btn btn-info" TabIndex="11"
                                    ValidationGroup="Main" OnClick="btnsubmit_Click" />
                                <asp:Button ID="btnreset" Text="Reset" runat="server" class="btn resetbtn" TabIndex="12"
                                    OnClick="btnreset_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

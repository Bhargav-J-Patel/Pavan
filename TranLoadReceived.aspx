<%@ Page Title="" Language="C#" MasterPageFile="~/PavanCourier.master" AutoEventWireup="true"
    CodeFile="TranLoadReceived.aspx.cs" Inherits="TranLoadReceived" %>

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
                            Load Received</h4>
                    </div>
                    <div style="float: right;">
                     <asp:Button ID="btnlist" Text="List" runat="server" class="btn btn-primary" Style="margin-top: 4px;
                            margin-right: 3px;" OnClick="btnlist_Click" TabIndex="6" UseSubmitBehavior="false" />
                    </div>
                </div>
                <div class="widget-body">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <table class="commontable">
                                <tr>
                                    <th width="100px;">
                                        Date :
                                    </th>
                                    <td width="190px;">
                                        <asp:TextBox ID="txtdate" runat="server" CssClass="txtbox date_picker" TabIndex="1"
                                            Width="120px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtdate_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                            CssClass="cal_Theme1" TargetControlID="txtdate">
                                        </cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdate"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                            InitialValue="" ValidationGroup="Main"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th width="100px;">
                                        AWB No :
                                    </th>
                                    <td width="200px">
                                        <asp:TextBox runat="server" ID="txtawbno" class="txtbox bgcolrred" Width="150px"
                                            AutoPostBack="true" OnTextChanged="txtawbno_TextChanged" TabIndex="2" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="GVLoadRecvd" runat="server" AutoGenerateColumns="false" class="table table-striped table-bordered table-hover">
                                                    <Columns>
                                                        <asp:BoundField DataField="NID" HeaderText="" ItemStyle-Width="1px" ItemStyle-ForeColor="Transparent"
                                                            ItemStyle-Font-Size="1px" />
                                                        <asp:BoundField DataField="cParentId" Visible="false" />
                                                        <asp:BoundField HeaderText="Sr No" DataField="srno" />
                                                        <asp:BoundField HeaderText="Weight" DataField="nWeight" />
                                                        <asp:BoundField HeaderText="Product" DataField="product" />
                                                        <asp:BoundField HeaderText="Packet" DataField="nPcs" />
                                                        <asp:BoundField HeaderText="AWB No" DataField="nAWBNo" />
                                                        <%--<asp:TemplateField HeaderText="Edit" ItemStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <a href="TranLoadReceived.aspx?id=<%# DataBinder.Eval(Container.DataItem,"cParentId")%>&cid=<%# DataBinder.Eval(Container.DataItem , "NID") %>">
                                                            <asp:Image ID="ImgEdit" ImageUrl="assets/img/edit.png" runat="server" title="Edit" />
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
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
                                            ValidationGroup="Main" TabIndex="20" />
                                        <asp:Button ID="btnreset" Text="Reset" runat="server" class="btn resetbtn" TabIndex="21"
                                            OnClick="btnreset_Click" UseSubmitBehavior="false" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="txtawbno" EventName="TextChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

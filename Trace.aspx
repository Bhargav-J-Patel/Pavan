<%@ Page Title="Trace" Language="C#" MasterPageFile="~/PavanCourier.master" AutoEventWireup="true"
    CodeFile="Trace.aspx.cs" Inherits="Trace" %>

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
                            Trace</h4>
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
                                    <td width="250px">
                                        <asp:TextBox runat="server" ID="txtawbno" class="txtbox bgcolrred" AutoPostBack="true"
                                            onkeypress="return validateKeyPress(event,validNums)" TabIndex="1" Width="180px"
                                            OnTextChanged="txtawbno_TextChanged" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtawbno"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='DELETE' alt='View' border='0'/&gt;"
                                            ValidationGroup="Main"></asp:RequiredFieldValidator>
                                    </td>
                                    <th width="120px;">
                                        Origin :
                                    </th>
                                    <td width="200px">
                                        <asp:TextBox runat="server" ID="txtorigin" class="txtbox bgcolrblue" Enabled="false" />
                                    </td>
                                    <th width="120px;">
                                        Location :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtlocation" class="txtbox bgcolrblue" Enabled="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Book Date & Time :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtbookdatetime" class="txtbox bgcolrblue" Enabled="false" />
                                    </td>
                                    <th>
                                        Customer Name :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtcustomer" class="txtbox bgcolrblue" Enabled="false" />
                                    </td>
                                       <th>
                                        Phone No :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtphoneno" class="txtbox bgcolrblue" Enabled="false" />
                                    </td>
                                    <%--<th>
                                        Product :
                                    </th>--%>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtproduct" class="txtbox bgcolrblue" Enabled="false" Visible="false"/>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        DRS No :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtdrsno" class="txtbox bgcolrblue" Enabled="false" />
                                    </td>
                                    <th>Route :</th>
                                    <td>
                                        <asp:TextBox runat="server" ID="TxtRoute" class="txtbox bgcolrblue" Enabled="false" />
                                    </td>
                                    <th>
                                        Manifest No :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtmanifestno" class="txtbox bgcolrblue" Enabled="false" />
                                    </td>
                                    
                                 
                                </tr>
                                <tr>
                                    <th>
                                        Status :
                                    </th>
                                    <td colspan="2">
                                        <asp:TextBox runat="server" ID="txtstatus" class="txtbox bgcolrgreen" TabIndex="2"
                                            Width="250px" Enabled="false" />
                                    </td>

                                </tr>
                                <tr>
                                    <th>
                                        Del Date :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtdeldate" class="txtbox date_picker" TabIndex="3"
                                            Enabled="false" />
                                        <cc1:CalendarExtender ID="txtfrom_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                            CssClass="cal_Theme1" TargetControlID="txtdeldate">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <th>
                                        Vendor 1 :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtvendor1" class="txtbox bgcolrblue" TabIndex="2" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Rec Name :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtrecname" class="txtbox bgcolrblue" TabIndex="3"
                                            Enabled="false" />
                                    </td>
                                    <th>
                                        Vendor 2 :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtvendor2" class="txtbox bgcolrblue" TabIndex="3" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Remark :
                                    </th>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtremark" class="txtbox bgcolrblue" TabIndex="5"
                                            Enabled="false" Width="200px" Height="60px" TextMode="MultiLine" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:GridView ID="GvPODList" runat="server" AutoGenerateColumns="false" class="table table-striped table-bordered table-hover">
                                            <Columns>
                                                <asp:BoundField DataField="NID" HeaderText="" ItemStyle-Width="1px" ItemStyle-ForeColor="Transparent"
                                                    ItemStyle-Font-Size="1px" />
                                                <asp:BoundField HeaderText="Status" DataField="cStatus" />
                                                <asp:BoundField HeaderText="Delivery Date" DataField="dDelDate" />
                                                <asp:BoundField HeaderText="Recv Name" DataField="cRecName" />
                                                <asp:BoundField HeaderText="Remark" DataField="cRemark" />
                                                <asp:BoundField HeaderText="Vendor 1" DataField="cvendor1" />
                                                <asp:BoundField HeaderText="Vendor 2" DataField="cvendor2" />
                                                <asp:TemplateField HeaderText="..." ItemStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <a href='<%#Eval("NID","TranPOD.aspx?id={0}&E=1") %>'>
                                                            <asp:Image ID="ImgEdit" ImageUrl="assets/img/edit.png" runat="server" title="Edit" />
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="..." ItemStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <a href='<%#Eval("NID","TranPOD.aspx?id={0}&D=1") %>'>
                                                            <asp:Image ID="ImgEdit" ImageUrl="assets/img/delete.png" runat="server" title="Edit" />
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:GridView ID="GvDRSList" runat="server" AutoGenerateColumns="false" class="table table-striped table-bordered table-hover">
                                            <Columns>
                                                <asp:BoundField DataField="NID" HeaderText="" ItemStyle-Width="1px" ItemStyle-ForeColor="Transparent"
                                                    ItemStyle-Font-Size="1px" />
                                                <asp:BoundField HeaderText="DRS No" DataField="nDRSNo" />
                                                <asp:BoundField HeaderText="Book Date" DataField="bookdt" />
                                                <asp:BoundField HeaderText="Origin" DataField="cOrigin" />
                                                <%--<asp:BoundField HeaderText="Customer Name" DataField="cCustomerName" />--%>
                                                <asp:BoundField HeaderText="Location Name" DataField="cLocationName" />
                                                <asp:TemplateField HeaderText="..." ItemStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <a href='<%#Eval("NID","TranDRS.aspx?id={0}&E=1") %>'>
                                                            <asp:Image ID="ImgEdit" ImageUrl="assets/img/edit.png" runat="server" title="Edit" />
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="..." ItemStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <a href='<%#Eval("NID","TranDRS.aspx?id={0}&D=1") %>'>
                                                            <asp:Image ID="ImgEdit" ImageUrl="assets/img/delete.png" runat="server" title="Edit" />
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:GridView ID="GvManifest" runat="server" AutoGenerateColumns="false" class="table table-striped table-bordered table-hover">
                                            <Columns>
                                                <asp:BoundField DataField="NID" HeaderText="" ItemStyle-Width="1px" ItemStyle-ForeColor="Transparent"
                                                    ItemStyle-Font-Size="1px" />
                                                <asp:BoundField HeaderText="Manifest No" DataField="nManifestNo" />
                                                <asp:BoundField HeaderText="Weight" DataField="nWeight" />
                                                <%--<asp:BoundField HeaderText="Product Name" DataField="cProductName" />--%>
                                                <asp:BoundField HeaderText="Destination" DataField="cDomesticName" />
                                                <asp:BoundField HeaderText="Pcs" DataField="nPcs" />
                                                <asp:TemplateField HeaderText="..." ItemStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <a href='<%#Eval("NID","TranManifest.aspx?id={0}&E=1") %>'>
                                                            <asp:Image ID="ImgEdit" ImageUrl="assets/img/edit.png" runat="server" title="Edit" />
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="..." ItemStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <a href='<%#Eval("NID","TranManifest.aspx?id={0}&D=1") %>'>
                                                            <asp:Image ID="ImgEdit" ImageUrl="assets/img/delete.png" runat="server" title="Edit" />
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddldelete" runat="server" Visible="false" TabIndex="3">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Button Text="Submit" runat="server" class="btn btn-info" ID="btnsubmit" OnClick="btnsubmit_Click"
                                            ValidationGroup="Main" TabIndex="6" />
                                        <asp:Button Text="Reset" runat="server" class="btn resetbtn" ID="btnreset" TabIndex="7"
                                            OnClick="btnreset_Click" />
                                    </td>
                                </tr>--%>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

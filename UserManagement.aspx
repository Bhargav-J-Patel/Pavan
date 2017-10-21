<%@ Page Title="UserManagement" Language="C#" MasterPageFile="~/PavanCourier.master"
    AutoEventWireup="true" CodeFile="UserManagement.aspx.cs" Inherits="UserManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        function SelectAll() {
            document.getElementById("<%=ChkMastersAll.ClientID%>").checked = document.getElementById("<%=SelectAll.ClientID%>").checked
            document.getElementById("<%=ChkTransAll.ClientID%>").checked = document.getElementById("<%=SelectAll.ClientID%>").checked
            document.getElementById("<%=ChkAllReport.ClientID%>").checked = document.getElementById("<%=SelectAll.ClientID%>").checked

            SelectAllforMaster()
            SelectAllforTransaction()
            ChkAllReport()
        }
        function SelectAllforMaster() {
            document.getElementById("<%=chkzonea.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkzoneu.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkzoned.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkzonel.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked

            document.getElementById("<%=chkcountrya.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkcountryu.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkcountryd.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkcountryl.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked

            document.getElementById("<%=chkloca.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chklocu.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chklocd.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chklocl.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked

            document.getElementById("<%=chkproducta.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkproductu.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkproductd.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkproductl.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked

            document.getElementById("<%=chkdestnationa.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkdestnationu.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkdestnationd.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkdestnationl.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked

            document.getElementById("<%=chkcustomera.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkcustomeru.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkcustomerd.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkcustomerl.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked

            document.getElementById("<%=chkcontracta.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkcontractu.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkcontractd.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkcontractl.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked

            document.getElementById("<%=chkdelroutea.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkdelrouteu.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkdelrouted.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkdelroutel.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked

            document.getElementById("<%=chkcouriera.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkcourieru.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkcourierd.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkcourierl.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked

            document.getElementById("<%=chkdelexceptiona.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkdelexceptionu.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkdelexceptiond.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkdelexceptionl.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked

            document.getElementById("<%=chkchargea.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkchargeu.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkcharged.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked
            document.getElementById("<%=chkchargel.ClientID%>").checked = document.getElementById("<%=ChkMastersAll.ClientID%>").checked


        }
        function SelectAllforTransaction() {

            document.getElementById("<%=chkstockinwarda.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=chkstockinwardu.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=chkstockinwardd.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=chkstockinwardl.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked

            document.getElementById("<%=chkstockissuea.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=chkstockissueu.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=chkstockissued.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=chkstockissuel.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked

            document.getElementById("<%=chkdrsa.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=chkdrsu.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=chkdrsd.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=chkdrsl.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked

            document.getElementById("<%=chkmanifesta.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=chkmanifestu.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=chkmanifestd.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=chkmanifestl.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked

            document.getElementById("<%=chkpoda.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=chkpodu.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=chkpodd.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=chkpodl.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked

            document.getElementById("<%=chkCreditBookingA.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=chkCreditBookingU.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=chkCreditBookingD.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=chkCreditBookingL.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked

            document.getElementById("<%=ChkCashBookingA.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=ChkCashBookingU.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=ChkCashBookingD.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=ChkCashBookingL.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked

            document.getElementById("<%=ChkTrace.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked
            document.getElementById("<%=ChkConsignee.ClientID%>").checked = document.getElementById("<%=ChkTransAll.ClientID%>").checked




        }
        function ChkAllReport() {

            document.getElementById("<%=ChkStockInwardR.ClientID%>").checked = document.getElementById("<%=ChkAllReport.ClientID%>").checked
            document.getElementById("<%=ChkStockIssueRDt.ClientID%>").checked = document.getElementById("<%=ChkAllReport.ClientID%>").checked
            document.getElementById("<%=ChkStockIssueC.ClientID%>").checked = document.getElementById("<%=ChkAllReport.ClientID%>").checked
            document.getElementById("<%=ChkManifestR.ClientID%>").checked = document.getElementById("<%=ChkAllReport.ClientID%>").checked
            document.getElementById("<%=chkDailyR.ClientID%>").checked = document.getElementById("<%=ChkAllReport.ClientID%>").checked

        }

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
                            User Management</h4>
                    </div>
                    <div style="float: right;">
                    </div>
                </div>
                <div class="widget-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table class="CommonTable2" style="width: 100%">
                                <tr>
                                    <td colspan="11">
                                        Branch&nbsp;
                                        <asp:DropDownList ID="DDlBranch" DataValueField="NID" DataTextField="cName" AutoPostBack="true"
                                            runat="server" Width="250px" OnSelectedIndexChanged="DDlBranch_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DDLUsername"
                                            ErrorMessage="&lt;img src='Images/writing-icon.jpg' border='0'/&gt;" InitialValue="0"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="11">
                                        User name&nbsp;
                                        <asp:DropDownList ID="DDLUsername" DataValueField="NID" DataTextField="cName" AutoPostBack="true"
                                            runat="server" Width="250px" OnSelectedIndexChanged="DDLUsername_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="DDLUsername"
                                            ErrorMessage="&lt;img src='Images/writing-icon.jpg' border='0'/&gt;" InitialValue="0"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="11">
                                        <strong>( Select All
                                            <asp:CheckBox ID="SelectAll" runat="server" onclick="SelectAll();" />
                                            ) </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <th colspan="5" style="text-align: center">
                                        Masters <span style="float: right">(Select All
                                            <asp:CheckBox ID="ChkMastersAll" runat="server" onclick="SelectAllforMaster();" />)
                                        </span>
                                    </th>
                                    <th style="text-align: center; width: 10px" rowspan="13">
                                    </th>
                                    <th colspan="5" style="text-align: center">
                                        Transactions <span style="float: right">(Select All
                                            <asp:CheckBox ID="ChkTransAll" runat="server" onclick="SelectAllforTransaction();" />)
                                        </span>
                                    </th>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                        <strong>Form Name</strong>
                                    </td>
                                    <td style="width: 30px">
                                        <strong>Add</strong>
                                    </td>
                                    <td style="width: 30px">
                                        <strong>Update</strong>
                                    </td>
                                    <td style="width: 30px">
                                        <strong>Delete</strong>
                                    </td>
                                    <td style="width: 30px">
                                        <strong>List</strong>
                                    </td>
                                    <%--<td style="width: 10px" rowspan="19">
                        </td>--%>
                                    <td style="width: 100px">
                                        <strong>Form Name</strong>
                                    </td>
                                    <td style="width: 30px">
                                        <strong>Add</strong>
                                    </td>
                                    <td style="width: 30px">
                                        <strong>Update</strong>
                                    </td>
                                    <td style="width: 30px">
                                        <strong>Delete</strong>
                                    </td>
                                    <td style="width: 30px">
                                        <strong>List</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Zone
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkzonea" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkzoneu" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkzoned" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkzonel" runat="server" />
                                    </td>
                                    <td>
                                        Stock Inward
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkstockinwarda" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkstockinwardu" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkstockinwardd" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkstockinwardl" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Country
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkcountrya" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkcountryu" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkcountryd" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkcountryl" runat="server" />
                                    </td>
                                    <td>
                                        Stock Issue
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkstockissuea" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkstockissueu" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkstockissued" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkstockissuel" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Location
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkloca" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chklocu" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chklocd" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chklocl" runat="server" />
                                    </td>
                                    <td>
                                        DRS
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkdrsa" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkdrsu" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkdrsd" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkdrsl" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Product
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkproducta" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkproductu" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkproductd" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkproductl" runat="server" />
                                    </td>
                                    <td>
                                        Manifest
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkmanifesta" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkmanifestu" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkmanifestd" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkmanifestl" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Destination
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkdestnationa" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkdestnationu" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkdestnationd" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkdestnationl" runat="server" />
                                    </td>
                                    <td>
                                        POD
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkpoda" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkpodu" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkpodd" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkpodl" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Customer
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkcustomera" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkcustomeru" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkcustomerd" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkcustomerl" runat="server" />
                                    </td>
                                    <td>
                                        Credit Booking
                                    </td>
                                   <td>
                                        <asp:CheckBox ID="chkCreditBookingA" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkCreditBookingU" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkCreditBookingD" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkCreditBookingL" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Contract
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkcontracta" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkcontractu" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkcontractd" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkcontractl" runat="server" />
                                    </td>
                                    <td>
                                        Cash Booking
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="ChkCashBookingA" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="ChkCashBookingU" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="ChkCashBookingD" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="ChkCashBookingL" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Delivery Route
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkdelroutea" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkdelrouteu" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkdelrouted" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkdelroutel" runat="server" />
                                    </td>
                                    <td>
                                        Trace
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="ChkTrace" runat="server" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Courier
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkcouriera" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkcourieru" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkcourierd" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkcourierl" runat="server" />
                                    </td>
                                    <td>
                                        Consignee
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="ChkConsignee" runat="server" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Delivery Exception
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkdelexceptiona" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkdelexceptionu" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkdelexceptiond" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkdelexceptionl" runat="server" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Charge
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkchargea" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkchargeu" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkcharged" runat="server" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkchargel" runat="server" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                            <table class="CommonTable2" style="width: 100%">
                                <tr>
                                    <th colspan="6">
                                        Reports
                                    </th>
                                </tr>
                                <tr id="trAccount1" runat="server">
                                    <td width="10%">
                                        <asp:CheckBox ID="ChkAllReport" runat="server" onclick="ChkAllReport();" />
                                        <strong>Reports</strong>
                                    </td>
                                    <td width="15%">
                                        <asp:CheckBox ID="ChkStockInwardR" runat="server" />
                                        Stock Inward Datewise
                                    </td>
                                    <td width="15%">
                                        <asp:CheckBox ID="ChkStockIssueRDt" runat="server" />
                                        Stock Issue Datewise
                                    </td>
                                    <td width="15%">
                                        <asp:CheckBox ID="ChkStockIssueC" runat="server" />
                                        Stock Issue Customer wise
                                    </td>
                                    <td width="15%">
                                        <asp:CheckBox ID="ChkManifestR" runat="server" />
                                        Manifest Report
                                    </td>
                                    <td width="15%">
                                        <asp:CheckBox ID="chkDailyR" runat="server" />
                                        Daily Report
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="Btnsubmit" Text="Submit" runat="server" class="btn btn-info" ValidationGroup="Main"
                                            TabIndex="5" OnClick="Btnsubmit_Click" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ChkMastersAll" EventName="CheckedChanged" />
                            <asp:AsyncPostBackTrigger ControlID="ChkTransAll" EventName="CheckedChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

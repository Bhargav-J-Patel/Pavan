<%@ Page Title="List Cash Booking" Language="C#" MasterPageFile="~/PavanCourier.master"
    AutoEventWireup="true" CodeFile="ListCashBooking.aspx.cs" Inherits="ListCashBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/icheck/icheck.min.js" type="text/javascript"></script>
    <script src="js/datatables/js/jquery.dataTables.js" type="text/javascript"></script>
    <script src="js/datatables/js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="js/datatables/tools/js/dataTables.tableTools.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $('input.tableflat').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                radioClass: 'iradio_flat-green'
            });
            var asInitVals = new Array();
            //$('#divProgressBar').attr('style', 'display:none;');
            var oTable = $('#datatable').DataTable({
                columns: [
                //{ 'data': 'NID' },
                 {'data': 'BookinbNo' },
                    { 'data': 'BookingDt' },
                    { 'data': 'cust' },
                    { 'data': 'dest' },
                     { 'data': 'weight' },
                     { 'data': 'amt' },
                    { 'data': 'cedit' },
                    { 'data': 'cdelete' },
                    { 'data': 'cprint' }
                ],
                "aoColumnDefs": [
                        {
                            'bSortable': false,
                            'aTargets': [6,7,8]
                        } //disables sorting for column one
                        ],

                bServerSide: true,
                sAjaxSource: 'ListPage.asmx/ListCashBooking',
                sServerMethod: 'post',
                "sPaginationType": "full_numbers",
                'iDisplayLength': 50
            });
            //$(tableTools.fnContainer()).insertBefore('#datatable_wrapper');


            $.ajax({
                type: "POST",
                url: "ListPage.asmx/UserManagement",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d.cash.substr(1, 1) != "1") {
                        oTable.column(6).visible(false);
                    }
                    if (data.d.cash.substr(2, 1) != "1") {
                        oTable.column(7).visible(false);
                    }
                }
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
                            List Cash Booking</h4>
                    </div>
                    <div style="float: right;">
                        <asp:Button ID="Button1" Text="Add New" runat="server" class="btn btn-primary" Style="margin-top: 4px;
                            margin-right: 3px;" OnClick="btnaddnew_Click" />
                        <%--<button name="btnAdd" id="btnAdd" class="btn btn-primary" onclick="List()" style="margin-top: 4px;
                            margin-right: 3px;">
                            <i class="icon wb-plus" style="margin-left: 0px; padding-left: 0px;"></i>Add New</button>--%>
                    </div>
                </div>
                <div class="widget-body">
                    <div id="MyDiv" class="modal-body">
                        <div id="datatable_wrapper" class="dataTables_wrapper" role="grid">
                            <table id="datatable" width="100%" class="table table-responsive table-bordered table-hover"
                                area-describedby="datatable_info" cellspacing="1px">
                                <thead>
                                    <tr style="background-color: #2A3F54; color: #fff; height: 34px;">
                                        <th style="width: 100px; padding: 5px 0px 5px 5px;">
                                            AWB No
                                        </th>
                                        <th style="width: 120px; padding: 5px 0px 5px 5px;">
                                            Booking Date
                                        </th>
                                        <th style="padding: 5px 0px 5px 5px;">
                                            Customer Name
                                        </th>
                                        <th style="padding: 5px 0px 5px 5px;">
                                            Destination
                                        </th>
                                        <th style="padding: 5px 0px 5px 5px;">
                                            Weight
                                        </th>
                                        <th style="padding: 5px 0px 5px 5px;">
                                            Amount
                                        </th>
                                        <th style="width: 25px; padding: 5px 0px 5px 5px;">
                                            &nbsp;
                                        </th>
                                        <th style="width: 25px; padding: 5px 0px 5px 5px;">
                                            &nbsp;
                                        </th>
                                        <th style="width: 25px; padding: 5px 0px 5px 5px;">
                                            &nbsp;
                                        </th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

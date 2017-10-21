﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PavanCourier.master" AutoEventWireup="true"
    CodeFile="ListCustomer.aspx.cs" Inherits="ListCustomer" %>

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
                    
                    { 'data': 'code' },
                    { 'data': 'name' },
                    { 'data': 'mob' },
                    { 'data': 'eid' },
                    { 'data': 'contract' },
                    
                    { 'data': 'cedit' },
                    { 'data': 'cdelete' }
                ],
                "aoColumnDefs": [
                        {
                            'bSortable': false,
                            'aTargets': [5,6]
                        } //disables sorting for column one
                        ],

                bServerSide: true,
                sAjaxSource: 'ListPage.asmx/ListCustomer',
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
                    if (data.d.customer.substr(1, 1) != "1") {
                        oTable.column(6).visible(false);
                    }
                    if (data.d.customer.substr(2, 1) != "1") {
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
                            List Customer Master</h4>
                    </div>
                    <div style="float: right;">
                        <asp:Button ID="btnaddnew" Text="Add New" runat="server" class="btn btn-primary"
                            Style="margin-top: 4px; margin-right: 3px;" OnClick="btnaddnew_Click" />
                    </div>
                </div>
                <div class="widget-body">
                    <div id="MyDiv" class="modal-body">
                        <div id="datatable_wrapper" class="dataTables_wrapper" role="grid">
                            <table id="datatable" width="100%" area-describedby="datatable_info" cellspacing="1px" class="table table-responsive table-bordered table-hover">
                                <thead>
                                    <tr style="background-color: #2A3F54; color: #fff; height: 34px;">
                                        
                                        <th style="width: 120px; padding: 5px 0px 5px 5px;">
                                            Code
                                        </th>
                                        <th style="padding: 5px 0px 5px 5px;">
                                            Name
                                        </th>
                                        <th style="padding: 5px 0px 5px 5px;">
                                            Mob No
                                        </th>
                                        <th style="padding: 5px 0px 5px 5px;">
                                            Email ID
                                        </th>
                                        <th style="padding: 5px 0px 5px 5px;">
                                            Contract
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
    <%--
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
            <div style="float:left">
                <h4 class="widget-title">List Customer Master</h4>
            </div>
			<div style="float:right;">
                <asp:Button ID="btnaddnew" Text="Add New" runat="server" class="btn btn-primary" 
                    style="margin-top:4px;margin-right:3px;" onclick="btnaddnew_Click"/>
            </div>	
			</div>
			<div class="widget-body">
                    <asp:GridView ID="GvCustomerList" runat="server" AutoGenerateColumns="false" PageSize="50"
                    AllowPaging="true" OnPageIndexChanging="GvCustomerList_PageIndexChanging" class="table table-striped table-bordered table-hover">
                    <Columns>
                        <asp:BoundField DataField="NID" Visible="false"/>
                        <asp:BoundField HeaderText="Code" DataField="cCustomerCode" />
                        <asp:BoundField HeaderText="Name" DataField="cCustomerName" />
                        <asp:BoundField HeaderText="Mobile No" DataField="cMobNo" />
                        <asp:BoundField HeaderText="Email Id" DataField="cEmailID" />
                        <asp:BoundField HeaderText="Contract" DataField="cContractName" />
                     
                        <asp:TemplateField HeaderText="..." ItemStyle-Width="5%">
                            <ItemTemplate>
                                <a href='<%#Eval("NID","MasterCustomer.aspx?id={0}&E=1") %>'>
                                <asp:Image ID="ImgEdit" ImageUrl="assets/img/edit.png" runat="server" title="Edit"/>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="..." ItemStyle-Width="5%">
                            <ItemTemplate>
                                <a href='<%#Eval("NID","MasterCustomer.aspx?id={0}&D=1") %>'>
                                <asp:Image ID="ImgEdit" ImageUrl="assets/img/delete.png" runat="server" title="Edit"/>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    </asp:GridView>
           </div>
        </div>
    </div>
</div>--%>
</asp:Content>

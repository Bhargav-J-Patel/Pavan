<%@ Page Title="" Language="C#" MasterPageFile="~/PavanCourier.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
                <h4 class="widget-title">Add User</h4>
            </div>
			    <div style="float:right;">
                <%--<asp:Button ID="btnlist" Text="List" runat="server" class="btn btn-primary" style="margin-top:4px;margin-right:3px;" onclick="btnlist_Click"/>--%>
                </div>	
			</div>
			<div class="widget-body">
				<table class="commontable">
                     <tr>
                        <th width="100px;">
                            Name :
                        </th>
                        <td>
                            <asp:TextBox runat="server" id="txtname" class="col-xs-6 txtbox"/>  
                        </td>
                    </tr>
                    <tr>
                        <th width="100px;">
                            Contact No :
                        </th>
                        <td>
                            <asp:TextBox runat="server" id="txtcontactno" class="col-xs-6 txtbox"/>  
                        </td>
                    </tr>
                    <tr>
                        <th width="100px;">
                            User Name :
                        </th>
                        <td>
                            <asp:TextBox runat="server" id="txtusername" class="col-xs-6 txtbox"/>  
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Password :
                        </th>
                        <td>
                            <asp:TextBox runat="server" id="txtpassword" class="col-xs-12 txtbox"/>
                        </td>
                    </tr>
                     <tr>
                        <th>
                           User Admin :
                        </th>
                        <td>
                            <asp:CheckBox runat="server"  ID="chkadmin" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Branch :
                        </th>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlbranch" DataValueField="NID" DataTextField="cName">
                            </asp:DropDownList>
                        </td>
                    </tr>
                   
                   
                    <tr>
                        <td colspan="2">
                            <asp:DropDownList ID="ddldelete" runat="server" Visible="false">
                                <asp:ListItem>No</asp:ListItem>
                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button Text="Submit" runat="server" class="btn btn-info" ID="btnsubmit" onclick="btnsubmit_Click"/>
                            <asp:Button Text="Reset" runat="server" class="btn resetbtn" ID="btnreset" 
                                onclick="btnreset_Click"/>
                        </td>
                    </tr>
                </table>
			</div>
	    </div>
	</div>
</div>
</asp:Content>



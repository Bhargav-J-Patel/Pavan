<%@ Page Title="" Language="C#" MasterPageFile="~/PavanCourier.master" AutoEventWireup="true" CodeFile="AddBranch.aspx.cs" Inherits="AddBranch" %>

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
    <div class="col-xs-12 col-sm-12">
		<div class="widget-box">
			<div class="widget-header">
            <div style="float:left">
                <h4 class="widget-title">Branch Master</h4>
            </div>
			<div style="float:right;">
                <asp:Button ID="btnlist" Text="List" runat="server" class="btn btn-primary" 
                    style="margin-top:4px;margin-right:3px;" onclick="btnlist_Click"/>
            </div>	
			</div>
			<div class="widget-body">
				<table class="commontable">
                 <tr>
                        <th width="100px;">
                            Sr No :
                        </th>
                        <td>
                            <asp:TextBox runat="server" id="txtsrno" class="bgcolrblue txtbox" Enabled="false" style="text-align:right;"/>  
                        </td>
                    </tr>
                    <tr>
                        <th width="100px;">
                            Branch Code :
                        </th>
                        <td>
                            <asp:TextBox runat="server" id="txtbranchcode" class="bgcolrblue txtbox"/>  
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Branch Name :
                        </th>
                        <td>
                            <asp:TextBox runat="server" id="txtbranchname" class="bgcolrblue txtbox" Width="250px"/>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Address :
                        </th>
                        <td>
                            <asp:TextBox runat="server" id="txtaddress" class="bgcolrblue" TextMode="MultiLine" Width="200px"/>
                            
                        </td>
                    </tr>
                    <tr>
                        <th>
                            PIN Code No :
                        </th>
                        <td>
                            <asp:TextBox runat="server" id="txtpincodeno" class="bgcolrblue txtbox"/>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Contact No :
                        </th>
                        <td>
                            <asp:TextBox runat="server" id="txtcontactno" class="bgcolrblue  txtbox"/>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            PAN No :
                        </th>
                        <td>
                            <asp:TextBox runat="server" id="txtpanno" class="bgcolrblue  txtbox"/>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:DropDownList ID="ddldelete" runat="server" Visible="false">
                                <asp:ListItem>No</asp:ListItem>
                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            </asp:DropDownList>

                            <asp:Button ID="btnsubmit" Text="Submit" runat="server" class="btn btn-info" onclick="btnsubmit_Click"/>
                        
                            <asp:Button ID="btnreset" Text="Reset" runat="server" class="btn resetbtn"/>
                        </td>
                    </tr>
                </table>
			</div>
	    </div>
	</div>
</div>
</asp:Content>




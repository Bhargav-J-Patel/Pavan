<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/PavanCourier.master"
    AutoEventWireup="true" CodeFile="TranChangePassword.aspx.cs" Inherits="TranChangePassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                           Change Password</h4>
                    </div>
                    <div style="float: right;">
                    </div>
                </div>
                <div class="widget-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table class="commontable">
                            <tr>
                                    <th style="width: 20%;">
                                        Current Password :
                                    </th>
                                    <td>
                                        <asp:TextBox ID="TxtCurrentPswd" CssClass="txtbox" runat="server" Width="40%"
                                            TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtCurrentPswd"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='EDIT' alt='View' border='0'/&gt;"
                                            ValidationGroup="Main"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 20%;">
                                        New Password :
                                    </th>
                                    <td>
                                        <asp:TextBox ID="TxtNewPswd" CssClass="txtbox" runat="server" Width="40%" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtNewPswd"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='EDIT' alt='View' border='0'/&gt;"
                                            ValidationGroup="Main"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 20%;">
                                        Confirm Password :
                                    </th>
                                    <td>
                                        <asp:TextBox ID="TxtConfirmPswd" CssClass="txtbox" runat="server" Width="40%"
                                            TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtConfirmPswd"
                                            ErrorMessage="&lt;img src='assets/img/writing-icon.jpg' title='EDIT' alt='View' border='0'/&gt;"
                                            ValidationGroup="Main"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Not Match"
                                            ControlToCompare="TxtNewPswd" ControlToValidate="TxtConfirmPswd" ValidationGroup="Main"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="btn btn-outline btn-primary"
                                            ValidationGroup="Main" OnClick="BtnSave_Click" />
                                        <asp:Button ID="Btncancel" runat="server" Text="Cancel" CssClass="btn btn-outline btn-info"
                                            OnClick="Btncancel_Click" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="TxtCurrentPswd" EventName="TextChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

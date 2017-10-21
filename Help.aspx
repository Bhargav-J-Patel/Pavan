<%@ Page Title="" Language="C#" MasterPageFile="~/PavanCourier.master" AutoEventWireup="true" CodeFile="Help.aspx.cs" Inherits="Help" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
.Help{margin-bottom:50px;}
.Help td{ padding: 20px 50px 5px 20px; border: 0px solid #000; color:Black; }
    .style1
    {
        text-align:right;
        width: 185px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="x_panel" style="height: 100%; margin-top:30px;">
<h2 style ="padding-left:150px;"> Help </h2>    
<div class="col-md-12 col-sm-12 col-xs-12" > 

 <table class="Help" border="0">
    <tr>
    <td class="style1"><asp:TextBox class="txtbox bgcolrblue" ID="t1" runat="server" Width="180px"></asp:TextBox></td>
    <td>Here This is text box control. it is an input control thats the user enter text. <br />This blue Text field user can Enter Alpha-numeric data. i.e abc123 </td>
    </tr>
    <!--<br /> Click in the Box n Enter data u want  -->     
        
    <tr>
    <td class="style1"><asp:TextBox class="txtbox bgcolrred"  ID="t2" runat="server"   Width="180px"></asp:TextBox></td>
    <td>Here This is text box control. it is an input control thats the user enter Numbers. <br />This Red Text field user can Enter Numeric data. i.e 123 </td>
    </tr>
    
    <tr>
    <td class="style1"><asp:TextBox class="txtbox bgcolrgreen"  ID="t3" runat="server" Width="180px" ></asp:TextBox></td>
    <td>Here user can enter "**" Then all Record are fetch in this field. This  green text box is autocomlete.</td>
    </tr>
    
    <tr>
    <td class="style1"><asp:FileUpload ID="FileUpload1" runat="server"  Width="180px" ReadOnly="true" /></td>
    <td>Here user can Upload files to the server using this FielUpload control. User can upload any type of file using this control. i.e image.jpg, abc.txt</td>
    </tr>

    <tr>
    <td class="style1"><asp:TextBox CssClass="txtbox bgcolrblue date_picker" ID="T4" runat="server" Width="180px"></asp:TextBox> 
    <cc1:CalendarExtender ID="TxtDate1_CalendarExtender" runat="server" Format="dd/MM/yyyy" CssClass="cal_Theme1" TargetControlID="T4"></cc1:CalendarExtender>
    </td>
    <td>Here this is Date picker control. when user click on control automatically a calander display. <br /> and user can select Date from using this control. </td>
    </tr>

    <tr>
    <td class="style1"> <asp:DropDownList ID="D1" runat="server" ReadOnly="true" CssClass="BGcolorBlue" Width="180px" ></asp:DropDownList></td>
    <td>Here This control provides multiple data. User can Choose one data from Listing.  </td>
    </tr>
    
    <tr>
    <td class="style1"> <asp:CheckBox ID="CheckBox1" runat="server" ReadOnly="true" /> <asp:CheckBox ID="CheckBox2" runat="server" ReadOnly="true" /> <asp:CheckBox ID="CheckBox3" runat="server" ReadOnly="true" /> </td>
    <td>Here This control provides Multiple Selection data. user can select multi data using this control. <br /> checked or unchecked this field according user's requirement.</td>
    </tr>                        

    <tr>
    <td class="style1"> <asp:RadioButton ID="RadioButton1" runat="server"  GroupName="a2" CssClass="chkbox"/>   <asp:RadioButton ID="RadioButton2" GroupName="a2" runat="server"  CssClass="chkbox"/></td>
    <td>Here This control provides Single Option Selection. user can choose only one data of them. if user Choose Second data, automatically first selcetion is remove.</td>
    </tr>    

    <tr>
    <td class="style1"><asp:Image ID="Image1" runat="server" Height="16px" ImageUrl="assets/img/writing-icon.jpg"  />  </td>
    <td>This Image display when any text control have submit blank data. <br />
    Its shows user that enter valid data in the text control.</td>
    </tr>
     
     
    <%--<tr> 
    <td class="style1"><asp:Image ID="Imgserch" runat="server" Height="16px" ImageUrl="~/images/icons/Search.png" />  </td>
    <td>This control provide search data from the listing.   </td> 
    </tr>--%>
      
    <tr>
    <td class="style1"><asp:Image ID="ImgBtnAdd" runat="server" ImageUrl="assets/img/add.png" CssClass="imgadd" title="Add" /></td>
    <td>Here this is button is for insert data. clilcking that user can save their data to the server side. before clicling u can syore about your data is correct & all field are filled.</td>
    </tr>
    
   <%-- <tr>
    <td class="style1"><asp:Image ID="ImgBtnCancel" runat="server" ImageUrl="~/images/cancel.png"  CssClass="imgcancel" title="Cancel" /></td>
    <td>Here this button is for cancel. user can cancel their work before completeing.  </td>
    </tr>--%>
    
    <tr>
    <td class="style1"><asp:Image ID="Image2" runat="server" Height="16px" ImageUrl="assets/img/edit.png" title="Edit"  />  </td>
    <td>Here this button Provide user that they can change their data by clicking this  control. after clicking all data is Editable form. also user update their data to the server side.</td>
    </tr>
    <tr>

    <td class="style1"><asp:Image ID="Image3" runat="server" Height="16px" ImageUrl="assets/img/delete.png" title="Delete" />  </td>
    <td>Here this Delete button provides user that user can delete their unused data from the Serverside. 
    while user delete their data, user Make syore about their data, because ones user delete their data. it cant be recover.</td>
    </tr>

    <tr>
    <td class="style1"><asp:Image ID="Image4"  runat="server" ImageUrl="assets/img/printer.png" title="Print"  /> </td>
    <td>Clicking this control user can Print their data. </td>
    </tr>
    
  <%--  <tr>
    <td class="style1"><asp:Image ID="Image5" runat="server"  ImageUrl="~/images/icons/export-excel-icon1.png" title="Excel Export" /></td>
    <td>Clicking this control user can Export their data to Excelsheet </td>
    </tr>--%>

<%--<tr><td style="text-align:right;width:250px;" class="glyphicon glyphicon-home">  </td> <td>This icon shows all Master</td></tr> 
<tr><td style="text-align:right;width:250px;" class="glyphicon glyphicon-edit">  </td> <td>This icon shows all Transaction</td></tr> 
<tr><td style="text-align:right;width:250px;" class="glyphicon glyphicon-envelope">  </td> <td>This icon shows all Reports</td></tr> 
<tr><td style="text-align:right;width:250px;" class="glyphicon glyphicon-user">  </td> <td>This icon shows user Management</td></tr> --%>

</table>



</div>
</div>



<%--<div style="margin-top:20px;">
<asp:Button CssClass="btn btn-round btn-success" ID="BtnPrint" runat="server"  Text="Print" />
<asp:Button CssClass="btn btn-round btn-info" ID="BtnExportToExcel" runat="server" Text="Export To Excel" />
<asp:Button CssClass="btn btn-round btn-warning" ID="btnback" runat="server" Text="Back" />
<asp:Button CssClass="btn btn-round btn-success" ID="btngraph" runat="server" Text="Graph" />
<asp:Button CssClass="btn btn-round btn-info" ID="BtnList" runat="server" Text="List" />
<asp:Button CssClass="btn btn-round btn-success" ID="BtnAddNew" runat="server" Text="Add New" />
<asp:Button CssClass="btn btn-success" ID="BtnUpdate" runat="server" Text="Submit" />
<asp:Button CssClass="btn btn-primary" ID="BtnCancel" runat="server" Text="Cancel" />
</div>--%>

</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManifestRpt.aspx.cs" Inherits="ManifestRpt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manifest Report</title>
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function PrintGridData() {
            var prtGrid = document.getElementById('<%=DivPrint.ClientID %>');
            prtGrid.border = 0;
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write(prtGrid.outerHTML);
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="success" runat="server" id="divsucess" visible="false">
        <asp:Label ID="lblsucess" runat="server" Text=""></asp:Label></div>
    <div class="warning" runat="server" id="DivWarning" visible="false">
        <asp:Label ID="LblWarning" runat="server" Text=""></asp:Label></div>
    <div class="error" runat="server" id="diverror" visible="false">
        <asp:Label ID="lblerror" runat="server" Text=""></asp:Label></div>
    <asp:ImageButton ID="Print" runat="server" OnClientClick="PrintGridData()" AlternateText="Print"
        ToolTip="Print" ImageUrl="assets/img/printer.png" />
    <center>
        <div id="DivPrint" runat="server" style="width: 100%; margin-top: 10px;">
            <asp:Label ID="lblreport" runat="server" Text=""></asp:Label>
        </div>
    </center>
    </form>
</body>
</html>

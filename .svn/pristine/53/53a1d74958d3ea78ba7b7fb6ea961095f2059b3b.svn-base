<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reporting.aspx.cs" Inherits="nerp.report.reporting" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="300" EnablePartialRendering="true" >
    </asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
  <asp:Panel ID="pnList" runat="server">

    <rsweb:ReportViewer ID="rpViewer" runat="server" Width="100%"></rsweb:ReportViewer>
      
</asp:Panel>
</ContentTemplate>

</asp:UpdatePanel> 
        </form>
</body>
</html>

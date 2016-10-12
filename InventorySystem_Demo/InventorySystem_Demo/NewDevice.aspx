<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewDevice.aspx.cs" Inherits="InventorySystem_Demo.NewDevice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        设备名称：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        设备IMEI：<asp:TextBox ID="txtIMEI" runat="server"></asp:TextBox>
        <br />
        所属区域：<asp:DropDownList ID="ddlAreaId" runat="server">
        </asp:DropDownList>
        <br />
        描&nbsp;&nbsp; 述：<asp:TextBox ID="textDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" />
&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="返回" OnClick="Button2_Click" />

    </div>
    </form>
</body>
</html>

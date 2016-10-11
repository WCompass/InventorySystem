<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeviceProfile.aspx.cs" Inherits="InventorySystem_Demo.DeviceProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        设备名称：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        设备IMEI：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        所属区域：<asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <br />
        描&nbsp;&nbsp; 述：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        状&nbsp;&nbsp; 态：<asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
        <br />
        创建时间：<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        创建人：<asp:DropDownList ID="DropDownList3" runat="server">
        </asp:DropDownList>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="修改" />
&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="返回" />

    </div>
    </form>
</body>
</html>

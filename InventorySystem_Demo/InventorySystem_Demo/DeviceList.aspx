<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeviceList.aspx.cs" Inherits="InventorySystem_Demo.DeviceList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="设备名称" />
                <asp:BoundField DataField="IMEI" HeaderText="设备IMEI" />
                <asp:BoundField DataField="AreaId" HeaderText="所属区域" />
                <asp:BoundField DataField="StatusCodeText" HeaderText="状态" />
                <asp:ButtonField CommandName="Delete" Text="删除" />
                <asp:ButtonField CommandName="Update" Text="详情/修改" />
            </Columns>
        </asp:GridView>
        <br />
    </div>
    </form>
</body>
</html>

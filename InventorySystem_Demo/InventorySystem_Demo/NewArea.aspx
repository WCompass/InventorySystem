<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewArea.aspx.cs" Inherits="InventorySystem_Demo.NewArea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <div>
            <asp:Button ID="btnSubmt" runat="server" OnClick="btnSubmt_Click" Text="保存" />
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消" />
        </div>
        <div>
                <div>区域编号：</div><div><asp:TextBox ID="txtCode" runat="server"></asp:TextBox></div>
                <div>区域名称：</div><div><asp:TextBox ID="txtName" runat="server"></asp:TextBox></div>
                <div>区域顺序：</div><div><asp:TextBox ID="txtLevel" runat="server"></asp:TextBox>
                </div>
                <div>区域负责人：</div><div>
                <asp:DropDownList ID="ddlOwner" runat="server">
                </asp:DropDownList>
                </div>
                <div>描述：</div><div><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox></div>
        </div>
    </div>
</form>
</body>
</html>

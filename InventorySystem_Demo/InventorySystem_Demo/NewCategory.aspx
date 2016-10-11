<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewCategory.aspx.cs" Inherits="InventorySystem_Demo.NewCategory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dl>
                <dd>添加类目</dd>
                <dt>类目编号：<asp:TextBox ID="txtCode" runat="server"></asp:TextBox></dt>
                <dt>类目名称：<asp:TextBox ID="txtName" runat="server"></asp:TextBox></dt>
                <dt>类目等级：<asp:TextBox ID="txtLevel" runat="server"></asp:TextBox></dt>
                <dt>类目描述：<asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox></dt>
                <dt>
                    <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" style="height: 21px" />&nbsp;<asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" /></dt>
            </dl>
        </div>
    </form>
</body>
</html>

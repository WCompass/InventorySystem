<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewItem.aspx.cs" Inherits="InventorySystem_Demo.NewItem" %>

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
                <dd>添加物品</dd>
                <dt>物品编号：<asp:TextBox ID="txtCode" runat="server"></asp:TextBox></dt>
                <dt>物品名称：<asp:TextBox ID="txtName" runat="server"></asp:TextBox></dt>
                <dt>物品类目：<asp:DropDownList ID="ddlCategoryId" runat="server"></asp:DropDownList></dt>
                <dt>物品价格：<asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></dt>
                <dt>描述：<asp:TextBox ID="txtDescription" runat="server"></asp:TextBox></dt>
                <dt>
                    <asp:Button ID="btnSave" runat="server" Text="保存" />&nbsp;<asp:Button ID="btnCancel" runat="server" Text="取消" /></dt>
            </dl>
        </div>
    </form>
</body>
</html>

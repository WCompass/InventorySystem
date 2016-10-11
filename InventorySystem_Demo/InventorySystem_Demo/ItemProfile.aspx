<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemProfile.aspx.cs" Inherits="InventorySystem_Demo.ItemProfile" %>

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
                <dd>修改物品</dd>
                <dt>物品编号：<asp:TextBox ID="txtCode" runat="server"></asp:TextBox></dt>
                <dt>物品名称：<asp:TextBox ID="txtName" runat="server"></asp:TextBox></dt>
                <dt>物品类目：<asp:DropDownList ID="ddlCategoryId" runat="server"></asp:DropDownList></dt>
                <dt>物品价格：<asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></dt>
                <dt>物品描述：<asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox></dt>
                <dt>物品状态：<asp:DropDownList ID="ddlStatus" runat="server"></asp:DropDownList></dt>
                <dt>创建时间：<asp:TextBox ID="txtCreatedTime" runat="server" Enabled="False"></asp:TextBox></dt>
                <dt>创建人：<asp:TextBox ID="txtCreatedBy" runat="server" Enabled="False"></asp:TextBox></dt>
                <dt>
                    <asp:Button ID="btnEdit" runat="server" Text="修改" OnClick="btnEdit_Click" />&nbsp;<asp:Button ID="btnBack" runat="server" Text="返回" OnClick="btnBack_Click" />&nbsp;<asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"  OnClientClick="return confirm('确定删除吗？')" /></dt>
            </dl>
        </div>
    </form>
</body>
</html>

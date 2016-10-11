<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaProfile.aspx.cs" Inherits="InventorySystem_Demo.AreaProfile" %>

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
            <asp:Button ID="btnSubmt" runat="server" OnClick="btnSubmt_Click" Text="修改" />
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消" />
        </div>
        <div>
            <ul>
                <li>
                    <div>区域编号：</div><div><asp:TextBox ID="txtCode" runat="server"></asp:TextBox></div><div></div>
                </li>
                <li>
                    <div>区域名称：</div><div><asp:TextBox ID="txtName" runat="server"></asp:TextBox></div><div></div>
                </li>
                <li>
                    <div>区域顺序：</div><div><asp:TextBox ID="txtLevel" runat="server"></asp:TextBox>
                    </div><div></div>
                </li>
                <li>
                    <div>区域负责人：</div><div><asp:TextBox ID="txtOwner" runat="server"></asp:TextBox>
                    </div><div></div>
                </li>
                <li>
                    <div>创建人：</div><div><asp:TextBox ID="txtCreatedBy" runat="server" Enabled="False"></asp:TextBox>
                    </div><div></div>
                </li>
                <li>
                    <div>创建时间：</div><div><asp:TextBox ID="txtCreatedTime" runat="server" Enabled="False"></asp:TextBox></div><div></div>
                </li>
                <li>
                    <div>状态：</div><div>
                    <asp:DropDownList ID="ddlStatusCode" runat="server">
                        <asp:ListItem Value="1">启用</asp:ListItem>
                        <asp:ListItem Value="2">已删除</asp:ListItem>
                        <asp:ListItem Value="3">禁用</asp:ListItem>
                    </asp:DropDownList>
                    </div><div></div>
                </li>
                <li>
                    <div>描述：</div><div><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox></div><div></div>
                </li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebPaging.ascx.cs" Inherits="InventorySystem_Demo.WebPaging" %>
<table border="0" style="text-align: center;">
    <tr>
        <td style="height: 2px;"></td>
    </tr>
    <tr>
        <td>
            <asp:LinkButton ID="lbFirst" ForeColor="#57a9bd" runat="server" OnClick="lbFirst_Click">首 页</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="lbUp" ForeColor="#57a9bd" runat="server" OnClick="lbUp_Click">上一页</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="lbDown" ForeColor="#57a9bd" runat="server" OnClick="lbDown_Click">下一页</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="lbLast" ForeColor="#57a9bd" runat="server" OnClick="lbLast_Click">末 页</asp:LinkButton>
            &nbsp;&nbsp; 共<asp:Label ID="lblRecord" runat="server" ForeColor="#57a9bd"></asp:Label>项
            &nbsp;&nbsp;&nbsp;页次：<asp:Label ID="lblPage" runat="server" ForeColor="#57a9bd"></asp:Label>
            /
            <asp:Label ID="lblPageTotal" runat="server" ForeColor="#57a9bd"></asp:Label>页
            &nbsp;&nbsp;跳到<asp:TextBox ID="txtPage" runat="server" Width="30px" onpaste="return false"></asp:TextBox>页
            <asp:Button ID="btnGo" runat="server" Text=" 跳 转 " OnClick="btnGo_Click"></asp:Button>
        </td>
    </tr>
</table>

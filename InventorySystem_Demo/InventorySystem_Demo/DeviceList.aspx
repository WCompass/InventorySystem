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
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加新设备" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnRowCommand="GridView1_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField  HeaderText="设备名称">
                    <EditItemTemplate>
                        <asp:LinkButton ID="lkbName" runat="server" CommandName="Profile" Text='<%# Bind("Name") %>'></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lkbName" runat="server" CommandName="Profile" Text='<%# Eval("Name") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="IMEI" HeaderText="设备IMEI" />
                <asp:BoundField DataField="AreaIdName" HeaderText="所属区域" />
                <asp:BoundField DataField="StatusCodeText" HeaderText="状态" />
                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Delete" OnClientClick="return confirm(&quot;是否删除？&quot;)" Text="删除"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <br />
    </div>
    </form>
</body>
</html>

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
                <div>区域编号：</div><div><asp:TextBox ID="txtCode" runat="server"></asp:TextBox></div>
                <div>区域名称：</div><div><asp:TextBox ID="txtName" runat="server"></asp:TextBox></div>
                <div>区域顺序：</div><div><asp:TextBox ID="txtLevel" runat="server"></asp:TextBox>
                </div>
                <div>区域负责人：</div><div>
                <asp:DropDownList ID="ddlOwner" runat="server">
                </asp:DropDownList>
                </div>
                <div>创建人：</div><div><asp:TextBox ID="txtCreatedBy" runat="server" Enabled="False"></asp:TextBox></div>
                <div>创建时间：</div><div><asp:TextBox ID="txtCreatedTime" runat="server" Enabled="False"></asp:TextBox></div>
                <div>状态：</div><div>
                <asp:DropDownList ID="ddlStatusCode" runat="server">
                </asp:DropDownList>
                </div>
                <div>描述：</div><div><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox></div>
        </div>
        <div>
            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="DeviceId" ForeColor="Black" GridLines="Vertical" OnRowCommand="GridView1_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="DeviceId" HeaderText="DeviceId" ReadOnly="True" SortExpression="DeviceId" Visible="False" />
                        <asp:TemplateField HeaderText="Name" SortExpression="Name">
                            <EditItemTemplate>
                                <asp:LinkButton ID="lkbName" runat="server" CommandName="Profile" Text='<%# Bind("Name") %>'></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbName" runat="server" CommandName="Profile" Text='<%# Eval("Name") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IMEI" HeaderText="IMEI" SortExpression="IMEI" />
                        <asp:BoundField DataField="AreaId" HeaderText="AreaId" SortExpression="AreaId" Visible="False" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" Visible="False" />
                        <asp:BoundField DataField="CreatedTime" HeaderText="CreatedTime" SortExpression="CreatedTime" Visible="False" />
                        <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" SortExpression="CreatedBy" Visible="False" />
                        <asp:BoundField DataField="StatusCode" HeaderText="StatusCode" SortExpression="StatusCode" Visible="False" />
                        <asp:BoundField DataField="AreaIdName" HeaderText="AreaIdName" SortExpression="AreaIdName" />
                        <asp:BoundField DataField="CreatedByName" HeaderText="CreatedByName" SortExpression="CreatedByName" Visible="False" />
                        <asp:BoundField DataField="StatusCodeText" HeaderText="StatusCodeText" SortExpression="StatusCodeText" />
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbDelete" runat="server" CommandName="MyDelete" OnClientClick="return confirm('是否删除？')">删除</asp:LinkButton>
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
            </div>
            <div>
                <asp:GridView ID="GridView2" runat="server">
                </asp:GridView>
            </div>
        </div>
    </div>
</form>
</body>
</html>

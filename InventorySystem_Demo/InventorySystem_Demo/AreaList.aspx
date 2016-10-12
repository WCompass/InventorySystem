<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaList.aspx.cs" Inherits="InventorySystem_Demo.AreaList" %>

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
            <div>

            </div>
        </div>
        <div>
            <div>
                <asp:Button ID="BtnAdd" runat="server" Text="添加" OnClick="BtnAdd_Click" />
            </div>
        </div>
        <div>
            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AreaId" OnRowCommand="GridView1_RowCommand" EmptyDataText="暂无数据" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="AreaId" HeaderText="AreaId" ReadOnly="True" SortExpression="AreaId" Visible="False" />
                        <asp:TemplateField HeaderText="Name" SortExpression="Name">
                            <EditItemTemplate>
                                <asp:LinkButton ID="lkbName" runat="server" CommandName="Profile" Text='<%# Bind("Name") %>'></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbName" runat="server" CommandName="Profile" Text='<%# Eval("Name") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
                        <asp:BoundField DataField="Level" HeaderText="Level" SortExpression="Level" />
                        <asp:BoundField DataField="Owner" HeaderText="Owner" SortExpression="Owner" Visible="False" />
                        <asp:BoundField DataField="OwnerName" HeaderText="OwnerName" SortExpression="OwnerName" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" Visible="False" />
                        <asp:BoundField DataField="CreatedTime" HeaderText="CreatedTime" SortExpression="CreatedTime" Visible="False" />
                        <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" SortExpression="CreatedBy" Visible="False" />
                        <asp:BoundField DataField="StatusCode" HeaderText="StatusCode" SortExpression="StatusCode" Visible="False" />
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
        </div>
    </div>
    </form>
</body>
</html>

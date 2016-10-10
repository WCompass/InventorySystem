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

            </div>
        </div>
        <div>
            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AreaId" OnRowCommand="GridView1_RowCommand" EmptyDataText="暂无数据">
                    <Columns>
                        <asp:BoundField DataField="AreaId" HeaderText="AreaId" ReadOnly="True" SortExpression="AreaId" Visible="False" />
                        <asp:TemplateField HeaderText="区域编号" SortExpression="Code">
                            <EditItemTemplate>
                                <asp:LinkButton ID="lkbProfile" runat="server" CommandName="Profile" Text='<%# Eval("Code") %>'></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbProfile" runat="server" CommandName="Profile" Text='<%#Bind("Code") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="区域名称" SortExpression="Name" />
                        <asp:BoundField DataField="Level" HeaderText="区域排序" SortExpression="Level" />
                        <asp:BoundField DataField="Owner" HeaderText="区域负责人" SortExpression="Owner" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" Visible="False" />
                        <asp:BoundField DataField="CreatedTime" HeaderText="CreatedTime" SortExpression="CreatedTime" Visible="False" />
                        <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" SortExpression="CreatedBy" Visible="False" />
                        <asp:BoundField DataField="StatusCode" HeaderText="StatusCode" SortExpression="StatusCode" Visible="False" />
                        <asp:BoundField DataField="OwnerName" HeaderText="OwnerName" SortExpression="OwnerName" Visible="False" />
                        <asp:BoundField DataField="CreatedByName" HeaderText="CreatedByName" SortExpression="CreatedByName" Visible="False" />
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbDelete" runat="server" CommandName="MyDelete">删除</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>
    </form>
</body>
</html>

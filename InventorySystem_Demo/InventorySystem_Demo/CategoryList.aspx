<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="InventorySystem_Demo.CategoryList" %>

<%@ Register Src="~/WebPaging.ascx" TagPrefix="uc1" TagName="WebPaging" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="Search">
            <asp:LinkButton ID="lbAdd" runat="server" OnClick="lbAdd_Click">新增</asp:LinkButton>
        </div>
        <div class="Show">
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="暂无数据" DataKeyNames="CategoryId" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="CategoryId" HeaderText="类目ID" SortExpression="CategoryId" Visible="False" />
                    <asp:ButtonField CommandName="MyNum" DataTextField="Code" HeaderText="类目编号" SortExpression="Code" />
                    <asp:BoundField DataField="Code" HeaderText="类目编号" SortExpression="Code" Visible="False" />
                    <asp:BoundField DataField="Name" HeaderText="类目名称" SortExpression="Name" />
                    <asp:BoundField DataField="Level" HeaderText="类目等级" SortExpression="Level" />
                    <asp:BoundField DataField="StatusCodeText" HeaderText="类目状态" SortExpression="StatusCodeText" />   
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbDelete" runat="server" CausesValidation="false" OnClientClick="return confirm('确定删除吗？')" Text="删除" CommandArgument='<%# Eval("CategoryId") %>' OnClick="lbDelete_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
        <uc1:WebPaging runat="server" ID="WebPaging" />
    </form>
</body>
</html>

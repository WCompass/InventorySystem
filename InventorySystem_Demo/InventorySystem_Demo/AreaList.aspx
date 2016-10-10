﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaList.aspx.cs" Inherits="InventorySystem_Demo.AreaList" %>

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
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AreaId">
                    <Columns>
                        <asp:BoundField DataField="AreaId" HeaderText="AreaId" ReadOnly="True" SortExpression="AreaId" Visible="False" />
                        <asp:TemplateField HeaderText="Code" SortExpression="Code">
                            <EditItemTemplate>
                                <asp:LinkButton ID="lkbProfile" runat="server" CommandName="Profile" Text='<%# Bind("Code") %>'></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbProfile" runat="server" CommandName="Profile"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Level" HeaderText="Level" SortExpression="Level" />
                        <asp:BoundField DataField="Owner" HeaderText="Owner" SortExpression="Owner" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:BoundField DataField="CreatedTime" HeaderText="CreatedTime" SortExpression="CreatedTime" />
                        <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" SortExpression="CreatedBy" />
                        <asp:BoundField DataField="StatusCode" HeaderText="StatusCode" SortExpression="StatusCode" />
                        <asp:BoundField DataField="OwnerName" HeaderText="OwnerName" SortExpression="OwnerName" />
                        <asp:BoundField DataField="CreatedByName" HeaderText="CreatedByName" SortExpression="CreatedByName" />
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbDelete" runat="server" CommandName="MyDelete"></asp:LinkButton>
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

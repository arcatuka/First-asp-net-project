<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlyFanSite.aspx.cs" Inherits="OnlyFanSite.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OnlyFanForm</title>
    <style>
        html {display:table; margin:auto;}
        body {display:table-cell; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2 align="center">ONLYFAN LIST</h2>
        <asp:TextBox ID="txtKeyword" runat="server" placeholder="Keyword"/>
        <asp:Button ID="btnSearch" runat="server" Text="SEARCH" OnClick="BtnSearch_Click" /><br />
        <asp:GridView ID="gvOnlyFan" runat="server" AutoGenerateSelectButton="true" OnSelectedIndexChanged="gvOnlyFan_SelectedIndexChanged" />

        <h2 align="center">ONLYFAN DETAIL</h2>
        <table>
            <tr>
                <td>ID</td>
                <td><asp:TextBox ID ="txtID" runat="server" /></td>
            </tr>
            <tr>
                <td>Name</td>
                <td><asp:TextBox ID="txtName" runat="server" /></td>
            </tr>
            <tr>
                <td>Gender</td>
                <td><asp:TextBox ID="txtGender" runat="server" /></td>
            </tr>
            <tr>
                <td>Age</td>
                <td><asp:TextBox ID="txtAge" runat="server" /></td>
            </tr>
            <tr>
                <td>Price</td>
                <td><asp:TextBox ID="txtPrice" runat="server" /></td>
            </tr>
        </table><br />
        <asp:Button ID="btnAdd" runat="server" Text="ADD NEW" OnClick="btnAdd_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="DELETE" OnClick="btnDelete_Click" />
    </form>
</body>
</html>

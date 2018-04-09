<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HelloWorld.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu Items</title>
    <link href="Content/CMS.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="divAdmin" runat="server">
            <strong><u>Menu Items</u></strong><br />

            <asp:Repeater ID="rptAdmin" runat="server" EnableViewState="False">
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%#Eval("Url")%>' Text='<%#Eval("Text")%>' Target='<%#Eval("Target")%>' ></asp:HyperLink><br /><br />
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>

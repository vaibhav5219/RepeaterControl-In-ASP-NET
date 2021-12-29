<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepeaterCRUDStoredprocedure.aspx.cs" Inherits="RepeaterControlStoredProcedure.RepeaterCRUDStoredprocedure" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
    <HeaderTemplate>
        <table  border="1" cellpadding="0" cellspacing="0">
            <tr>
                <th scope="col" style="width: 120px">
                    Name
                </th>
                <th scope="col" style="width: 100px">
                    Address
                </th>
                <th scope="col" style="width: 120px">
                    Email
                </th>
                <th scope="col" style="width: 100px">
                    Mobile
                </th>
                <th scope="col" style="width: 120px">
                    Password
                </th>
                <th scope="col" style="width: 150px">
                </th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:Label ID="lblUserId" runat="server" Text='<%# Eval("UserId") %>' Visible = "false" />
                <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("UserName") %>' />
                <asp:TextBox ID="txtUserName" runat="server" Width="120" Text='<%# Eval("UserName") %>'
                    Visible="false" />
            </td>
            <td>
                <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("UserAddress") %>' />
                <asp:TextBox ID="txtAddress" runat="server" Width="120" Text='<%# Eval("UserAddress") %>'
                    Visible="false" />
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("UserEmail") %>' />
                <asp:TextBox ID="TextBox1" runat="server" Width="120" Text='<%# Eval("UserEmail") %>'
                    Visible="false" />
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Usermobile") %>' />
                <asp:TextBox ID="TextBox2" runat="server" Width="120" Text='<%# Eval("Usermobile") %>'
                    Visible="false" />
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Password") %>' />
                <asp:TextBox ID="TextBox3" runat="server" Width="120" Text='<%# Eval("Password") %>'
                    Visible="false" />
            </td>
            <td>
                <asp:LinkButton ID="lnkEdit" Text="Edit  | " runat="server" OnClick="OnEdit" />
                <asp:LinkButton ID="lnkUpdate" Text="Update  |  " runat="server" Visible="false" OnClick="OnUpdate" />
                <asp:LinkButton ID="lnkCancel" Text="Cancel" runat="server" Visible="false" OnClick="OnCancel" />
                <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" OnClick="OnDelete" OnClientClick="return confirm('Do you want to delete this row?');" />
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
        <br />
<table border="1" cellpadding="0" cellspacing="0" >
    <tr>
        <td style="width: 150px">
            User Name:<br />
            <asp:TextBox ID="txtName" runat="server" Width="140" />
        </td>
        <td style="width: 150px">
            Address:<br />
            <asp:TextBox ID="TextAddress" runat="server" Width="140" />
        </td>
        <td style="width: 150px">
            User Email:<br />
            <asp:TextBox ID="TextEmail" runat="server" Width="140" />
        </td>
        <td style="width: 150px">
            Mobile:<br />
            <asp:TextBox ID="Textmobile" runat="server" Width="140" />
        </td>
        <td style="width: 150px">
            Password:<br />
            <asp:TextBox ID="txtPassword" runat="server" Width="140" />
        </td>
        <td style="width: 100px">
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert_Data" />
        </td>
    </tr>
</table>
    </div>
    </form>
</body>
</html>

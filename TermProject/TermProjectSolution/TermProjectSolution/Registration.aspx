<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="TermProjectSolution.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" text="Email*" ID="RegisterEmailLabel"></asp:Label>
            <asp:TextBox runat="server" placeholder="example@server.com" id="RegisterEmailTxtBox"></asp:TextBox>
            <br />
             <asp:Label runat="server" text="Password*" ID="RegisterPasswordLabel"></asp:Label>
            <asp:TextBox runat="server" TextMode="Password" id="RegisterPasswordTxtBox"></asp:TextBox>
            <br />
             <asp:Label runat="server" text="Confirm Password*" ID="RegisterCPasswordLabel"></asp:Label>
            <asp:TextBox runat="server" TextMode="Password" id="RegisterCPasswordTxtBox"></asp:TextBox>
            <br />
            <asp:Button Text="Register" ID="RegisterUserButton" runat="server" OnClick="RegisterUserButton_Click" />
        </div>
    </form>
    
</body>
</html>

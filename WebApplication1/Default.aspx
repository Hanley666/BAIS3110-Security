<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default"  ValidateRequest="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <hr />
            HTML Input Validation Test
            <asp:TextBox ID="aMessage" runat="server" Rows="10" TextMode="MultiLine" Width="100%" />
            <asp:Button ID="Button1" runat="server" Text="Submit" UseSubmitBehavior="true" />
            
            <br />
            <hr />
        </div>
        Save to Filename
        <asp:TextBox ID="aFileName" runat="server" Width="150"></asp:TextBox>
        <asp:RegularExpressionValidator ID="regexpName" runat="server"     
                                    ErrorMessage="This expression does not validate." 
                                    ControlToValidate="aFileName"     
                                    ValidationExpression="^[a-z]{1,8}\.[a-z]{1.3}$"/>
        <br />
    </form>
</body>
</html>

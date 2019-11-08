<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="SecurityExercise._Default" ValidateRequest="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <hr />
            HTML Input Validation Test<br />
            <asp:TextBox ID="aMessage" runat="server" Rows="10" TextMode="MultiLine" Width="100%" />
            <asp:Button ID="Button1" runat="server" Text="Submit" UseSubmitBehavior="true" />
            <br />
            <hr />
        </div>
            Save To File:<br />
            <asp:TextBox ID="aFileName" runat="server" Width="150"></asp:TextBox>
        <br />
    </form>
</body>
</html>

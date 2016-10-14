<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASP.Net_Project.WebForms.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="NameLabel" AssociatedControlId="uxName" Text="Name" runat="server"/>
        <asp:TextBox runat="server" ID="uxName" />
        <br />
        <br />
        <asp:Label ID="DropLabel" AssociatedControlID="uxPriority" Text="Priority" runat="server"/>
        <asp:DropDownList runat="server" ID="uxPriority">
            <asp:ListItem Text="High" />
            <asp:ListItem Text="Medium" />
            <asp:ListItem Text="Low" />
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="SubjectLabel" AssociatedControlId="uxSubject" Text="Subject" runat="server"/>
        <asp:TextBox runat="server" ID="uxSubject" />
        <br />
        <br />
        <asp:Label ID="Description" AssociatedControlId="uxDescription" Text="Description" runat="server"/>
        <asp:TextBox runat="server" ID="uxDescription" TextMode="MultiLine" Columns="50" Rows="5" />
        <br />
        <br />
        <asp:Button runat="server" ID="uxSubmit" Text="Submit" OnClick="uxSubmit_Click" />
        <asp:Literal runat="server" ID="uxFormOutput" />
        <asp:Literal runat="server" ID="uxEventOutput" />
        <br />
        <br />
    </div>
    </form>
</body>
</html>

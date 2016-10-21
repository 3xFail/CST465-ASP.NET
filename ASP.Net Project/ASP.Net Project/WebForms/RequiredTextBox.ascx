<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RequiredTextBox.ascx.cs" Inherits="ASP.Net_Project.WebForms.RequiredTextBox" %>


<asp:Label runat ="server" AssociatedControlID="uxTextBox" ID="uxLabel"></asp:Label>
<asp:TextBox runat="server" ID="uxTextBox"></asp:TextBox>
<asp:RequiredFieldValidator runat ="server" ID="uxValidator" ControlToValidate="uxTextBox" Text="*"></asp:RequiredFieldValidator>
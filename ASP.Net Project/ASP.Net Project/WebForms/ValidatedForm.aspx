<%@ Page MasterPageFile="~/WebForms/Site1.Master" Language="C#" AutoEventWireup="true" CodeBehind="ValidatedForm.aspx.cs" Inherits="ASP.Net_Project.WebForms.ValidatedForm" %>
<%@ Register TagPrefix="CST" TagName="RequiredTextBox" Src="~/WebForms/RequiredTextBox.ascx" %>



<asp:Content runat="server" ContentPlaceHolderID="uxContentPlaceHolderMain" ID="ContentNav">
    <asp:Panel runat="server">
        <CST:RequiredTextBox runat="server" LabelText="Name: " ID="uxName" ValidationGroup="default"> </CST:RequiredTextBox>
        <br />
        <CST:RequiredTextBox runat="server" LabelText="Favorite Color: " ID="uxFavoriteColor" ValidationGroup="default"> </CST:RequiredTextBox>
        <br />
        <CST:RequiredTextBox runat="server" LabelText="City: " ID="uxCity" ValidationGroup="default"> </CST:RequiredTextBox>
        <br />
        <asp:Button runat="server" Text="Submit" ID="uxSubmit" OnClick="uxSubmit_Click" />
    </asp:Panel>
</asp:Content>
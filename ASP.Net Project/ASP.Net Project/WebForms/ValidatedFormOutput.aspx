<%@ Page MasterPageFile="~/WebForms/Site1.Master" Language="C#" AutoEventWireup="true" CodeBehind="ValidatedFormOutput.aspx.cs" Inherits="ASP.Net_Project.WebForms.ValidatedFormOutput" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="uxContentPlaceHolderMain">
    <asp:PlaceHolder runat="server" ID="uxInvaildDataArea" Visible="false">
        <p>This form did not receive the parameters expected</p>
    </asp:PlaceHolder>

    <asp:PlaceHolder runat="server" ID="uxVaildDataArea" Visible="false">
        <div>
            Name: <asp:Literal runat="server" ID="uxName" />
        </div>
        <div>
            Favorite Color: <asp:Literal runat="server" ID="uxFavoriteColor" />
        </div>
        <div>
            City: <asp:Literal runat="server" ID="uxCity" />
        </div>
    </asp:PlaceHolder>
</asp:Content>


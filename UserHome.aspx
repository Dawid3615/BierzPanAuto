<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralLayoutMaster.Master" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="BierzPanAuto.UserHome" %>

<asp:Content ID="ContentUserHome" ContentPlaceHolderID="ContentPlaceHolderGeneral" runat="server">
                    <div class="container">
                        <h1>Witaj użytkowniku !</h1>
                        <hr />
                        <asp:Label ID="lblShowUsername" runat="server" CssClass="text-success"></asp:Label>
                    </div>
 </asp:Content>
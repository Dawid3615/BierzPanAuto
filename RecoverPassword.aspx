<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralLayoutMaster.Master" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="BierzPanAuto.RecoverPassword" %>

<asp:Content ID="ContentRecoverPassword" ContentPlaceHolderID="ContentPlaceHolderGeneral" runat="server"> 
                    <div class="container signin-page-center">
                        <h1>Resetuj hasło</h1>
                        <hr />
                        <div class="g-3">
                            <div class="col-md-6">
                                <asp:Label ID="lblPassword" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Nowe hasło" Visible="False"></asp:Label>
                                <asp:TextBox ID="txtbPassword" TextMode="Password" CssClass="form-control form-control-sm" runat="server" placeholder="Nowe hasło" Visible="False"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" CssClass="text-danger" runat="server" ErrorMessage="Wprowadź nowe hasło !" ControlToValidate="txtbPassword"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="lblRetypePassword" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Powtórz nowe hasło" Visible="False"></asp:Label>
                                <asp:TextBox ID="txtbRetypePassword" TextMode="Password" CssClass="form-control form-control-sm" runat="server" placeholder="Potwierdź hasło" Visible="False"></asp:TextBox>
                                <asp:CompareValidator ID="cvRetypePassword" runat="server" ErrorMessage="Oba hasła muszą być takie same !" CssClass="text-danger" ControlToValidate="txtbPassword" ControlToCompare="txtbRetypePassword"></asp:CompareValidator>
                            </div>

                            <div class="col-md-12">
                                <asp:Button ID="btnPasswordReset" runat="server" CssClass="btn btn-sm btn-outline-success" Text="Resetuj" OnClick="btnPasswordReset_Click" Visible="False" />
                            </div>
                        </div>
                    </div>

</asp:Content>

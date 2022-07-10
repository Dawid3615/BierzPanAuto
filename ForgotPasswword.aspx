<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralLayoutMaster.Master" AutoEventWireup="true" CodeBehind="ForgotPasswword.aspx.cs" Inherits="BierzPanAuto.ForgotPasswword" %>

<asp:Content ID="ContentForgotPassword" ContentPlaceHolderID="ContentPlaceHolderGeneral" runat="server">
                    <!-- Forgot Password start -->
                    <div class="container signin-page-center">
                        <h1>Odzyskiwanie hasła</h1>
                        <hr />
                        <div class="g-3">
                            <h4>Podaj swój adres e-mail, wyślemy Ci instrukcje odzyskania hasła.</h4>
                                
                            <div class="col-12">
                                <asp:Label ID="lblEmail" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Twój Adres email"></asp:Label>
                                <asp:TextBox ID="txtbEmail" TextMode="Email" CssClass="form-control form-control-sm" runat="server" placeholder="Adres email"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" CssClass="text-danger" runat="server" ErrorMessage="Wprowadź swój identyfikator e-mail !" ControlToValidate="txtbEmail"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-12">
                                <asp:Button ID="btnPasswordRecover" runat="server" CssClass="btn btn-sm btn-outline-success" Text="Wyślij" OnClick="btnPasswordRecover_Click" />
                            </div>
                        </div>
                    </div>
                    <!-- Forgot Password end -->
</asp:Content>

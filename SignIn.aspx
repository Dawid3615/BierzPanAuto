<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralLayoutMaster.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="BierzPanAuto.SignIn" %>

<asp:Content ID="ContentSignIn" ContentPlaceHolderID="ContentPlaceHolderGeneral" runat="server">
                    <div class="container">
                        <h1>Zaloguj się !</h1>
                        <hr />
                        <!-- Sign In start -->
                        <div class="g-3">
                            <div class="col-md-12">
                                <asp:Label ID="lblUsername" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Nazwa użytkownika lub Adres email"></asp:Label>
                                <asp:TextBox ID="txtbUsernameEmail" CssClass="form-control form-control-sm" runat="server" placeholder="Nazwa użytkownika lub Adres email"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvUsernameEmail" CssClass="text-danger" runat="server" ErrorMessage="Pole nazwy użytkownika lub adresu e-mail jest wymagane !" ControlToValidate="txtbUsernameEmail"></asp:RequiredFieldValidator>
                            </div>
                            
                            <div class="col-md-12">
                                <asp:Label ID="lblPassword" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Hasło"></asp:Label>
                                <asp:TextBox ID="txtbPassword" TextMode="Password" CssClass="form-control form-control-sm" runat="server" placeholder="Hasło"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPassword" CssClass="text-danger" runat="server" ErrorMessage="Pole hasła jest wymagane !" ControlToValidate="txtbPassword"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-12">
                                <div class="form-check">
                                    <asp:Label ID="lblRememberMe" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Zapamiętaj mnie"></asp:Label>
                                    <asp:CheckBox ID="chkbRememberMe" runat="server" />
                                </div>
                            </div>

                            <div class="col-12">
                                <asp:Button ID="btnSignIn" runat="server" Text="Zaloguj się" CssClass="btn btn-sm btn-success" OnClick="btnSignIn_Click" />
                                <asp:LinkButton ID="lbtnRegister" runat="server" PostBackUrl="~/SignUp.aspx">Zarejestruj się</asp:LinkButton>
                            </div>

                            <div class="col-12">
                                <asp:LinkButton ID="lbtnForgotPassword" runat="server" PostBackUrl="~/ForgotPassword.aspx">Zapomniałeś hasła ?</asp:LinkButton>
                            </div>
                        </div>
                        <!-- Sign In end -->
                    </div>
</asp:Content>

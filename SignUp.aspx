<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralLayoutMaster.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="BierzPanAuto.SignUp" %>

<asp:Content ID="ContentSignUp" ContentPlaceHolderID="ContentPlaceHolderGeneral" runat="server">
                    <div class="container">
                        <h1>Zarejestruj się !</h1>
                        <hr />
                        <!-- Sign Up start -->
                        <div class="row g-3">
                            <div class="col-md-6">
                                <asp:Label CssClass="col-md-2 col-form-label col-form-label-sm" ID="lblUsername" runat="server" Text="Nazwa użytkownika"></asp:Label>
                                <asp:TextBox ID="txtbUsername" runat="server" CssClass="form-control form-control-sm" placeholder="Nazwa użytkownika"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <asp:Label CssClass="col-md-2 col-form-label col-form-label-sm" ID="lblEmail" runat="server" Text="Adres email"></asp:Label>
                                <asp:TextBox ID="txtbEmail" TextMode="Email" runat="server" CssClass="form-control form-control-sm" placeholder="Adres email"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <asp:Label CssClass="col-md-2 col-form-label col-form-label-sm" ID="lblPassword" runat="server" Text="Hasło"></asp:Label>
                                <asp:TextBox ID="txtbPassword" TextMode="Password" runat="server" CssClass="form-control form-control-sm" placeholder="Hasło"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <asp:Label CssClass="col-md-2 col-form-label col-form-label-sm" ID="lblPasswordConfirm" runat="server" Text="Potwierdź hasło"></asp:Label>
                                <asp:TextBox ID="txtbPasswordConfirm" TextMode="Password" runat="server" CssClass="form-control form-control-sm" placeholder="Potwierdź hasło"></asp:TextBox>
                            </div>

                            <div class="input-group">
                                <asp:Label CssClass="col-md-2 col-form-label col-form-label-sm" ID="lblFirstLastName" runat="server" Text="Imię i Nazwisko"></asp:Label>
                                <asp:TextBox ID="txtbFirstName" aria-label="First Name" runat="server" CssClass="form-control form-control-sm" placeholder="Imię"></asp:TextBox>
                                <asp:TextBox ID="txtbLastName" aria-label="Last Name" runat="server" CssClass="form-control form-control-sm" placeholder="Nazwisko"></asp:TextBox>
                            </div>

                            <div class="col-11">
                                <asp:Button ID="btnSignUp" runat="server" CssClass="btn btn-sm btn-success" Text="Zarejestruj się" OnClick="btnSignUp_Click" />
                                <asp:Label ID="lblMessages" runat="server"></asp:Label>
                            </div>
                        </div>
                        <!-- Sign Up end -->
                    </div>
    </asp:Content>

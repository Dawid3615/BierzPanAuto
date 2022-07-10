<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddTier.aspx.cs" Inherits="BierzPanAuto.AddTier" %>

<asp:Content ID="ContentAddTier" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <div class="container">
        <h1>Dodaj poziom</h1>
        <hr />
        <div class="col-12">
            <asp:Label ID="lblTier" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Nazwa poziomu"></asp:Label>
            <asp:TextBox ID="txtbName" CssClass="form-control form-control-sm" runat="server" placeholder="Nazwa poziomu"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTierName" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="txtbName"></asp:RequiredFieldValidator>
        </div>

        <div class="col-12">
            <asp:Label ID="lblClass" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Klasa"></asp:Label>
            <asp:DropDownList ID="ddlClass" CssClass="form-select form-select-sm" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvClass" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="ddlClass" InitialValue="0"></asp:RequiredFieldValidator>
        </div>

        <div class="col-12">
            <asp:Button ID="btnAddTier" runat="server" CssClass="btn btn-sm btn-success" Text="Dodaj poziom" OnClick="btnAddTier_Click"/>
        </div>
        <br /><br />
        <h1>Poziomy</h1>
        <hr />
        <div class="card">
           <div class="card-header">Wszystkie poziomy</div>
           <asp:Repeater ID="RepeaterTiers" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Poziom</th>
                                <th scope="col">Klasa</th>
                                <th scope="col">Edytuj</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th scope="row"><%# Eval("TierID") %></th>
                        <td><%# Eval("TierName") %></td>
                        <td><%# Eval("ClassName") %></td>
                        <td>Edit</td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

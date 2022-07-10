<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddGarage.aspx.cs" Inherits="BierzPanAuto.AddGarage" %>

<asp:Content ID="ContentAddGarage" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <div class="container">
        <h1>Dodaj garażowanie</h1>
        <hr />
        <div class="row g-3">
            <div class="col-12">
                <asp:Label ID="lblGarage" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Nazwa garażowania"></asp:Label>
                <asp:TextBox ID="txtbGarage" CssClass="form-control form-control-sm" runat="server" placeholder="Nazwa garażowania"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCarName" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="txtbGarage"></asp:RequiredFieldValidator>
            </div>

            <div class="col-12">
                <asp:Button ID="btnAddGarage" runat="server" CssClass="btn btn-sm btn-success" Text="Dodaj garażowanie" OnClick="btnAddGarage_Click" />
            </div>
        </div>
        <br /><br />
        <h1>Garażowanie</h1>
        <hr />
        <div class="card">
            <div class="card-header">Wszystkie typy garażowania</div>
            <asp:Repeater ID="RepeaterGarages" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Garażowanie</th>
                                <th scope="col">Edytuj</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th scope="row"><%# Eval("GarageID") %></th>
                        <td><%# Eval("GarageName") %></td>
                        <td>
                            <asp:Button ID="btnDelGarage" CssClass="btn btn-sm btn-outline-danger" Text="Usuń" runat="server" OnClick="btnDelGarage_Click"/>
                            <asp:Button ID="btnEditGarage" CssClass="btn btn-sm btn-outline-warning" Text="Edytuj" runat="server"/>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
</asp:Content>

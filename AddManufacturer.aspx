<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddManufacturer.aspx.cs" Inherits="BierzPanAuto.AddManufacturer" %>

<asp:Content ID="ContentAddManufacturer" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <div class="container">
        <h1>Dodaj markę</h1>
        <hr />
        <div class="row g-3">
            <div class="col-12">
                <asp:Label ID="lblManufacturer" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Nazwa marki"></asp:Label>
                <asp:TextBox ID="txtbManufacturer" CssClass="form-control form-control-sm" runat="server" placeholder="Nazwa marki"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCarName" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="txtbManufacturer"></asp:RequiredFieldValidator>
            </div>

            <div class="col-12">
                <asp:Button ID="btnAddManufacturer" runat="server" CssClass="btn btn-sm btn-success" Text="Dodaj markę" OnClick="btnAddManufacturer_Click" />
            </div>
        </div>
        <br /><br />
        <h1>Marki</h1>
        <hr />
        <div class="card">
            <div class="card-header">Wszystkie marki</div>
            <asp:Repeater ID="RepeaterManufacturers" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Marka</th>
                                <th></th>
                                <th scope="col">Edytuj</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th scope="row"><%# Eval("ManufacturerID") %></th>
                        <td style="width: 64px; /*background-color: #222222;*/"><img style="width: 64px; height: 64px;" src="img/ManufacturerImages/<%#Eval("ManufacturerImage") %>" alt="<%#Eval("ManufacturerName") %>"/></td>
                        <td><%# Eval("ManufacturerName") %></td>
                        <td>
                            <asp:Button ID="btnDelManufacturer" CssClass="btn btn-sm btn-outline-danger" Text="Usuń" runat="server" />
                            <asp:Button ID="btnEditManufacturer" CssClass="btn btn-sm btn-outline-warning" Text="Edytuj" runat="server"/>
                        </td>
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

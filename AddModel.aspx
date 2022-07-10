<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddModel.aspx.cs" Inherits="BierzPanAuto.AddModel" %>

<asp:Content ID="ContentAddModel" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <div class="container">
        <h1>Dodaj model</h1>
        <hr />
        <div class="row g-3">
            <div class="input-group mb-3">
                <asp:Label ID="lblModel" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Nazwa modelu"></asp:Label>
                <asp:TextBox ID="txtbModelName" aria-label="Model Name" runat="server" CssClass="form-control form-control-sm" placeholder="Nazwa modelu"></asp:TextBox>
                <asp:DropDownList ID="ddlManufacturer" CssClass="form-select form-select-sm" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvModel" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="txtbModelName"></asp:RequiredFieldValidator>
            </div>

            <div class="col-12">
                <asp:Button ID="btnAddModel" runat="server" CssClass="btn btn-sm btn-success" Text="Dodaj model" OnClick="btnAddModel_Click" />
            </div>
        </div>
        <br /><br />
        <h1>Modele</h1>
        <hr />
        <div class="card">
            <div class="card-header">Wszystkie modele</div>
            <asp:Repeater ID="RepeaterModels" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Marka</th>
                                <th scope="col">Model</th>
                                <th scope="col">Edytuj</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th scope="row"><%# Eval("ModelID") %></th>
                        <td><%#Eval("ManufacturerName") %></td>
                        <td><%# Eval("ModelName") %></td>
                        <td>Edytuj</td>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddGeneration.aspx.cs" Inherits="BierzPanAuto.AddGeneration" %>

<asp:Content ID="ContentAddGeneration" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <div class="container">
        <h1>Dodaj generację</h1>
        <hr />
         <div class="input-group mb-3">
            <asp:Label ID="lblGeneration" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Nazwa generacji"></asp:Label>
            <asp:TextBox ID="txtbGenerationName" aria-label="Paint Name" runat="server" CssClass="form-control form-control-sm" placeholder="Nazwa generacji"></asp:TextBox>
            <asp:DropDownList ID="ddlModel" CssClass="form-select form-select-sm" runat="server"></asp:DropDownList>
            <asp:DropDownList ID="ddlManufacturer" CssClass="form-select form-select-sm" runat="server"  OnSelectedIndexChanged="ddlManufacturer_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvGenerationName" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="txtbGenerationName"></asp:RequiredFieldValidator>
        </div>

        <div class="col-12">
            <asp:Button ID="btnAddGeneration" runat="server" CssClass="btn btn-sm btn-success" Text="Dodaj generację" OnClick="btnAddGeneration_Click" />
        </div>
        <br /><br />
        <h1>Generacje</h1>
        <hr />
        <div class="card">
            <div class="card-header">Wszystkie generacje</div>
            <asp:Repeater ID="RepeaterGenerations" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Generacja</th>
                                <th scope="col">Model</th>
                                <th scope="col">Marka</th>
                                <th scope="col">Edytuj</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th scope="row"><%# Eval("GenerationID") %></th>
                        <td><%# Eval("GenerationName") %></td>
                        <td><%# Eval("ModelName") %></td>
                        <td><%# Eval("ManufacturerName") %></td>
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

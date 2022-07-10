<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddColor.aspx.cs" Inherits="BierzPanAuto.AddColor" %>

<asp:Content ID="ContentAddColor" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <div class="container">
        <h1>Dodaj kolor</h1>
        <hr />
        <div class="input-group mb-3">
            <asp:Label ID="lblCar" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Samochód"></asp:Label>
            <asp:DropDownList ID="ddlCarManufacturer" CssClass="form-select form-select-sm" runat="server" OnSelectedIndexChanged="ddlCarManufacturer_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            <asp:DropDownList ID="ddlCarModel" CssClass="form-select form-select-sm" runat="server" OnSelectedIndexChanged="ddlCarModel_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            <asp:DropDownList ID="ddlCarGeneration" CssClass="form-select form-select-sm" runat="server"></asp:DropDownList>
        </div>

        <div class="input-group mb-3">
            <asp:Label ID="lblColor" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Kolor bazowy i podgląd"></asp:Label>
            <asp:DropDownList ID="ddlBasePaint" CssClass="form-select form-select-sm" runat="server"></asp:DropDownList>
            <asp:TextBox ID="txtbPaintPrewiev" aria-label="Paint Preview" runat="server" CssClass="form-control form-control-sm" placeholder="Podgląd koloru"></asp:TextBox>
            <asp:DropDownList ID="ddlPaintType" CssClass="form-select form-select-sm" runat="server"></asp:DropDownList>
        </div>

        <div class="col-12">
            <asp:Label ID="lblName" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Nazwa koloru"></asp:Label>
            <asp:TextBox ID="txtbName" CssClass="form-control form-control-sm" runat="server" placeholder="Nazwa koloru"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCarName" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="txtbName"></asp:RequiredFieldValidator>
        </div>

        <div class="col-12">
            <asp:Button ID="btnAddColor" runat="server" CssClass="btn btn-sm btn-success" Text="Dodaj kolor" OnClick="btnAddColor_Click"/>
        </div>

        <br /><br />
        <h1>Kolory</h1>
        <hr />
        <div class="card">
           <div class="card-header">Wszystkie kolory</div>
           <asp:Repeater ID="RepeaterColors" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Kolor</th>
                                <th scope="col">Kolor główny</th>
                                <th scope="col">Typ lakieru</th>
                                <th scope="col">Marka</th>
                                <th scope="col">Model</th>
                                <th scope="col">Generacja</th>
                                <th scope="col">Podgląd</th>
                                <th scope="col">Edytuj</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th scope="row"><%# Eval("ColorID") %></th>
                        <td><%# Eval("ColorName") %></td>
                        <td><%# Eval("BasePaintName") %></td>
                        <td><%# Eval("PaintTypeName") %></td>
                        <td><%# Eval("ManufacturerName") %></td>
                        <td><%# Eval("ModelName") %></td>
                        <td><%# Eval("GenerationName") %></td>
                        <td style="background-color:<%#Eval("ColorPreview") %>;"></td>
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

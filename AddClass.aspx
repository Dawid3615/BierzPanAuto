<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddClass.aspx.cs" Inherits="BierzPanAuto.AddClass" %>

<asp:Content ID="ContentAddClass" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <h1>Dodaj klasę</h1>
        <hr />
        <div class="row g-3">
            <div class="col-12">
                <asp:Label ID="lblClass" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Nazwa klasy"></asp:Label>
                <asp:TextBox ID="txtbClass" CssClass="form-control form-control-sm" runat="server" placeholder="Nazwa klasy"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvClassName" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="txtbClass"></asp:RequiredFieldValidator>
            </div>

            <div class="col-12">
                <asp:Button ID="btnAddClass" runat="server" CssClass="btn btn-sm btn-success" Text="Dodaj klasę" OnClick="btnAddClass_Click" />
            </div>
            <br /><br />
            <h1>Klasy</h1>
            <hr />
            <div class="card">
                <div class="card-header">Wszystkie klasy</div>
                <asp:Repeater ID="RepeaterClasses" runat="server">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Klasa</th>
                                    <th scope="col">Edytuj</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <th scope="row"><%# Eval("ClassID") %></th>
                            <td><%# Eval("ClassName") %></td>
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

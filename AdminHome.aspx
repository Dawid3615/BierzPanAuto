<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="BierzPanAuto.AdminHome" %>

<asp:Content ID="ContentAdminHome" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <div class="container">
		<h1>Witaj Admin</h1>
		<hr />
        <div class="table-responsive">
            <!-- Tabs -->
            <nav>
                <div class="nav nav-tabs" id="nav-tab" role="tablist">
                    <a class="nav-link active" id="nav-cars-tab" data-bs-toggle="tab" href="#nav-cars" role="tab" aria-controls="nav-cars" aria-selected="true">Samochody</a>
                    <a class="nav-link" id="nav-manufacturers-tab" data-bs-toggle="tab" href="#nav-manufacturers" role="tab" aria-controls="nav-manufacturers" aria-selected="false">Marki</a>
                    <a class="nav-link" id="nav-models-tab" data-bs-toggle="tab" href="#nav-models" role="tab" aria-controls="nav-models" aria-selected="false">Modele</a>
                    <a class="nav-link" id="nav-generations-tab" data-bs-toggle="tab" href="#nav-generations" role="tab" aria-controls="nav-generations" aria-selected="false">Generacje</a>
                    <a class="nav-link" id="nav-colors-tab" data-bs-toggle="tab" href="#nav-colors" role="tab" aria-controls="nav-colors" aria-selected="false">Kolory</a>
                    <a class="nav-link" id="nav-users-tab" data-bs-toggle="tab" href="#nav-users" role="tab" aria-controls="nav-users" aria-selected="false">Użytkownicy</a>
                    <a class="nav-link" id="nav-classes-tab" data-bs-toggle="tab" href="#nav-classes" role="tab" aria-controls="nav-classes" aria-selected="false">Klasy</a>
                    <a class="nav-link" id="nav-tiers-tab" data-bs-toggle="tab" href="#nav-tiers" role="tab" aria-controls="nav-tiers" aria-selected="false">Poziomy</a>
                    <a class="nav-link" id="nav-garages-tab" data-bs-toggle="tab" href="#nav-garages" role="tab" aria-controls="nav-garages" aria-selected="false">Garażowanie</a>
                </div>
            </nav>
            <!-- Content -->
            <div class="tab-content" id="nav-tabContent">
                <div class="tab-pane fade show active" id="nav-cars" role="tabpanel" aria-labelledby="nav-cars-tab">
                    <asp:Repeater ID="RepeaterCars" runat="server">
                        <HeaderTemplate>
                            <table class="table table-hover table-sm caption-top">
                                <caption>Lista samochodów</caption>
                                <thead>
                                    <tr>
                                        <th scope="col">#</th>
                                        <th scope="col">Nazwa</th>
                                        <th scope="col">Cena</th>
                                        <th scope="col">Cena sprzedaży</th>
                                        <th scope="col">Marka</th>
                                        <th scope="col">Model</th>
                                        <th scope="col">Generacja</th>
                                        <th scope="col">Klasa</th>
                                        <th scope="col">Poziom</th>
                                        <th scope="col">Opis</th>
                                        <th scope="col">Detale</th>
                                        <th scope="col">Miejsce postoju</th>
                                        <th scope="col">Typ garażowania</th>
                                        <th scope="col">Pojemność</th>
                                        <th scope="col">Typ silnika</th>
                                        <th scope="col">Pozycja silnika</th>
                                        <th scope="col">Liczba biegów</th>
                                        <th scope="col">Typ skrzyni biegów</th>
                                        <th scope="col">Rodzaj napędu</th>
                                        <th scope="col">Kolor</th>
                                        <th scope="col">Pogląd koloru</th>
                                        <th scope="col">Edytuj</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="clickable-row">
                                <th scope="row"><asp:Label ID="lblCarID" runat="server" Text='<%# Eval("CarID") %>'></asp:Label></th>
                                <td><%# Eval("Name") %></td>
                                <td><%# Eval("Price") %></td>
                                <td><%# Eval("SellPrice") %></td>
                                <td><%# Eval("ManufacturerName") %></td>
                                <td><%# Eval("ModelName") %></td>
                                <td><%# Eval("GenerationName") %></td>
                                <td><%# Eval("ClassName") %></td>
                                <td><%# Eval("TierName") %></td>
                                <td><%# Eval("Description") %></td>
                                <td><%# Eval("Details") %></td>
                                <td><%# Eval("Access") %></td>
                                <td><%# Eval("GarageName") %></td>
                                <td><%# Eval("Capacity") %></td>
                                <td><%# Eval("EngineName") %></td>
                                <td><%# Eval("EnginePosition") %></td>
                                <td><%# Eval("GearNumber") %></td>
                                <td><%# Eval("GearboxName") %></td>
                                <td><%# Eval("DriveName") %></td>
                                <td><%# Eval("ColorName") %></td>
                                <td style="background-color:<%#Eval("ColorPreview") %>;"></td>
                                <td>
                                    <asp:Button ID="btnCarEdit" CssClass="btn btn-sm btn-outline-warning rounded-pill" Text="Edytuj" runat="server" />
                                    <asp:Button ID="btnCarDelete" CssClass="btn btn-sm btn-outline-danger rounded-pill" Text="Usuń" runat="server" OnClick="btnCarDelete_Click" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="tab-pane fade" id="nav-manufacturers" role="tabpanel" aria-labelledby="nav-manufacturers-tab">
                    <asp:Repeater ID="RepeaterManufacturers" runat="server">
                        <HeaderTemplate>
                            <table class="table table-hover table-sm caption-top">
                                <caption>Lista marek</caption>
                                <thead>
                                    <tr>
                                        <th scope="col">#</th>
                                        <td></td>
                                        <th scope="col">Marka</th>
                                        <th scope="col">Edytuj</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="clickable-row">
                                <th scope="row"><asp:Label ID="lblManufacturerID" runat="server" Text='<%# Eval("ManufacturerID") %>'></asp:Label></th>
                                <td style="width: 64px; /*background-color: #222222;*/"><img style="width: 64px; height: 64px;" src="img/ManufacturerImages/<%#Eval("ManufacturerImage") %>" alt="<%#Eval("ManufacturerName") %>"/></td>
                                <td><asp:Label ID="lblManufacturerName" runat="server" Text='<%# Eval("ManufacturerName") %>'></asp:Label></td>
                                <td>
                                    <asp:Button ID="btnManufacturerEdit" CssClass="btn btn-sm btn-outline-warning rounded-pill" Text="Edytuj" runat="server" />
                                    <asp:Button ID="btnManufacturerDelete" CssClass="btn btn-sm btn-outline-danger rounded-pill" Text="Usuń" runat="server" OnClick="btnManufacturerDelete_Click" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="tab-pane fade" id="nav-models" role="tabpanel" aria-labelledby="nav-models-tab">
                    <asp:Repeater ID="RepeaterModels" runat="server">
                        <HeaderTemplate>
                            <table class="table table-hover table-sm caption-top">
                                <caption>Lista modeli</caption>
                                <thead>
                                    <tr>
                                        <th scope="col">#</th>
                                        <th scope="col">Model</th>
                                        <th scope="col">Marka</th>
                                        <th scope="col">Edytuj</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <th scope="row"><asp:Label ID="lblModelID" runat="server" Text='<%# Eval("ModelID") %>'></asp:Label></th>
                                <td><%# Eval("ModelName") %></td>
                                <td><%#Eval("ManufacturerName") %></td>
                                <td>
                                    <button type="button" class="btn btn-sm btn-outline-warning rounded-pill">Edytuj</button>
                                    <asp:Button ID="btnModelDelete" CssClass="btn btn-sm btn-outline-danger rounded-pill" Text="Usuń" runat="server" OnClick="btnModelDelete_Click" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="tab-pane fade" id="nav-generations" role="tabpanel" aria-labelledby="nav-generations-tab">
                    <asp:Repeater ID="RepeaterGenerations" runat="server">
                        <HeaderTemplate>
                            <table class="table table-hover table-sm caption-top">
                                <caption>Lista generacji</caption>
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
                                <th scope="row"><asp:Label ID="lblModelID" runat="server" Text='<%# Eval("GenerationID") %>'></asp:Label></th>
                                <td><%# Eval("GenerationName") %></td>
                                <td><%# Eval("ModelName") %></td>
                                <td><%# Eval("ManufacturerName") %></td>
                                <td>
                                    <button type="button" class="btn btn-sm btn-outline-warning rounded-pill">Edytuj</button>
                                    <asp:Button ID="btnGenerationDelete" CssClass="btn btn-sm btn-outline-danger rounded-pill" Text="Usuń" runat="server" OnClick="btnGenerationDelete_Click" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="tab-pane fade" id="nav-colors" role="tabpanel" aria-labelledby="nav-colors-tab">
                    <asp:Repeater ID="RepeaterColors" runat="server">
                        <HeaderTemplate>
                            <table class="table table-hover table-sm caption-top">
                                <caption>Lista kolorów</caption>
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
                                <th scope="row"><asp:Label ID="lblModelID" runat="server" Text='<%# Eval("ColorID") %>'></asp:Label></th>
                                <td><%# Eval("ColorName") %></td>
                                <td><%# Eval("BasePaintName") %></td>
                                <td><%# Eval("PaintTypeName") %></td>
                                <td><%# Eval("ManufacturerName") %></td>
                                <td><%# Eval("ModelName") %></td>
                                <td><%# Eval("GenerationName") %></td>
                                <td style="background-color:<%#Eval("ColorPreview") %>;"></td>
                                <td>
                                    <button type="button" class="btn btn-sm btn-outline-warning rounded-pill">Edytuj</button>
                                    <asp:Button ID="btnColorDelete" CssClass="btn btn-sm btn-outline-danger rounded-pill" Text="Usuń" runat="server" OnClick="btnColorDelete_Click" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="tab-pane fade" id="nav-users" role="tabpanel" aria-labelledby="nav-users-tab">
                    <asp:Repeater ID="RepeaterUsers" runat="server">
                        <HeaderTemplate>
                            <table class="table table-hover table-sm caption-top">
                                <caption>Lista użytkowników</caption>
                                <thead>
                                    <tr>
                                        <th scope="col">#</th>
                                        <th scope="col">Nazwa użytkownika</th>
                                        <th scope="col">Adres email</th>
                                        <th scope="col">Hasło</th>
                                        <th scope="col">Imię</th>
                                        <th scope="col">Nazwisko</th>
                                        <th scope="col">Typ konta</th>
                                        <th scope="col">Edytuj</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <th scope="row"><asp:Label ID="lblUserID" runat="server" Text='<%# Eval("UserID") %>'></asp:Label></th>
                                <td><%# Eval("Username") %></td>
                                <td><%# Eval("Email") %></td>
                                <td><%# Eval("Password") %></td>
                                <td><%# Eval("FirstName") %></td>
                                <td><%# Eval("LastName") %></td>
                                <td><%# Eval("UserType") %></td>
                                <td>
                                    <button type="button" class="btn btn-sm btn-outline-warning rounded-pill">Edytuj</button>
                                    <asp:Button ID="btnUserDelete" CssClass="btn btn-sm btn-outline-danger rounded-pill" Text="Usuń" runat="server" OnClick="btnUserDelete_Click" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="tab-pane fade" id="nav-classes" role="tabpanel" aria-label="nav-classes-tab">
                    <asp:Repeater ID="RepeaterClasses" runat="server">
                        <HeaderTemplate>
                            <table class="table table-hover table-sm caption-top">
                                <caption>Lista klas</caption>
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
                                <th scope="row"><asp:Label ID="lblClassID" runat="server" Text='<%# Eval("ClassID") %>'></asp:Label></th>
                                <td><%# Eval("ClassName") %></td>
                                <td>
                                    <button type="button" class="btn btn-sm btn-outline-warning rounded-pill">Edytuj</button>
                                    <asp:Button ID="btnClassDelete" CssClass="btn btn-sm btn-outline-danger rounded-pill" Text="Usuń" runat="server" OnClick="btnClassDelete_Click" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="tab-pane fade" id="nav-tiers" role="tabpanel" aria-label="nav-tiers-tab">
                    <asp:Repeater ID="RepeaterTiers" runat="server">
                        <HeaderTemplate>
                            <table class="table table-hover table-sm caption-top">
                                <caption>Lista poziomów</caption>
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
                                <th scope="row"><asp:Label ID="lblModelID" runat="server" Text='<%# Eval("TierID") %>'></asp:Label></th>
                                <td><%# Eval("TierName") %></td>
                                <td><%# Eval("ClassName") %></td>
                                <td>
                                    <button type="button" class="btn btn-sm btn-outline-warning rounded-pill">Edytuj</button>
                                    <asp:Button ID="btnTierDelete" CssClass="btn btn-sm btn-outline-danger rounded-pill" Text="Usuń" runat="server" OnClick="btnTierDelete_Click" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                </asp:Repeater>
                </div>
                <div class="tab-pane fade" id="nav-garages" role="tabpanel" aria-labelledby="nav-garages-tab">
                    <asp:Repeater ID="RepeaterGarages" runat="server">
                        <HeaderTemplate>
                            <table class="table table-hover table-sm caption-top">
                                <caption>Lista garażowania</caption>
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
                                <th scope="row"><asp:Label ID="lblModelID" runat="server" Text='<%# Eval("GarageID") %>'></asp:Label></th>
                                <td><%# Eval("GarageName") %></td>
                                <td>
                                    <button type="button" class="btn btn-sm btn-outline-warning rounded-pill">Edytuj</button>
                                    <asp:Button ID="btnGarageDelete" CssClass="btn btn-sm btn-outline-danger rounded-pill" Text="Usuń" runat="server" OnClick="btnGarageDelete_Click" />
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
        </div>
    </div>
</asp:Content>

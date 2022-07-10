<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralLayoutMaster.Master" AutoEventWireup="true" CodeBehind="CarView.aspx.cs" Inherits="BierzPanAuto.CarView" %>

<asp:Content ID="ContentCarView" ContentPlaceHolderID="ContentPlaceHolderGeneral" Runat="Server">
    <div class="container" style="padding-top: 30px;">
        <div class="card mb-3">
            <div class="row g-0">
            <div class="col-md-4">
                <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
                    <ol class="carousel-indicators">
                        <li data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active"></li>
                        <li data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1"></li>
                        <li data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2"></li>
                        <li data-bs-target="#carouselExampleIndicators" data-bs-slide-to="3"></li>
                        <li data-bs-target="#carouselExampleIndicators" data-bs-slide-to="4"></li>
                        <li data-bs-target="#carouselExampleIndicators" data-bs-slide-to="5"></li>
                    </ol>
                    <div class="carousel-inner">
                        <asp:Repeater ID="RepeaterImages" runat="server">
                            <ItemTemplate>
                                <div class="carousel-item <%# GetActiveClass(Container.ItemIndex) %>">
                                    <img class="img-fluid" src="img/CarImages/<%#Eval("CarID") %>/<%#Eval("ImageName") %><%#Eval("ImageExtention") %>" class="d-block w-100" alt="<%#Eval("ImageName") %>" onerror="this.src='img/no_image.png'"/>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </a>
                    <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </a>
                </div>
            </div>
            <div class="col-md-8">
                <asp:Repeater ID="RepeaterCar" OnItemDataBound="RepeaterCar_ItemDataBound" runat="server">
                    <ItemTemplate>
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Name") %></h5>
                            <p class="card-text"><span><%# Eval("Price") %></span><span> <%# Eval("SellPrice") %> </span><span> (10% + 50%)</span></p>
                            <hr />
                            <h5 class="card-title">Klasy</h5>
                            <asp:RadioButtonList ID="rbtnlstClass" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"></asp:RadioButtonList>
                            <hr />
                            <h5 class="card-title">Miejsce i rodzaj przechowywania</h5>
                            <p class="card-text"><span><%# Eval("Access") %></span><span> </span><span><%# Eval("GarageName") %></span></p>
                            <hr />
                            <asp:Button ID="btnAdd" runat="server" Text="Bierz samochód !" CssClass="btn btn-sm btn-warning" OnClick="btnAdd_Click" />
                            <hr />
                            <h5 class="card-title">Opis</h5>
                            <p class="card-text"><%# Eval("Description") %></p>
                            <hr />
                            <h5 class="card-title">Silnik</h5>
                            <p class="card-text"><span><%# Eval("Capacity") %></span><span> </span><span><%# Eval("EngineName") %></span><span> </span><span>Umiejscowiony: <%# Eval("EnginePosition") %></span></p></p>
                            <h5 class="card-title">Skrzynia biegów</h5>
                            <p class="card-text"><span><%# Eval("GearNumber") %>-biegowa</span><span> </span><span><%# Eval("GearboxName") %></span></p>
                            <h5 class="card-title">Napęd</h5>
                            <p class="card-text"><span>Napęd na <%# Eval("DriveName") %></p>
                            <h5 class="card-title">Kolor</h5>
                            <p class="card-text"><span><%# Eval("ColorName") %></span><span> </span><div style="background-color:<%#Eval("ColorPreview") %>; width: 128px; height: 32px;"></div>
                            <hr />
                            <h5 class="card-title">Detale / Wyposażenie</h5>
                            <p class="card-text"><%# Eval("Details") %></p>
                            <p class="card-text"><%#((int)Eval("FreeWeekend")==1)?"Darmowy weekend":"" %></p>
                            <p class="card-text"><%#((int)Eval("PledgetCar")==1)?"Samochód w zastaw":"" %></p>
                            <p class="card-text"><%#((int)Eval("LimitedDistance")==1)?"Ograniczony dystans":"" %></p>
                            <p class="card-text"><small class="text-muted">Aktualizacja: <span id="modify"></span></small></p>
                        </div>

                        <asp:HiddenField ID="hfModel" Value='<%# Eval("ModelID") %>' runat="server" />
                        <asp:HiddenField ID="hfGeneration" Value='<%# Eval("GenerationID") %>' runat="server" />
                        <asp:HiddenField ID="hfClass" Value='<%# Eval("ClassID") %>' runat="server" />
                        <asp:HiddenField ID="hfManufacturer" Value='<%# Eval("ManufacturerID") %>' runat="server" />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            </div>
        </div>
    </div>
    <script src="js/_custom.js"></script>
</asp:Content>

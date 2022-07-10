<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddCar.aspx.cs" Inherits="BierzPanAuto.AddCar" %>

<asp:Content ID="ContentAddCar" ContentPlaceHolderID="ContentPlaceHolderAdmin" Runat="Server">
    <div class="container">
        <h1>Dodaj samochód</h1>
        <hr />
        <div class="row g-3">
            <div class="col-12">
                <asp:Label ID="lblName" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Nazwa samochodu"></asp:Label>
                <asp:TextBox ID="txtbCarName" CssClass="form-control form-control-sm" runat="server" placeholder="Nazwa samochodu"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCarName" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="txtbCarName"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-6">
                <asp:Label ID="lblCarPrice" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Wartość samochodu [PLN]"></asp:Label>
                <asp:TextBox ID="txtbCarPrice" CssClass="form-control form-control-sm" runat="server" placeholder="Wartość samochodu"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCarPrice" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="txtbCarPrice"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-6">
                <asp:Label ID="lblCarSellPrice" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Cena wynajmu [PLN]"></asp:Label>
                <asp:TextBox ID="txtbCarSellPrice" CssClass="form-control form-control-sm" runat="server" placeholder="Cena sprzedaży"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCarSellPrice" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="txtbCarSellPrice"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-6">
                <asp:Label ID="lblCarManufacturer" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Marka samochodu"></asp:Label>
                <asp:DropDownList ID="ddlCarManufacturer" CssClass="form-select form-select-sm" runat="server" OnSelectedIndexChanged="ddlCarManufacturer_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCarManufacturer" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="ddlCarManufacturer" InitialValue="0"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-4">
                <asp:Label ID="lblCarModel" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Model samochodu"></asp:Label>
                <asp:DropDownList ID="ddlCarModel" CssClass="form-select form-select-sm" runat="server" OnSelectedIndexChanged="ddlCarModel_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCarModel" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="ddlCarModel" InitialValue="0"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-2">
                <asp:Label ID="lblCarGeneration" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Generacja"></asp:Label>
                <asp:DropDownList ID="ddlCarGeneration" CssClass="form-select form-select-sm" runat="server" OnSelectedIndexChanged="ddlCarGeneration_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCarGeneration" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="ddlCarGeneration" InitialValue="0"></asp:RequiredFieldValidator>
            </div>

            <div class="input-group mb-3">
                <asp:Label ID="lblCarClassTier" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Klasa i Poziom"></asp:Label>
                <asp:DropDownList ID="ddlCarClass" CssClass="form-select form-select-sm" runat="server" OnSelectedIndexChanged="ddlCarClass_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:CheckBoxList ID="chkclTier" runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList>
            </div>

            <div class="col-md-12">
                <asp:Label ID="lblQuantity" CssClass="col-md-2 col-form-label col-form-label-sm" runat="server" Text="Ilość"></asp:Label>
                <asp:TextBox ID="txtbQuantity" aria-label="Quantity" runat="server" CssClass="form-control form-control-sm" placeholder="Ilość"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ErrorMessage="To pole jest obowiązkowe !" CssClass="text-danger" ControlToValidate="txtbQuantity"></asp:RequiredFieldValidator>
            </div>

            <div class="input-group">
                <asp:Label ID="lblCarDescDetail" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Opis i Detale samochodu"></asp:Label>
                <asp:TextBox ID="txtbCarDesc" TextMode="MultiLine" aria-label="Description" runat="server" CssClass="form-control form-control-sm" placeholder="Opis samochodu"></asp:TextBox>
                <asp:TextBox ID="txtbCarDetail" TextMode="MultiLine" aria-label="Details" runat="server" CssClass="form-control form-control-sm" placeholder="Detale samochodu" aria-describedby="btnCarDetails"></asp:TextBox>
                <button class="btn btn-sm btn-outline-secondary" type="button" id="btnCarDetails" data-bs-toggle="modal" data-bs-target="#DetailsModal">Wybierz...</button>
            </div>

            <!-- Details Modal start -->
            <div class="modal fade" id="DetailsModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
	            <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
		            <div class="modal-content">
			            <div class="modal-header">
				            <h5 class="modal-title" id="exampleModalLabel">Dodatkowe wyposażenie</h5>
				            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
			            </div>
			            <div class="modal-body">
			                <asp:CheckBoxList ID="chkblDetails" runat="server"></asp:CheckBoxList>
			            </div>
			            <div class="modal-footer">
				            <asp:Button runat="server" CssClass="btn btn-secondary" data-bs-dismiss="modal" Text="Zamknij"></asp:Button>
				            <asp:Button ID="btnSaveDet" runat="server" CssClass="btn btn-primary" Text="Zapisz zmiany" OnClick="btnSaveDet_Click" CausesValidation="false"></asp:Button>
			            </div>
		            </div>
	            </div>
            </div>
            <!-- Details Modal start -->

            <div class="input-group">
                <asp:Label ID="lblAccessGarage" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Garażowanie i Dojazd"></asp:Label>
                <asp:TextBox ID="txtbAccess" TextMode="MultiLine" aria-label="Access" runat="server" CssClass="form-control form-control-sm" placeholder="Dojazd"></asp:TextBox>
                <asp:DropDownList ID="ddlGarage" CssClass="form-select form-select-sm" runat="server"></asp:DropDownList>
            </div>

            <div class="input-group mb-3">
                <asp:Label ID="lblEngine" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Silnik"></asp:Label>
                <asp:TextBox ID="txtbCapacity" aria-label="Capacity" runat="server" CssClass="form-control form-control-sm" placeholder="Pojemność[L]"></asp:TextBox>
                <asp:DropDownList ID="ddlEngineType" CssClass="form-select form-select-sm" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="ddlEnginePosition" CssClass="form-select form-select-sm" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvEngine" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="txtbCapacity"></asp:RequiredFieldValidator>
            </div>

            <div class="input-group mb-3">
                <asp:Label ID="lblGearbox" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Skrzynia biegów"></asp:Label>
                <asp:TextBox ID="txtbGears" aria-label="Gear Numbers" runat="server" CssClass="form-control form-control-sm" placeholder="Liczba biegów"></asp:TextBox>
                <asp:DropDownList ID="ddlGearbox" CssClass="form-select form-select-sm" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvGearbox" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="txtbGears"></asp:RequiredFieldValidator>
            </div>

            <div class="md-12">
                <asp:Label ID="lblDriveLabel" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Napęd"></asp:Label>
                <asp:DropDownList ID="ddlDrive" CssClass="form-select form-select-sm" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvDrive" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="ddlDrive" InitialValue="0"></asp:RequiredFieldValidator>
            </div>

            <div class="col-12">
                <asp:Label ID="lblCarPaint" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Lakier samochodu"></asp:Label>
                <asp:DropDownList ID="ddlPaint" CssClass="form-select form-select-sm" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvPaintName" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="ddlPaint" InitialValue="0"></asp:RequiredFieldValidator>
            </div>

            <%--PICTURES--%>
            <div class="col-md-4">
	            <asp:Label ID="lblCarImage01" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Załaduj obrazek 01"></asp:Label>
                <asp:FileUpload ID="fuCarImage01" runat="server" CssClass="form-control form-control-sm" />
                <asp:RequiredFieldValidator ID="rfvCarImage01" CssClass="text-danger" runat="server" ErrorMessage="Obrazek jest obowiązkowy !" ControlToValidate="fuCarImage01"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-4">
	            <asp:Label ID="lblCarImage02" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Załaduj obrazek 02"></asp:Label>
                <asp:FileUpload ID="fuCarImage02" runat="server" CssClass="form-control form-control-sm" />
                <asp:RequiredFieldValidator ID="rfvCarImage02" CssClass="text-danger" runat="server" ErrorMessage="Obrazek jest obowiązkowy !" ControlToValidate="fuCarImage02"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-4">
	            <asp:Label ID="lblCarImage03" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Załaduj obrazek 03"></asp:Label>
                <asp:FileUpload ID="fuCarImage03" runat="server" CssClass="form-control form-control-sm" />
                <asp:RequiredFieldValidator ID="rfvCarImage03" CssClass="text-danger" runat="server" ErrorMessage="Obrazek jest obowiązkowy !" ControlToValidate="fuCarImage03"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-4">
	            <asp:Label ID="lblCarImage04" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Załaduj obrazek 04"></asp:Label>
                <asp:FileUpload ID="fuCarImage04" runat="server" CssClass="form-control form-control-sm" />
                <asp:RequiredFieldValidator ID="rfvCarImage04" CssClass="text-danger" runat="server" ErrorMessage="Obrazek jest obowiązkowy !" ControlToValidate="fuCarImage04"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-4">
	            <asp:Label ID="lblCarImage05" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Załaduj obrazek 05"></asp:Label>
                <asp:FileUpload ID="fuCarImage05" runat="server" CssClass="form-control form-control-sm" />
                <asp:RequiredFieldValidator ID="rfvCarImage05" CssClass="text-danger" runat="server" ErrorMessage="Obrazek jest obowiązkowy !" ControlToValidate="fuCarImage05"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-4">
	            <asp:Label ID="lblCarImage06" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Załaduj obrazek 06"></asp:Label>
                <asp:FileUpload ID="fuCarImage06" runat="server" CssClass="form-control form-control-sm" />
                <asp:RequiredFieldValidator ID="rfvCarImage06" CssClass="text-danger" runat="server" ErrorMessage="Obrazek jest obowiązkowy !" ControlToValidate="fuCarImage06"></asp:RequiredFieldValidator>
            </div>

            <div class="form-check col-md-4">
                <asp:CheckBox ID="chkbFreeWeekend" runat="server" />
                <asp:Label ID="lblFreeWeekend" runat="server" CssClass="form-check-label" Text="Darmowy weekend"></asp:Label>
            </div>

            <div class="form-check col-md-4">
                <asp:CheckBox ID="chkbPledgetCar" runat="server" />
                <asp:Label ID="lblPledgetCar" runat="server" CssClass="form-check-label" Text="Samochód w zastaw"></asp:Label>
            </div>

            <div class="form-check col-md-4">
                <asp:CheckBox ID="chkbLimitedDistance" runat="server" />
                <asp:Label ID="lblLimitedDistance" runat="server" CssClass="form-check-label" Text="Ograniczony dystans"></asp:Label>
            </div>

            <div class="col-12">
                <asp:Button ID="btnAddCar" runat="server" CssClass="btn btn-sm btn-success" Text="Dodaj Samochód" OnClick="btnAddCar_Click" />
            </div>
        </div>
    </div>
</asp:Content>

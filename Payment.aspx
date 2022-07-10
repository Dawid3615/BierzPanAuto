<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralLayoutMaster.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="BierzPanAuto.Payment" %>

<asp:Content ID="ContentPayment" ContentPlaceHolderID="ContentPlaceHolderGeneral" Runat="Server">
    <asp:HiddenField ID="hfAmount" runat="server" />
    <asp:HiddenField ID="hfDiscount" runat="server" />
    <asp:HiddenField ID="hfTotalPayed" runat="server" />
    <asp:HiddenField ID="hfCarIDTierID" runat="server" />
    <div class="container">
        <div class="row"  style="padding-top: 30px;">
            <div class="col-md-9">
                <h1>Adres dostawy</h1>
                <hr />
                <div class="col-md-8">
                    <div class="col-md-7">
                        <asp:Label ID="lblName" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Nazwa"></asp:Label>
                        <asp:TextBox ID="txtbName" CssClass="form-control form-control-sm" runat="server" placeholder="Nazwa"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="txtbName"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col-md-7">
                        <asp:Label ID="lblAddress" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Adres"></asp:Label>
                        <asp:TextBox ID="txtbAddress" TextMode="MultiLine" CssClass="form-control form-control-sm" runat="server" placeholder="Adres"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddress" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="txtbAddress"></asp:RequiredFieldValidator>
                    </div>

                    <div class="col-md-7">
                        <asp:Label ID="lblZaipCode" runat="server" CssClass="col-md-2 col-form-label col-form-label-sm" Text="Kod pocztowy"></asp:Label>
                        <asp:TextBox ID="txtbZipCode" CssClass="form-control form-control-sm" runat="server" placeholder="Kod pocztowy"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvZipCode" CssClass="text-danger" runat="server" ErrorMessage="To pole jest obowiązkowe !" ControlToValidate="txtbZipCode"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="col-md-3 pt-5" runat="server" id="divPriceDetails">
                <h5 class="card-title">Szczególy cennika</h5>
                <div>
                    <label>Wypożyczenie całkowite</label>
                    <span class="float-end" id="spanRentTotal" style="color: gray;" runat="server"></span>
                </div>
                <div><span> </span></div>
                <div>
                    <label>Zniżka</label>
                    <span class="float-end" id="spanDisc" style="color: forestgreen;" runat="server"></span>
                </div>
                <hr />
                <div>
                    <div>
                        <label>Koszt całkowity</label>
                        <span class="float-end" id="spanTotal" runat="server"></span>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <h1>Wybierz metodę płatności</h1>
                <hr />
                <div class="table-responsive">
                    <nav>
                        <div class="nav nav-tabs" id="nav-tab" role="tablist">
                            <a class="nav-link" id="nav-cash-tab" data-bs-toggle="tab" href="#nav-cash" role="tab" aria-controls="nav-cash" aria-selected="true">Gotówka</a>
                            <a class="nav-link" id="nav-cashdel-tab" data-bs-toggle="tab" href="#nav-cashdel" role="tab" aria-controls="nav-cashdel" aria-selected="true">Gotówka przy odbiorze</a>
                            <a class="nav-link active" id="nav-cdcard-tab" data-bs-toggle="tab" href="#nav-cdcard" role="tab" aria-controls="nav-cdcard" aria-selected="false">Karta kredytowa / debetowa</a>
                            <a class="nav-link" id="nav-blik-tab" data-bs-toggle="tab" href="#nav-blik" role="tab" aria-controls="nav-blik" aria-selected="false">Blik</a>
                        </div>
                    </nav>
                    <div class="tab-content" id="nav-tabContent">
                        <div class="tab-pane fade" id="nav-cash" role="tabpanel" aria-labelledby="nav-cash-tab">
                            <h3>Gotówka</h3>
                            <asp:Button ID="btnPayPal" CssClass="btn btn-sm btn-secondary" OnClick="btnPayPal_Click" runat="server" Text="Zapłać przy pomocy PayPal" />
                        </div>
                        <div class="tab-pane fade" id="nav-cashdel" role="tabpanel" aria-labelledby="nav-cashdel-tab">
                            <h3>Gotówka przy odbiorze</h3>
                        </div>
                        <div class="tab-pane fade show active" id="nav-cdcard" role="tabpanel" aria-labelledby="nav-cdcard-tab">
                            <h3>Karta kredytowa / debetowa</h3>
                        </div>
                        <div class="tab-pane fade" id="nav-blik" role="tabpanel" aria-labelledby="nav-blik-tab">
                            <h3>Blik</h3>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

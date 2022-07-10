<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralLayoutMaster.Master" AutoEventWireup="true" CodeBehind="Take.aspx.cs" Inherits="BierzPanAuto.Take" %>

<asp:Content ID="ContentTake" ContentPlaceHolderID="ContentPlaceHolderGeneral" Runat="Server">
    <div class="container">
        <div class="row"  style="padding-top: 30px;">
            <h1 runat="server" id="h1NoItems"></h1>
            <hr />
            <div class="col-md-9">
                <asp:Repeater ID="RepeaterTakeCars" runat="server">
                    <ItemTemplate>
                        <div class="col-md-9">
                            <div class="card mb-3">
                                <div class="row g-0">
                                    <div class="col-md-4">
                                        <a href="CarView.aspx?CarID=<%#Eval("CarID") %>" target="_blank">
                                            <img width="1000px" class="img-thumbnail" src="img/CarImages/<%#Eval("CarID") %>/<%#Eval("ImageName") %><%#Eval("ImageExtention") %>" alt="<%#Eval("ImageName") %>" onerror="this.src='img/no_image.png'" />
                                        </a>
                                    </div>
                                    <div class="col-md-8">
                                        <div class="card-body">
                                            <h5 class="card-title"><%#Eval("Name") %></h5>
                                            <p class="card-text" style="color: blue;">Poziom: <%#Eval("TierNamee") %></p>
                                            <span class="card-text" style="font-weight: bold;"><%#Eval("Price","{0:c}") %></span>
                                            <span class="card-text"><%#Eval("SellPrice","{0:0,00}") %></span>
                                            <asp:Button CommandArgument='<%#Eval("CarID") + "-" + Eval("TierIDD") %>' ID="btnRemoveItem" OnClick="btnRemoveItem_Click" CssClass="btn btn-sm btn-warning" Text="USUŃ" runat="server"/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
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
                <asp:Button ID="btnTakeItem" OnClick="btnTakeItem_Click" CssClass="btn btn-sm btn-success" Text="BIERZ AUTO" runat="server"/>
            </div>
        </div>
    </div>
</asp:Content>

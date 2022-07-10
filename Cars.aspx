<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralLayoutMaster.Master" AutoEventWireup="true" CodeBehind="Cars.aspx.cs" Inherits="BierzPanAuto.Cars" %>

<asp:Content ID="ContentCars" ContentPlaceHolderID="ContentPlaceHolderGeneral" Runat="Server">
    <div class="container" style="padding-top: 50px;">
        <div class="row row-cols-1 row-cols-md-4 g-4">
            <asp:Repeater ID="RepeaterCar" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <a href="CarView.aspx?CarID=<%#Eval("CarID") %>" style="text-decoration: none; color: black;">
                            <div class="card h-100" style="width: 18rem;">
                                <img class="img-thumbnail card-img-top" src="img/CarImages/<%#Eval("CarID") %>/<%#Eval("ImageName") %><%#Eval("ImageExtention") %>" class="card-img-top" alt="<%#Eval("Name") %>"/>
                                <div class="card-body">
                                    <h5 class="card-title CarName"><%#Eval("Name") %></h5>
                                    <%--<p class="card-text"><%#Eval("Description") %></p>--%>
                                </div>
                                <ul class="list-group list-group-flush">
                                    <li class="list-group-item"><span><%#Eval("Capacity") %>L </span><span><%#Eval("EngineName") %></span></li>
                                    <li class="list-group-item"><span><%#Eval("GearNumber") %>-biegowa </span><span><%#Eval("GearboxName") %></span></li>
                                    <li class="list-group-item">Napęd na <%#Eval("DriveName") %></li>
                                    <li class="list-group-item"><span><%# Eval("Price") %></span><span> <%# Eval("SellPrice") %> </span><span> (10% + 50%)</span></li>
                                </ul>
                                <div class="card-footer">
                                     
                                </div>
                            </div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <%--<nav aria-label="Page navigation example">
	            <ul class="pagination justify-content-center">
		            <li class="page-item disabled">
			            <a class="page-link" href="#" tabindex="-1" aria-disabled="true">Previous</a>
		            </li>
		            <li class="page-item"><a class="page-link" href="#">1</a></li>
		            <li class="page-item"><a class="page-link" href="#">2</a></li>
		            <li class="page-item"><a class="page-link" href="#">3</a></li>
		            <li class="page-item">
			            <a class="page-link" href="#">Next</a>
		            </li>
	            </ul>
            </nav>--%>
        </div>
    </div>
    <script src="js/_custom.js"></script>
</asp:Content>

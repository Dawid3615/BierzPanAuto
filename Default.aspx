<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralLayoutMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BierzPanAuto._Default" %>

<asp:Content ID="ContentDefault" ContentPlaceHolderID="ContentPlaceHolderGeneral" runat="server">
    <!-- Carousel start -->
    <div id="carouselDefaultWebsite" class="carousel slide carousel-fade" data-bs-ride="carousel">
        <ol class="carousel-indicators">
            <li data-bs-target="#carouselDefaultWebsite" data-bs-slide-to="0" class="active"></li>
            <li data-bs-target="#carouselDefaultWebsite" data-bs-slide-to="1"></li>
            <li data-bs-target="#carouselDefaultWebsite" data-bs-slide-to="2"></li>
        </ol>
        <div class="carousel-inner">
            <div class="carousel-item active data-bs-interval="2000"">
                <img src="img/carousel/01.png" class="d-block w-100" alt="01_carousel" />
                <div class="carousel-caption d-none d-md-block">
                    <h5>Koenigsegg One:1</h5>
                    <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
                    <p><a class="btn btn-lg btn-primary" href="SignIn.aspx" role="button">Dołącz do nas już dzisiaj</a></p>
                </div>
            </div>
            <div class="carousel-item data-bs-interval="2000"">
                <img src="img/carousel/02.png" class="d-block w-100" alt="02_carousel" />
                <div class="carousel-caption d-none d-md-block">
                    <h5>BMW M5 E39</h5>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                </div>
            </div>
            <div class="carousel-item data-bs-interval="2000"">
                <img src="img/carousel/03.png" class="d-block w-100" alt="03_carousel" />
                <div class="carousel-caption d-none d-md-block">
                    <h5>Dodge Challenger R/T</h5>
                    <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
                </div>
            </div>
        </div>
        <a class="carousel-control-prev" href="#carouselDefaultWebsite" role="button" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </a>
        <a class="carousel-control-next" href="#carouselDefaultWebsite" role="button" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </a>
    </div>
    <!-- Carousel end -->
    <br />
    <br />
    <!-- Content start -->
    <div class="container default-page-center">
        <div class="row">
            <div class="col-lg-4">
                <img class="img-fluid rounded rounded-circle" src="img/CAR_CLASS_EXOTIC.png" alt="car_class_exotic" width="140" height="140" />
                <h2>Klasa egzotyczna</h2>
                <p>Najbardziej wydajne pojazdy, ale najtrudniejsze do opanowania.</p>
                <p><a class="btn btn-outline-secondary" href="#" role="button">Zobacz &raquo;</a></p>
            </div>
            <div class="col-lg-4">
                <img class="img-fluid rounded rounded-circle" src="img/CAR_CLASS_MUSCLE.png" alt="car_class_muscle" width="140" height="140" />
                <h2>Klasa muscle</h2>
                <p>Najszybciej przyspieszające pojazdy kosztem maksymalnej prędkości i prowadzenia.</p>
                <p><a class="btn btn-outline-secondary" href="#" role="button">Zobacz &raquo;</a></p>
            </div>
            <div class="col-lg-4">
                <img class="img-fluid rounded rounded-circle" src="img/CAR_CLASS_TUNER.png" alt="car_class_tuner" width="140" height="140" />
                <h2>Klasa tuningowa</h2>
                <p>Najbardziej responsywne prowadzenie i najwyższa przyczepność kosztem maksymalnej prędkości.</p>
                <p><a class="btn btn-outline-secondary" href="#" role="button">Zobacz &raquo;</a></p>
            </div>
        </div>
    </div>
    <!-- Content end -->
</asp:Content>

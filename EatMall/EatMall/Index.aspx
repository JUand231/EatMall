<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EatMall.Index" MasterPageFile="~/Vista/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body, html { height: 100%; }
        .hero-image {
            background-image: linear-gradient(rgba(0,0,0,0.5), rgba(0,0,0,0.5)), url("Vista/Assets/Img/HeroPlazoleta.png");
            height: 60vh;
            background-position: center;
            background-repeat: no-repeat;
            background-size: cover;
            position: relative;
            width: 100%;
            border-radius: 12px;
        }
        .hero-text {
            position: absolute;
            top: 50%;
            left: 2rem;
            transform: translateY(-50%);
            color: white;
        }
        .card { border-radius: 12px; overflow: hidden; width: 100%; }
        .card img { border-radius: 10px; }
        .card-body h5 { font-size: 16px; }
        .btn-custom {
            background-color: #e7c7a5;
            color: #000;
            border-radius: 10px;
            font-weight: 500;
        }
        .btn-custom:hover { opacity: 0.9; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">

        <!-- HERO -->
        <div class="hero-image mb-5">
            <div class="hero-text">
                <h1>EatMall</h1>
                <p>Administra locales, controla ocupación y optimiza el servicio en tiempo real</p>
                <button class="btn btn-light btn-lg px-4 py-2">Explorar ahora</button>
            </div>
        </div>

        <!-- TITULO -->
        <h4 class="mb-4">Centros Comerciales</h4>

        <!-- LISTADO -->
        <div class="row">
            <asp:Repeater ID="rptCentrosComerciales" runat="server">
                <ItemTemplate>
                    <div class="col-lg-3 col-md-6 mb-4">
                        <div class="card shadow-sm p-3 h-100 position-relative">
                            <img src='<%# Eval("Imagen") %>'
                                 class="card-img-top"
                                 style="height:150px; object-fit:cover;"
                                 onerror="this.src='Vista/Assets/Img/CCDefault.png'" />
                            <div class="card-body text-start">
                                <h5 class="fw-bold"><%# Eval("Nombre") %></h5>
                                <p class="text-muted mb-1">
                                    <i class="bi bi-geo-alt-fill"></i>
                                    <%# Eval("Ciudad.NombreCiudad") %> - 
                                    <%# Eval("Ciudad.Departamento.Nombre") %>
                                </p>
                                <p class="small text-secondary"><%# Eval("Ubicacion") %></p>
                                <a href='Vista/Plazoleta/Plazoleta.aspx?id=<%# Eval("Id") %>' class="btn btn-custom w-100 mt-2">
                                    Ver Detalles
                                </a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </div>

</asp:Content>
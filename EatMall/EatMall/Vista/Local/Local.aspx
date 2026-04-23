<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Local.aspx.cs" Inherits="EatMall.Vista.Pago.Local" %>

<!DOCTYPE html>
<html>
<head>
    <title>Locales</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

    <style>
        body {
            background-color: #f0f2f5;
            font-family: 'Segoe UI', sans-serif;
        }

        .local-card {
            background: white;
            border-radius: 16px;
            padding: 24px 16px;
            text-align: center;
            box-shadow: 0 2px 8px rgba(0,0,0,0.07);
            transition: transform 0.2s ease, box-shadow 0.2s ease;
            height: 100%;
            position: relative;
        }

        .local-card:hover {
            transform: translateY(-4px);
            box-shadow: 0 6px 18px rgba(0,0,0,0.12);
        }

        .local-icono {
            width: 90px;
            height: 90px;
            border-radius: 50%;
            object-fit: cover;
            border: 3px solid #e0e0e0;
        }

        .local-nombre {
            font-size: 1rem;
            font-weight: 700;
            color: #1a1a1a;
            margin-top: 12px;
            margin-bottom: 8px;
        }

        .btn-ver-menu {
            background-color: #c0392b;
            color: white;
            border: none;
            border-radius: 8px;
            width: 100%;
            padding: 10px;
            font-weight: 600;
            margin-top: 16px;
            transition: background 0.2s;
        }

        .btn-ver-menu:hover {
            background-color: #a93226;
            color: white;
        }

        .btn-cerrado {
            background-color: #e5e7eb;
            color: #9ca3af;
            border: none;
            border-radius: 8px;
            width: 100%;
            padding: 10px;
            font-weight: 600;
            margin-top: 16px;
            cursor: not-allowed;
        }

        .page-title {
            font-size: 2rem;
            font-weight: 800;
            color: #1a1a1a;
        }

        .page-subtitle {
            color: #6b7280;
            margin-bottom: 32px;
        }

        .local-wrapper {
            position: relative;
            width: 90px;
            margin: 0 auto;
        }

        .estado-local {
            width: 16px;
            height: 16px;
            border-radius: 50%;
            position: absolute;
            bottom: 4px;
            right: 4px;
            border: 2px solid white;
        }

        .abierto {
            background-color: #28a745;
        }

        .cerrado {
            background-color: #dc3545;
        }

        .calificacion {
            position: absolute;
            top: 10px;
            left: 12px;
            color: #f59e0b;
            font-size: 0.85rem;
            font-weight: 600;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="container py-5">

            <!-- Botón volver -->
            <div class="mb-2">
                <asp:HyperLink ID="btnVolverPlazoleta"
                    runat="server"
                    Text="← Volver"
                    CssClass="btn btn-outline-dark btn-sm" />
            </div>

            <h2 class="page-title mt-3">Locales Disponibles</h2>
            <p class="page-subtitle">
                Explora los locales disponibles en esta plazoleta.
            </p>

            <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-4">
                <asp:Repeater ID="rptLocales" runat="server">
                    <ItemTemplate>

                        <div class="col">
                            <div class="local-card">

                                <!-- Calificación -->
                                <div class="calificacion">
                                    ★ <%# string.Format("{0:0.0}", Eval("Promedio")) %>
                                </div>

                                <div class="local-wrapper">

                                    <asp:Image ID="imgLocal"
                                        runat="server"
                                        ImageUrl='<%# string.IsNullOrEmpty(Eval("Imagen").ToString()) ? "~/img/default-local.png" : Eval("Imagen").ToString() %>'
                                        CssClass="local-icono"
                                        AlternateText='<%# Eval("Nombre") %>' />

                                    <!-- Estado -->
                                    <span class='estado-local <%# Eval("Estado").ToString() == "Abierto" ? "abierto" : "cerrado" %>'
                                        title='<%# Eval("Estado") %>'>
                                    </span>

                                </div>

                                <p class="local-nombre">
                                    <%# Eval("Nombre") %>
                                </p>

                                <!-- Botón -->
                                <%# Eval("Estado").ToString() == "Abierto"
                                    ? "<a href='/Vista/Local/Tienda.aspx?idLocal=" + Eval("Id") +
                                      "&idPlazoleta=" + Request.QueryString["idPlazoleta"] +
                                      "&idCC=" + Request.QueryString["idCC"] +
                                      "' class='btn-ver-menu d-block text-decoration-none text-center'>Ver Menú</a>"
                                    : "<button class='btn-cerrado' disabled>Cerrado</button>" %>

                            </div>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <asp:Label ID="lblMensaje"
                runat="server"
                CssClass="mt-3 d-block alert alert-warning"
                Visible="false" />

        </div>
    </form>
</body>
</html>
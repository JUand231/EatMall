<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Local.aspx.cs" Inherits="EatMall.Vista.Pago.Local" %>

<!DOCTYPE html>
<html>
<head>
    <title>Locales</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body { background-color: #f0f2f5; font-family: 'Segoe UI', sans-serif; }

        .local-icono {
            width: 80px;
            height: 80px;
            border-radius: 50%;
            object-fit: cover;
            border: 3px solid #e0e0e0;
        }

        .local-icono-default {
            width: 80px;
            height: 80px;
            border-radius: 50%;
            background-color: #0d6efd;
            display: flex;
            align-items: center;
            justify-content: center;
            color: white;
            font-size: 1.8rem;
            font-weight: bold;
            margin: 0 auto;
        }

        .local-card {
            cursor: pointer;
            transition: transform 0.2s ease;
            text-align: center;
        }

        .local-card:hover { transform: translateY(-4px); }

        .local-nombre {
            font-size: 0.85rem;
            font-weight: 600;
            color: #1a1a2e;
            margin-top: 8px;
            word-break: break-word;
        }

        .header-locales {
            background: linear-gradient(135deg, #0d6efd, #6610f2);
            color: white;
            border-radius: 20px;
            padding: 30px;
            margin-bottom: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container py-5">

            <div class="header-locales text-center">
                <h2 class="fw-bold mb-0">Locales</h2>
                <p class="mb-0 opacity-75">Selecciona un local</p>
            </div>

            <div class="row row-cols-3 row-cols-sm-4 row-cols-md-6 g-4">
                <asp:Repeater ID="rptLocales" runat="server">
                    <ItemTemplate>
                        <div class="col">
                            <div class="local-card" onclick="window.location='/Vista/Tienda.aspx?idLocal=<%# Eval("Id") %>'">
                                <asp:Image ID="imgLocal" runat="server"
                                    ImageUrl='<%# string.IsNullOrEmpty(Eval("Imagen").ToString()) ? "~/img/default-local.png" : Eval("Imagen").ToString() %>'
                                    CssClass="local-icono"
                                    AlternateText='<%# Eval("Nombre") %>' />
                                <p class="local-nombre"><%# Eval("Nombre") %></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3 d-block alert alert-warning" Visible="false" />

        </div>
    </form>
</body>
</html>
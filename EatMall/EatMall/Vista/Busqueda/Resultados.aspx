<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resultados.aspx.cs" Inherits="EatMall.Vista.Busqueda.Resultados" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Resultados de búsqueda</title>
    <style>
        * { box-sizing: border-box; margin: 0; padding: 0; }

        body {
            font-family: 'Segoe UI', sans-serif;
            background-color: #f5f5f5;
            color: #333;
            padding: 30px;
        }

        h2 {
            font-size: 22px;
            color: #444;
            margin-bottom: 20px;
            border-left: 4px solid #e84040;
            padding-left: 12px;
        }

        .seccion {
            margin-bottom: 40px;
        }

        .grid {
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
        }

        .card {
            background: #fff;
            border-radius: 12px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.08);
            width: 220px;
            overflow: hidden;
            transition: transform 0.2s, box-shadow 0.2s;
        }

        .card:hover {
            transform: translateY(-4px);
            box-shadow: 0 6px 20px rgba(0,0,0,0.12);
        }

        .card img {
            width: 100%;
            height: 150px;
            object-fit: cover;
        }

        .card-body {
            padding: 14px;
        }

        .card-body strong {
            font-size: 16px;
            display: block;
            margin-bottom: 6px;
            color: #222;
        }

        .card-body span {
            font-size: 13px;
            color: #666;
            display: block;
            margin-bottom: 8px;
        }

        .card-meta {
            font-size: 12px;
            color: #999;
            margin-top: 6px;
        }

        .badge {
            display: inline-block;
            background-color: #e8f5e9;
            color: #2e7d32;
            font-size: 11px;
            padding: 3px 8px;
            border-radius: 20px;
            margin-top: 6px;
        }

        .precio {
            font-size: 15px;
            font-weight: bold;
            color: #e84040;
            margin-top: 8px;
        }

        .sin-resultados {
            color: #aaa;
            font-style: italic;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="seccion">
            <h2>🏪 Locales encontrados</h2>
            <div class="grid">
                <asp:Repeater ID="rptLocales" runat="server">
                    <ItemTemplate>
                        <div class="card">
                            <img src='<%# Eval("Imagen") %>' alt="Local" onerror="this.src='https://via.placeholder.com/220x150?text=Sin+imagen'" />
                            <div class="card-body">
                                <strong><%# Eval("Nombre") %></strong>
                                <span><%# Eval("Descripcion") %></span>
                                <div class="card-meta">📍 <%# Eval("Plazoleta") %> — <%# Eval("CentroComercial") %></div>
                                <span class="badge"><%# Eval("Estado") %></span>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

        <div class="seccion">
            <h2>🍽️ Productos encontrados</h2>
            <div class="grid">
                <asp:Repeater ID="rptProductos" runat="server">
                    <ItemTemplate>
                        <div class="card">
                            <img src='<%# Eval("Imagen") %>' alt="Producto" onerror="this.src='https://via.placeholder.com/220x150?text=Sin+imagen'" />
                            <div class="card-body">
                                <strong><%# Eval("Nombre") %></strong>
                                <span><%# Eval("Descripcion") %></span>
                                <div class="precio">$<%# Eval("Precio", "{0:N2}") %></div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="seccion">
    <h2>🏬 Centros Comerciales por ciudad</h2>
    <div class="grid">
        <asp:Repeater ID="rptCentros" runat="server">
            <ItemTemplate>
                <div class="card">
                    <img src='<%# Eval("Imagen") %>' alt="Centro Comercial" onerror="this.src='https://via.placeholder.com/220x150?text=Sin+imagen'" />
                    <div class="card-body">
                        <strong><%# Eval("Nombre") %></strong>
                        <span><%# Eval("Descripcion") %></span>
                        <div class="card-meta">📍 <%# Eval("Direccion") %></div>
                        <div class="card-meta">🏙️ <%# Eval("Ciudad") %></div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>

    </form>
</body>
</html>
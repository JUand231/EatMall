<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Plazoletas.aspx.cs" Inherits="EatMall.Vista.Plazoletas" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.css" />

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Plazoletas</title>

</head>

<body>
    <form id="form1" runat="server">

        <!-- NAVBAR -->
        <nav class="navbar navbar-light bg-light shadow-sm">
            <div class="container">
                <a class="navbar-brand fw-bold" href="../Index.aspx">EatMall</a>
            </div>
        </nav>

        <div class="container mt-4">

            <div class="d-flex align-items-center mb-4">

                <asp:HyperLink ID="btnVolverIndex"
                    runat="server"
                    Text="← Volver"
                    CssClass="btn btn-outline-dark btn-sm me-3" />

                <h4 class="mb-0">Plazoletas</h4>

            </div>

            <div class="row">
                <asp:Repeater ID="rptPlazoletas" runat="server">
                    <ItemTemplate>

                        <div class="col-lg-3 col-md-4 col-sm-6 mb-4">
                            <div class="card shadow-sm p-2 h-100">

                                <img src='<%# Eval("Imagen") %>'
                                    class="card-img-top"
                                    style="height: 150px; object-fit: cover;"
                                    onerror="this.src='Vista/Assets/Img/CCDefault.png'" />

                                <div class="card-body d-flex flex-column">

                                    <h6 class="fw-bold"><%# Eval("Nombre") %></h6>

                                    <p class="small text-muted">
                                        <%# Eval("Descripcion") %>
                                    </p>
                                    <p class="small">
                                        <i class="bi bi-building"></i>
                                        <%# Eval("CentroComercial.Nombre") %>
                                    </p>

                                    <asp:Button ID="btnSeleccionar" runat="server"
                                        Text="Seleccionar"
                                        CssClass="btn btn-primary btn-sm w-100 mt-auto"
                                        CommandArgument='<%# Eval("Id") %>'
                                        OnClick="btnSeleccionar_Click" />

                                </div>

                            </div>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>
                <asp:Label ID="lblMensaje" runat="server" CssClass="text-center text-muted d-block mt-4"></asp:Label>
            </div>

        </div>

    </form>
</body>
</html>

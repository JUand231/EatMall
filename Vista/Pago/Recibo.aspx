<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="Recibo.aspx.cs" 
    Inherits="EatMall.Vista.Pago.Recibo" %>

<!DOCTYPE html>
<html>
<head>
    <title>Recibo de Pago</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <style>
        .recibo { border-radius: 15px; box-shadow: 0 0 20px rgba(0,0,0,0.1); max-width: 500px; margin: auto; }
        .check-icon { font-size: 60px; color: #198754; }
        .linea-punteada { border-top: 2px dashed #dee2e6; }
    </style>
</head>
<body>
<form id="form1" runat="server">
<div class="container mt-5">
    <div class="card recibo p-4">

        <div class="text-center mb-4">
            <div class="check-icon">✅</div>
            <h3 class="mt-2 text-success">¡Pago Exitoso!</h3>
            <p class="text-muted">Tu pedido ha sido confirmado</p>
        </div>

        <div class="linea-punteada mb-4"></div>

        <div class="mb-2 d-flex justify-content-between">
            <span class="text-muted">N° Transacción:</span>
            <asp:Label ID="lblIdTransaccion" runat="server" CssClass="fw-bold"/>
        </div>

        <div class="mb-2 d-flex justify-content-between">
            <span class="text-muted">Método de pago:</span>
            <asp:Label ID="lblMetodo" runat="server" CssClass="fw-bold"/>
        </div>

        <div class="mb-2 d-flex justify-content-between">
            <span class="text-muted">Fecha:</span>
            <asp:Label ID="lblFecha" runat="server" CssClass="fw-bold"/>
        </div>

        <div class="mb-2 d-flex justify-content-between">
            <span class="text-muted">Estado:</span>
            <asp:Label ID="lblEstado" runat="server" CssClass="fw-bold text-success"/>
        </div>

        <div class="linea-punteada my-3"></div>

        <div class="d-flex justify-content-between fs-5">
            <span class="fw-bold">Total pagado:</span>
            <asp:Label ID="lblTotal" runat="server" CssClass="fw-bold text-primary"/>
        </div>

        <div class="mt-4 text-center">
            <asp:Button ID="btnInicio" runat="server"
                Text="Volver al Inicio"
                CssClass="btn btn-primary"
                OnClick="btnInicio_Click"/>
        </div>

    </div>
</div>
</form>
</body>
</html>
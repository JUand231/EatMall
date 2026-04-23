<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="ConfirmacionPago.aspx.cs" 
    Inherits="EatMall.Vista.Pago.ConfirmacionPago" %>

<!DOCTYPE html>
<html>
<head>
    <title>Confirmación de Pago</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <style>
        .card-resumen { border-radius: 15px; box-shadow: 0 0 15px rgba(0,0,0,0.1); }
        .metodo-icon { width: 60px; height: auto; }
    </style>
</head>
<body>
<form id="form1" runat="server">
<div class="container mt-5">
    <div class="card card-resumen p-4">
        <h3 class="mb-4 text-center">Resumen de tu pedido</h3>

        <div class="mb-3">
            <h5>Método de pago seleccionado:</h5>
            <div class="d-flex align-items-center gap-3 mt-2">
                <asp:Image ID="imgMetodo" runat="server" CssClass="metodo-icon"/>
                <asp:Label ID="lblMetodo" runat="server" CssClass="fs-5 fw-bold"/>
            </div>
        </div>

        <hr/>

        <div class="mb-3">
            <h5>Total a pagar:</h5>
            <asp:Label ID="lblTotal" runat="server" CssClass="fs-3 fw-bold text-primary"/>
        </div>

        <div class="d-flex gap-3 mt-4">
            <asp:Button ID="btnConfirmar" runat="server"
                Text="Confirmar Pago"
                CssClass="btn btn-success btn-lg flex-grow-1"
                OnClick="btnConfirmar_Click"/>
            <asp:Button ID="btnCancelar" runat="server"
                Text="Cancelar"
                CssClass="btn btn-outline-danger btn-lg"
                OnClick="btnCancelar_Click"/>
        </div>
    </div>
</div>
</form>
</body>
</html>
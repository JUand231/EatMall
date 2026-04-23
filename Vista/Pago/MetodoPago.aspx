<<<<<<< HEAD
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MetodosPago.aspx.cs" Inherits="EatMall.Vista.Pago.MetodosPago" %>
=======
﻿<%@ Page Language="C#" AutoEventWireup="true"CodeBehind="MetodosPago.aspx.cs"Inherits="EatMall.Vista.Pago.MetodosPago" %>
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0

<!DOCTYPE html>
<html>
<head>
    <title>Métodos de Pago</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f0f2f5;
            font-family: 'Segoe UI', sans-serif;
        }

        .pago-card {
            border: 2px solid #e0e0e0;
            border-radius: 16px;
            transition: all 0.3s ease;
            cursor: pointer;
            background: white;
        }

<<<<<<< HEAD
            .pago-card:hover {
                border-color: #0d6efd;
                box-shadow: 0 4px 20px rgba(13,110,253,0.15);
                transform: translateY(-2px);
            }

            .pago-card.seleccionado {
                border-color: #0d6efd;
                background-color: #f0f6ff;
            }
=======
        .pago-card:hover {
            border-color: #0d6efd;
            box-shadow: 0 4px 20px rgba(13, 110, 253, 0.15);
            transform: translateY(-2px);
        }

        .pago-card.seleccionado {
            border-color: #0d6efd;
            background-color: #f0f6ff;
        }

        .icono-pago {
            font-size: 2rem;
            color: #0d6efd;
        }

        .titulo-seccion {
            color: #1a1a2e;
            font-weight: 700;
        }
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0

        .btn-continuar {
            border-radius: 12px;
            padding: 12px 40px;
            font-size: 1.1rem;
            font-weight: 600;
        }

        .header-pago {
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
        <div class="container py-5" style="max-width: 650px;">

<<<<<<< HEAD
=======
            <!-- Header -->
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
            <div class="header-pago text-center">
                <i class="bi bi-credit-card-2-front" style="font-size: 3rem;"></i>
                <h2 class="mt-2 mb-0 fw-bold">Métodos de Pago</h2>
                <p class="mb-0 opacity-75">Selecciona cómo quieres pagar tu pedido</p>
            </div>

<<<<<<< HEAD
            <!-- Campo oculto que guarda el Id seleccionado -->
            <asp:HiddenField ID="hfMetodoPago" runat="server" />

            <asp:Repeater ID="rptMetodos" runat="server">
                <ItemTemplate>
                    <div class="pago-card p-4 mb-3" data-id='<%# Eval("Id") %>' onclick="seleccionarMetodo(this)">
                        <div class="d-flex align-items-center gap-3">
=======
            <!-- Métodos de pago -->
            <asp:Repeater ID="rptMetodos" runat="server">
                <ItemTemplate>
                    <div class="pago-card p-4 mb-3" onclick="seleccionarMetodo(this, '<%# Eval("Id") %>')">
                        <div class="d-flex align-items-center gap-3">
                            
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
                            <div class="flex-grow-1">
                                <h5 class="mb-0 fw-semibold"><%# Eval("NombreMetodo") %></h5>
                                <small class="text-muted">Pago seguro y rápido</small>
                            </div>
                            <div>
<<<<<<< HEAD
                                <input type="radio" name="metodoPagoVisual"
=======
                                <input type="radio"
                                    name="metodoPago"
                                    value='<%# Eval("Id") %>'
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
                                    id='metodo_<%# Eval("Id") %>'
                                    class="form-check-input fs-5" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

<<<<<<< HEAD
=======
            <!-- Botón continuar -->
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
            <div class="d-grid mt-4">
                <asp:Button ID="btnContinuar" runat="server"
                    Text="Continuar con el pago →"
                    CssClass="btn btn-primary btn-continuar"
                    OnClick="btnContinuar_Click" />
            </div>

<<<<<<< HEAD
            <div class="text-center mt-3 text-muted">
                <i class="bi bi-shield-lock-fill text-success"></i>
                <small>Tus datos están protegidos con cifrado SSL</small>
=======
            <!-- Seguridad -->
            <div class="text-center mt-3 text-muted">
                <i class="bi bi-shield-lock-fill text-success"></i>
                <small> Tus datos están protegidos con cifrado SSL</small>
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0
            </div>

        </div>
    </form>

    <script>
<<<<<<< HEAD
        function seleccionarMetodo(card) {
            var id = card.getAttribute('data-id');
            document.querySelectorAll('.pago-card').forEach(c => c.classList.remove('seleccionado'));
            card.classList.add('seleccionado');
            document.getElementById('metodo_' + id).checked = true;
            document.getElementById('<%= hfMetodoPago.ClientID %>').value = id;
        }
</script>
</body>
</html>
=======
        function seleccionarMetodo(card, id) {
            document.querySelectorAll('.pago-card').forEach(c => c.classList.remove('seleccionado'));
            card.classList.add('seleccionado');
            document.getElementById('metodo_' + id).checked = true;
        }
    </script>
</body>
</html>
>>>>>>> 76119a2f89d22700a490fdef95ffddad2fc193c0

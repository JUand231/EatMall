<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EatMall.Vista.Auth.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.css" rel="stylesheet" />

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        body {
            min-height: 100vh;
            background: #dadada;
        }

        .login-card {
            background: #fff;
            border-radius: 12px;
            border: .5px solid rgba(0,0,0.12);
            padding: 2rem
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="d-flex justify-content-center align-items-center vh-100">
            <div class="container col-3 ">
                <div class="login-card ">
                    <div class="text-center mb-2">
                        <i class="bi bi-person-circle me-2" style="font-size: 3rem; color: #0d6efd;"></i>
                    </div>
                    <h1 class="d-flex justify-content-center">Iniciar Sesión</h1>
                    <div class="mb-3 mt-3">
                        <label for="email" class="form-label">Correo:</label>
                        <asp:TextBox ID="txtEmail" runat="server" Class="form-control" placeholder="Ingrese Correo" TextMode="Email"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="pwd" class="form-label">Contraseña:</label>
                        <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Ingrese Contraseña" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="check-group mb-3">
                        <label class="form-check-label">
                            <input class="form-check-input" type="checkbox" name="remember" />
                            Recúerdame
                        </label>
                        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                    </div>

                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" class="btn accordion-body btn-primary w-100 py-1" OnClick="btnIngresar_Click" />
                    <div class="mt-3">
                        <a href="#">¿Olvidaste tu contraseña?</a>
                    </div>
                </div>
            </div>
        </div>
        <div>
        </div>
    </form>
</body>
</html>
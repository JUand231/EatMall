<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carritos.aspx.cs"
    Inherits="EatMall.Vista.Pedido.Carritos" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .carrito-card {
            border-radius: 20px;
            box-shadow: 0 0 20px rgba(0,0,0,0.08);
        }

        .producto-row {
            border-radius: 12px;
            border: 1px solid #f0f0f0;
            transition: all 0.2s;
        }

            .producto-row:hover {
                box-shadow: 0 4px 15px rgba(0,0,0,0.08);
            }

        .total-card {
            border-radius: 20px;
            background-color: #f8f9fa;
            border: none;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 mb-5">
        <h3 class="fw-bold mb-4"><i class="bi bi-cart3 me-2"></i>Mi Carrito</h3>

        

        <li class="nav-item me-3">
            <asp:LinkButton ID="btnVolver" runat="server" PostBackUrl="~/Index.aspx" CssClass="text-decoration-none">
                <span class="fw-semibold">↩
                </span>
            </asp:LinkButton>
        </li>

        <div class="row">
            <!-- PRODUCTOS -->
            <div class="col-md-8">
                <div class="card carrito-card p-4">

                    <asp:Panel ID="pnlVacio" runat="server" Visible="false">
                        <div class="text-center py-5">
                            <i class="bi bi-cart-x" style="font-size: 4rem; color: #ccc;"></i>
                            <h5 class="text-muted mt-3">Tu carrito está vacío</h5>
                            <a href="/Index.aspx" class="btn btn-primary mt-3">Ver centros comerciales</a>
                        </div>
                    </asp:Panel>

                    <asp:Repeater ID="rptCarrito" runat="server" OnItemCommand="rptCarrito_ItemCommand">
                        <ItemTemplate>
                            <div class="producto-row p-3 mb-3">
                                <div class="d-flex justify-content-between align-items-center">
                                    <div>
                                        <h6 class="fw-bold mb-1"><%# Eval("Nombre") %></h6>
                                        <p class="text-muted mb-0 small">
                                            $<%# string.Format("{0:N2}", Eval("Precio")) %> x <%# Eval("Cantidad") %>
                                        </p>
                                    </div>
                                    <div class="d-flex align-items-center gap-3">
                                        <span class="fw-bold text-primary">$<%# string.Format("{0:N2}", Eval("Subtotal")) %>
                                        </span>
                                        <asp:LinkButton runat="server"
                                            CssClass="btn btn-outline-danger btn-sm"
                                            CommandName="Eliminar"
                                            CommandArgument='<%# Eval("Id") %>'>
                                        <i class="bi bi-trash"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>

            <!-- RESUMEN -->
            <div class="col-md-4">
                <div class="card total-card p-4">
                    <h5 class="fw-bold mb-4">Resumen del pedido</h5>

                    <div class="d-flex justify-content-between mb-2">
                        <span class="text-muted">Subtotal</span>
                        <span>$<asp:Label ID="lblSubtotal" runat="server" Text="0.00" /></span>
                    </div>

                    <hr />

                    <div class="d-flex justify-content-between mb-4">
                        <span class="fw-bold fs-5">Total</span>
                        <span class="fw-bold fs-5 text-primary">$<asp:Label ID="lblTotal" runat="server" Text="0.00" />
                        </span>
                    </div>

                    <asp:Button ID="btnConfirmar" runat="server"
                        Text="Confirmar pedido →"
                        CssClass="btn btn-success w-100 fw-bold"
                        OnClick="btnConfirmar_Click" />

                    <a href="/Index.aspx" class="btn btn-outline-secondary w-100 mt-2">Seguir comprando
                    </a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

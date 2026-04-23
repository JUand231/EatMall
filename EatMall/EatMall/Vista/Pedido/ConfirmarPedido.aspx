<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmarPedido.aspx.cs"
    Inherits="EatMall.Vista.Pedido.ConfirmarPedido" MasterPageFile="~/Site.Master"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container mt-4" style="max-width:600px">

    <h4>Confirmar Pedido</h4>
    <p class="text-muted">
        <small>Fecha: <asp:Label ID="lblFecha" runat="server"/></small>
    </p>

    <!-- RESUMEN DEL PEDIDO -->
    <div class="card mb-3">
        <div class="card-body">
            <h6 class="card-title">Resumen del pedido</h6>
            <asp:Repeater ID="rptResumen" runat="server">
                <HeaderTemplate>
                    <table class="table table-sm">
                        <thead><tr>
                            <th>Producto</th>
                            <th>Cant.</th>
                            <th>Precio</th>
                            <th>Subtotal</th>
                        </tr></thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Nombre") %></td>
                        <td><%# Eval("Cantidad") %></td>
                        <td>$<%# Eval("Precio", "{0:N2}") %></td>
                        <td>$<%# Eval("Subtotal", "{0:N2}") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

            <hr/>
            <h5 class="text-end">Total: $<asp:Label ID="lblTotal" runat="server"/></h5>
        </div>
    </div>

    <!-- BOTONES -->
    <div class="d-flex gap-2">
        <asp:Button ID="btnVolver" runat="server" Text="← Volver"
            CssClass="btn btn-secondary"
            OnClick="btnVolver_Click"/>

        <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar Pedido ✓"
            CssClass="btn btn-success flex-grow-1"
            OnClick="btnConfirmar_Click"/>

        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"
            CssClass="btn btn-danger"
            OnClick="btnCancelar_Click"/>
    </div>

    <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3 d-block"/>

</div>
</asp:Content>
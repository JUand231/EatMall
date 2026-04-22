<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tienda.aspx.cs"
    Inherits="EatMall.Vista.Tienda" MasterPageFile="~/Vista/Site.Master"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="row">

            <!-- COLUMNA PRODUCTOS -->
            <div class="col-md-8">
                <div class="d-flex align-items-center mb-3">

                    <asp:HyperLink ID="btnVolverLocal"
                        runat="server"
                        Text="← Volver"
                        CssClass="btn btn-outline-dark btn-sm me-3" />

                    <h4 class="mb-0">Productos</h4>

                </div>
                <asp:Repeater ID="rptProductos" runat="server"
                    OnItemCommand="rptProductos_ItemCommand">
                    <ItemTemplate>
                        <div class="card d-inline-block m-2" style="width: 200px; vertical-align: top; min-height: 320px;">
                            <div class="card-body d-flex flex-column" style="min-height: 280px;">
                                <img src=<%# Eval("Imagen").ToString().StartsWith("http") ? Eval("Imagen").ToString() : ResolveUrl("~/" + Eval("Imagen").ToString()) %>

                                    alt='<%# Eval("Nombre") %>'
                                    style="width: 100%; height: 120px; object-fit: cover; border-radius: 8px; margin-bottom: 8px;"
                                    onerror="this.style.display='none'" />
                                <h6 class="card-title"><%# Eval("Nombre") %></h6>
                                <small class="flex-grow-1"><%# Eval("Descripcion") %></small>
                                <strong class="text-success">$<%# Eval("Precio", "{0:N2}") %></strong>
                                <div class="d-flex align-items-center mt-2">
                                    <asp:TextBox ID="txtCantidad" runat="server" Text="1"
                                        CssClass="form-control form-control-sm me-2"
                                        Style="width: 55px" TextMode="Number" min="1" />
                                    <asp:Button runat="server" Text="Agregar"
                                        CssClass="btn btn-primary btn-sm"
                                        CommandName="AgregarCarrito"
                                        CommandArgument='<%# Eval("Id") %>' />
      
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <!-- COLUMNA CARRITO -->
            <div class="col-md-4">
                <h4>🛒 Carrito</h4>
                <asp:Repeater ID="rptCarrito" runat="server"
                    OnItemCommand="rptCarrito_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-sm">
                            <thead>
                                <tr>
                                    <th>Producto</th>
                                    <th>Cant.</th>
                                    <th>Subtotal</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Nombre") %></td>
                            <td><%# Eval("Cantidad") %></td>
                            <td>$<%# Eval("Subtotal", "{0:N2}") %></td>
                            <td>
                                <asp:LinkButton ID="btnEliminar" runat="server"
                                    CssClass="btn btn-danger btn-sm"
                                    CommandName="Eliminar"
                                    CommandArgument='<%# Eval("Id") %>'>✕</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
          </table>
                    </FooterTemplate>
                </asp:Repeater>

                <h5>Total: $<asp:Label ID="lblTotal" runat="server" Text="0.00" /></h5>
                <asp:Button ID="btnIrConfirmar" runat="server" Text="Confirmar pedido →"
                    CssClass="btn btn-success w-100 mt-2"
                    OnClick="btnIrConfirmar_Click" />
            </div>

        </div>
    </div>
</asp:Content>

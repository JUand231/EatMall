<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tienda.aspx.cs"
    Inherits="EatMall.Vista.Local.Tienda" MasterPageFile="~/Site.Master"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">

        <div class="d-flex align-items-center justify-content-between mb-3">
            <div class="d-flex align-items-center">
                <asp:HyperLink ID="btnVolverLocal"
                    runat="server"
                    Text="← Volver"
                    CssClass="btn btn-outline-dark btn-sm me-3" />
                <h4 class="mb-0">Productos</h4>
            </div>
            <a href="/Vista/Pedido/Carritos.aspx" class="btn btn-warning fw-bold">
                <i class="bi bi-cart3 me-2"></i>Ver Carrito
            </a>
        </div>

        <div class="row">
            <asp:Repeater ID="rptProductos" runat="server"
                OnItemCommand="rptProductos_ItemCommand">
                <ItemTemplate>
                    <div class="col-md-3 d-inline-block m-2" style="vertical-align: top;">
                        <div class="card h-100 shadow-sm">
                            <img src='<%# Eval("Imagen").ToString().StartsWith("http") ? Eval("Imagen").ToString() : ResolveUrl("~/" + Eval("Imagen").ToString()) %>'
                                alt='<%# Eval("Nombre") %>'
                                style="width: 100%; height: 150px; object-fit: cover; border-radius: 8px 8px 0 0;"
                                onerror="this.style.display='none'" />
                            <div class="card-body d-flex flex-column">
                                <h6 class="card-title fw-bold"><%# Eval("Nombre") %></h6>
                                <small class="text-muted flex-grow-1"><%# Eval("Descripcion") %></small>
                                <strong class="text-success mt-2">$<%# Eval("Precio", "{0:N2}") %></strong>
                                <div class="d-flex align-items-center mt-2 gap-2">
                                    <asp:TextBox ID="txtCantidad" runat="server" Text="1"
                                        CssClass="form-control form-control-sm"
                                        Style="width: 55px" TextMode="Number" min="1" />
                                    <asp:Button runat="server" Text="Agregar"
                                        CssClass="btn btn-primary btn-sm"
                                        CommandName="AgregarCarrito"
                                        CommandArgument='<%# Eval("Id") %>' />
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </div>
</asp:Content>

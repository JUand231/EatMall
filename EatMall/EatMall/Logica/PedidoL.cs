using System;
using System.Collections.Generic;
using EatMall.Datos;
using EatMall.Modelo;

namespace EatMall.Logica
{
    public class PedidoL
    {
        public Pedido ConfirmarPedido(List<Carrito> carrito, int idCliente, string horaEntrega)
        {
            PedidoD pedidoD = new PedidoD();

            Pedido pedido = new Pedido
            {
                CodigoPedido = "PED-" + DateTime.Now.Ticks.ToString().Substring(10),
                FechaPedido = DateTime.Now,
                Estado = "Pendiente",
                Total = 0,
                TipoEntrega = "Local",
                IdCliente = idCliente,
                HoraEntrega = TimeSpan.Parse(horaEntrega)
            };

            foreach (var item in carrito)
                pedido.Total += item.Subtotal;

            pedido.Id = pedidoD.GuardarPedido(pedido); // ← guarda el Id

            foreach (var item in carrito)
            {
                DetallePedido detalle = new DetallePedido
                {
                    IdPedido = pedido.Id,
                    IdProducto = item.Id,
                    IdLocal = item.IdLocal,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = item.Precio,
                    Subtotal = item.Subtotal
                };
                pedidoD.GuardarDetalle(detalle);
            }

            return pedido; // ← retorna el pedido completo con CodigoPedido
        }
    }
}
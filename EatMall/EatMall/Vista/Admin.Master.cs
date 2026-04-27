using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EatMall.Datos;
using EatMall.Modelo;
using System.Linq;

namespace EatMall.Vista
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                UsuarioLogin oUsuario = (UsuarioLogin)Session["Usuario"];

                // Roles del 1 al 4 son funcionarios
                if (oUsuario.Rol >= 1 && oUsuario.Rol <= 4)
                {
                    string nombreRol = "";
                    switch (oUsuario.Rol)
                    {
                        case 1: nombreRol = "Administrador"; break;
                        case 2: nombreRol = "AdministradorCC"; break;
                        case 3: nombreRol = "Local"; break;
                        case 4: nombreRol = "Cajero"; break;
                    }
                    lblUsuario.Text = $"{oUsuario.Nombre} ({nombreRol})";

                    if (!IsPostBack)
                        CargarMenu(nombreRol);
                }
                else
                {
                    // El Rol 5 (Cliente) no entra aquí
                    Response.Redirect("~/Index.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Vista/Auth/Login.aspx");
            }
        }

        private void CargarMenu(string rol)
        {
            MenuD menuD = new MenuD();
            List<Modelo.Menu> menus = menuD.ObtenerMenuPorRol(rol);

            string html = "<ul class='nav flex-column'>";
            foreach (var item in menus.Where(m => m.IdPadre == null))
            {
                html += $"<li class='nav-item'><a class='nav-link text-white' href='{item.Ruta}'>{item.Nombre}</a></li>";

                // Hijos
                foreach (var hijo in menus.Where(m => m.IdPadre == item.Id))
                {
                    html += $"<li class='nav-item ps-3'><a class='nav-link text-white' href='{hijo.Ruta}'>— {hijo.Nombre}</a></li>";
                }
            }
            html += "</ul>";

            MenuRol.InnerHtml = html;
        }
        protected void lbCerrar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Vista/Auth/Login.aspx");
        }
    }

}


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="web_clinica.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <% if (Session["Usuario"] == null)
        { %>
    <div class="d-flex justify-content-center align-items-start pt-5">
        <div class="card shadow p-4" style="width: 22rem;">
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email"></asp:TextBox>
                <div id="emailHelp" class="form-text">No compartas tus credenciales.</div>
            </div>
            <div class="mb-3">
                <label for="exampleInputPassword1" class="form-label">Password</label>
                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <div class="mb-3 d-grid gap-2">
                <asp:Button runat="server" ID="btnIngresar" Text="Ingresar" CssClass="btn btn-primary w-100" OnClick="btnIngresar_Click" />
                <asp:Button runat="server" ID="btnRegistro" Text="Registro" CssClass="btn btn-outline-success w-100" OnClick="btnRegistro_Click" />
            </div>
        </div>
    </div>
    <%}
        else
        {  dominio.Usuario usuario = (dominio.Usuario)Session["Usuario"]; %>
    <div class="container my-5">
        <div class="row justify-content-center">
            <div class="col-md-6 col-lg-4">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h5 class="card-title">Bienvenido <%= usuario.Apellido %>, <%= usuario.Nombre %></h5>
                        <p class="card-text">
                            Bienvenidos a la aplicación web dedicada a gestionar los turnos de esta clínica médica. Desde su rol de <%= usuario.Tipo.ToString() %> tiene acceso a las siguientes funcionalidades:
         
                        </p>
                        <ul>
                            <li>Panel de perfil</li>
                            <li>Gestión de turnos</li>
                            <% 
                                if (usuario.Tipo == dominio.TipoUsuario.Recepcionista || usuario.Tipo == dominio.TipoUsuario.Administrador)
                                {
                            %>
                            <li>Administrar Médicos</li>
                            <li>Administrar Pacientes</li>
                            <% 
                                }
                            %>
                            <% 
                                if (usuario.Tipo == dominio.TipoUsuario.Administrador)
                                {
                            %>
                            <li>Gestión de Especialidades</li>
                            <li>Gestión de Obras Sociales</li>
                            <% 
                                }
                            %>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%} %>
                <div class="toast-container position-fixed bottom-0 end-0 p-5 mb-5">
                <asp:Panel ID="panelToast" runat="server" CssClass="toast align-items-center text-bg-success border-0" role="alert" aria-live="assertive" aria-atomic="true">
                    <div class="d-flex">
                        <div class="toast-body">
                            <asp:Label ID="lblToast" runat="server"></asp:Label>
                        </div>
                        <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
                    </div>
                </asp:Panel>
            </div>
</asp:Content>

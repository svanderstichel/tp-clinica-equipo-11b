<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="web_clinica.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
     body {
         position: relative; /*  posicionar el elemento */
         min-height: 25vh; /* Asegura que cubra al menos toda la ventana */
     }

         /* Crear la capa de fondo animada usando ::before */
         body::before {
             content: ''; /* Obligatorio para pseudo-elementos */
             position: fixed; /* Lo fija en el viewport */
             top: 0;
             left: 0;
             width: 100%;
             height: 100%;
             z-index: -1; /* Mueve la capa detrás de todo el contenido */
             /* Estilos del GIF y Opacidad */
             background-image: url('https://cdn.pixabay.com/photo/2023/12/29/03/10/ai-generated-8475432_640.jpg');
             background-repeat: no-repeat;
             background-position: center bottom;
             background-size: cover;
             opacity: 0.99;
         }

     /* Si la tabla oscura se ve afectada, le damos un fondo sólido */
     .table-dark {
         background-color: rgba(33, 37, 41, 0.9);
     }
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <% if (Session["Usuario"] == null)
        { %>
    <div class="d-flex justify-content-center align-items-start pt-5 mb-5">
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
            <div class="col-md-8 col-lg-6"> <div class="card shadow-lg border-primary border-3"> <div class="card-body p-5"> <h1 class="card-title text-primary mb-4 border-bottom pb-2">
                            👋 ¡Hola, <%= usuario.Nombre %>!
                        </h1>

                        <h4 class="card-subtitle mb-4 text-secondary">
                            <span class="badge bg-info text-dark me-2">
                                🏅 Rol: <%= usuario.Tipo.ToString() %>
                            </span>
                        </h4>

                        <p class="card-text lead"> Estamos encantados de tenerte en **C-Medic WebApp**. Como **<%= usuario.Tipo.ToString() %>**, tienes acceso a las siguientes funcionalidades.
                        </p>
                        
                        <h5 class="mt-4 mb-3 text-success">
                            🎯 Funcionalidades Disponibles:
                        </h5>
                        
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item d-flex align-items-center">
                                <span class="me-2 text-warning">⭐</span> Panel de perfil
                            </li>
                            <li class="list-group-item d-flex align-items-center">
                                <span class="me-2 text-primary">📅</span> Gestión de turnos
                            </li>
                            
                            <% if (usuario.Tipo == dominio.TipoUsuario.Recepcionista || usuario.Tipo == dominio.TipoUsuario.Administrador)
                                {
                            %>
                            <li class="list-group-item d-flex align-items-center">
                                <span class="me-2 text-info">🩺</span> Administrar Médicos
                            </li>
                            <li class="list-group-item d-flex align-items-center">
                                <span class="me-2 text-success">🧑‍🤝‍🧑</span> Administrar Pacientes
                            </li>
                            <% } %>
                            
                            <% if (usuario.Tipo == dominio.TipoUsuario.Administrador)
                                {
                            %>
                            <li class="list-group-item d-flex align-items-center">
                                <span class="me-2 text-danger">📝</span> Gestión de Especialidades
                            </li>
                            <li class="list-group-item d-flex align-items-center">
                                <span class="me-2 text-warning">🏥</span> Gestión de Obras Sociales
                            </li>
                            <% } %>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="web_clinica.Pacientes" %>

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
                background-image: url('https://cdn.pixabay.com/photo/2023/12/19/22/46/woman-8458561_640.jpg');
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

    <div class="row">
        <div class="col">
            <div class="w-100">
                <div class="container d-flex justify-content-center mt-5">
                    <div class="w-100">
                        <div class="py-4 mb-3 bg-dark text-light rounded shadow text-center">
                            <h2 class="fw-bold">Panel de pacientes 👥</h2>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <div class="mb-3">
                            <asp:Label Text="Filtrar" runat="server" />
                            <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
                        </div>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Estado" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control">
                            <asp:ListItem Text="Todos" />
                            <asp:ListItem Text="Activo" />
                            <asp:ListItem Text="Inactivo" />
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row">
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
                        </div>
                    </div>
                </div>

                <asp:GridView runat="server" ID="dgvPaciente" DataKeyNames="IdPaciente"
                    OnSelectedIndexChanged="dgvPaciente_SelectedIndexChanged"
                    OnPageIndexChanging="dgvPaciente_PageIndexChanging" AllowPaging="true" PageSize="10"
                    CssClass="table table-dark table-bordered" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                        <asp:BoundField HeaderText="Email" DataField="Email" />
                        <asp:BoundField HeaderText="DNI" DataField="DNI" />
                        <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                        <asp:BoundField HeaderText="Fecha de Naciemiento" DataField="FechaNacimiento" DataFormatString="{0:dd/MM/yyyy}"
                            HtmlEncode="false" />
                        <asp:BoundField HeaderText="Obra Social" DataField="ObraSocial.Nombre" />
                        <asp:BoundField HeaderText="Cobertura" DataField="ObraSocial.Cobertura" />
                        <asp:TemplateField HeaderText="Activo" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:CheckBox Enabled="false" Checked='<%# Eval("Estado") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:CheckBoxField HeaderText ="Estado" DataField="Estado" /> La baja lógica no esta implementada--%>
                        <asp:CommandField ShowSelectButton="true" SelectText="✍️" HeaderText="Accion" />
                    </Columns>
                                    <PagerTemplate>
                    <nav>
                        <nav>
                            <ul class="pagination justify-content-center mb-0">
                                <!-- validar si es la primera pagina: disabled -->
                                <li class='<%# ((GridView)Container.NamingContainer).PageIndex == 0 
                        ? "page-item disabled" 
                        : "page-item" %>'>
                                    <!-- boton anterior -->
                                    <asp:LinkButton
                                        runat="server"
                                        CommandName="Page"
                                        CommandArgument="Prev"
                                        CssClass="page-link bg-dark text-light border-secondary"> ◀
                                    </asp:LinkButton>
                                </li>

                                <!-- Indica página actual -->
                                <li class="page-item disabled">
                                    <span class="page-link bg-dark text-light border-secondary">
                                        <!-- pagina actual = index+1 / paginas totales -->
                                        <%# ((GridView)Container.NamingContainer).PageIndex + 1 %> /
                    <%# ((GridView)Container.NamingContainer).PageCount %>
                                    </span>
                                </li>

                                <!-- validar si es la última página: disabled -->
                                <li class='<%# ((GridView)Container.NamingContainer).PageIndex 
                        == ((GridView)Container.NamingContainer).PageCount - 1
                        ? "page-item disabled" 
                        : "page-item" %>'>

                                    <!-- boton siguiente -->
                                    <asp:LinkButton
                                        runat="server"
                                        CommandName="Page"
                                        CommandArgument="Next"
                                        CssClass="page-link bg-dark text-light border-secondary"> ▶
                                    </asp:LinkButton>
                                </li>
                            </ul>
                        </nav>
                </PagerTemplate>
                </asp:GridView>
                <div class="d-flex justify-content-between mt-3">
                    <div>
                        <asp:Button runat="server" ID="btnAgregarPaciente" Text="Agregar" CssClass="btn btn-primary me-2" OnClick="btnAgregarPaciente_Click" />
                        <asp:Button runat="server" ID="btnRegresar" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnRegresar_Click" />
                    </div>
                    <% if (Session["Usuario"] != null)
                        {
                            dominio.Usuario usuario = (dominio.Usuario)Session["Usuario"];
                            if (usuario.Tipo == dominio.TipoUsuario.Recepcionista || usuario.Tipo == dominio.TipoUsuario.Administrador)
                            { %>
                    <div>
                        <asp:Button runat="server" ID="btnObraSocial" Text="Administrar obras sociales" CssClass="btn btn-success" OnClick="btnObraSocial_Click" />
                    </div>
                    <% }
                        } %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

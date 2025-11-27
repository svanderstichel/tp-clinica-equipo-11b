<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearObraSocial.aspx.cs" Inherits="web_clinica.CrearObraSocial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            position: relative; /*  posicionar el elemento */
            min-height: 100vh; /* Asegura que cubra al menos toda la ventana */
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
                background-image: url('https://cdn.pixabay.com/photo/2024/09/05/00/03/ai-generated-9023090_640.jpg');
                background-repeat: no-repeat;
                background-position: center bottom;
                background-size: cover;
                opacity: 0.70;
            }

        /* Si la tabla oscura se ve afectada, le damos un fondo sólido */
        .table-dark {
            background-color: rgba(33, 37, 41, 0.9);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <hr />

    <div class="d-flex justify-content-center align-items-start pt-5">
        <div class="card shadow p-4" style="width: 22rem;">
            <h4 class="text-center mb-4">Agregar Obra Social</h4>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Ingrese el nombre"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control"
                    TextMode="MultiLine" Rows="4" placeholder="Ingrese una descripción..."></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtCobertura" class="form-label">Cobertura</label>
                <asp:TextBox runat="server" ID="txtCobertura" CssClass="form-control"
                    placeholder="Cobertura"></asp:TextBox>
            </div>

            <div class="mb-3 d-grid gap-2">
                <asp:Button runat="server" ID="btnGuardar" Text="Guardar" CssClass="btn btn-primary w-100" OnClick="btnGuardar_Click" />
            </div>

            <div class="mb-3 d-grid gap-2">
                <asp:Button runat="server" ID="btnInactivar" Text="Inactivar" CssClass="btn btn-danger" Visible="false" OnClick="btnInactivar_Click" />
                <asp:Button runat="server" ID="btnActivar" Text="Activar" CssClass="btn btn-success" Visible="false" OnClick="btnActivar_Click" />
            </div>

            <div class="mb-3 d-grid gap-2">
                <asp:Button runat="server" ID="Button1" Text="Cancelar" CssClass="btn btn-outline-secondary w-100" OnClick="btnCancelar_Click" />
            </div>
            <%--<div class="mb-3 d-grid gap-2">--%>
            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
            <%--<ContentTemplate>--%>
            <%--   <div class="mb-3 d-grid gap-2">
                            <asp:Button runat="server" ID="btnEliminar" OnClick="btnEliminar_Click" Text="Eliminar" CssClass="btn btn-danger" />
                        </div>--%>
            <%--                        <%if (ConfirmaEliminacion)
                            { %>
                        <div class="mb-3">
                            <asp:CheckBox Text="Confirmar Eliminacion" ID="chkConfirmarEliminacion" runat="server" />
                            <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="btnConfirmaEliminar_Click" CssClass="btn btn-outline-danger" runat="server" />
                        </div>--%>
            <%--<% } %>--%>
            <%--</ContentTemplate>--%>
            <%--</asp:UpdatePanel>--%>
            <%--</div>--%>
        </div>
    </div>


</asp:Content>



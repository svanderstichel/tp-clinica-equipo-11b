<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearPaciente.aspx.cs" Inherits="web_clinica.CrearPaciente" %>

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

    <div class="d-flex justify-content-center align-items-start pt-5">
    <div class="card shadow p-4" style="width: 40rem; background: rgba(255,255,255,0.95);">
        <h4 class="text-center mb-4">Agregar Paciente</h4>

        <div class="row">
            <!-- Columna izquierda -->
            <div class="col-md-6">

                <div class="mb-3">
                    <label class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ID="txbNombre" CssClass="form-control" placeholder="Ingrese el nombre"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Nombre es requerido" ControlToValidate="txbNombre" runat="server" />
                </div>

                <div class="mb-3">
                    <label class="form-label">Apellido</label>
                    <asp:TextBox runat="server" ID="txbApellido" CssClass="form-control" placeholder="Ingrese el Apellido"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Apellido es requerido" ControlToValidate="txbApellido" runat="server" />
                </div>

                <div class="mb-3">
                    <label class="form-label">DNI</label>
                    <asp:TextBox runat="server" ID="txbDNI" CssClass="form-control" placeholder="Ingrese el DNI"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El DNI es requerido" ControlToValidate="txbDNI" runat="server" />
                </div>

            </div>

            <!-- Columna derecha -->
            <div class="col-md-6">

                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox runat="server" ID="txbEmail" CssClass="form-control" placeholder="Ingrese el Email"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Email es requerido" ControlToValidate="txbEmail" runat="server" />
                </div>

                <div class="mb-3">
                    <label class="form-label">Teléfono</label>
                    <asp:TextBox runat="server" ID="txbTelefono" CssClass="form-control" placeholder="Ingrese el Teléfono"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Teléfono es requerido" ControlToValidate="txbTelefono" runat="server" />
                </div>

                <div class="mb-3">
                    <label class="form-label">Fecha de Nacimiento</label>
                    <asp:TextBox runat="server" TextMode="Date" ID="txtFechaNacimiento" CssClass="form-control" />
                    <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="La fecha es requerida" ControlToValidate="txtFechaNacimiento" runat="server" />
                </div>

            </div>
        </div>

        <!-- Obra Social y Cobertura - fila completa -->
        <div class="row mt-2">
            <div class="col-md-6">
                <label class="form-label">Obra Social</label>
                <asp:DropDownList ID="ddlObraSocial" CssClass="form-select" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlObraSocial_SelectedIndexChanged">
                </asp:DropDownList>
            </div>

            <div class="col-md-6">
                <label class="form-label">Cobertura</label>
                <asp:DropDownList ID="ddlCobertura" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
        </div>

        <!-- Botones -->
        <div class="mt-4 d-grid gap-2">
            <asp:Button runat="server" ID="btnInactivar" CssClass="btn btn-danger" Text="Inactivar" Visible="false" OnClick="btnInactivar_Click" />
            <asp:Button runat="server" ID="btnActivar" CssClass="btn btn-success" Text="Activar" Visible="false" OnClick="btnActivar_Click" />

            <asp:Button Text="Guardar" runat="server" ID="btnGuardar" CssClass="btn btn-primary w-100" OnClick="btnGuardar_Click" />
            <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" CssClass="btn btn-outline-secondary w-100" OnClick="btnCancelar_Click" CausesValidation="false" />
        </div>

    </div>
</div>


</asp:Content>

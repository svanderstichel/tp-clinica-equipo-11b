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
                background-image: url('https://media.istockphoto.com/id/2205410030/pt/foto/smiling-woman-using-cell-phone-while-waiting-for-doctors-appointment-at-the-clinic.jpg?s=612x612&w=0&k=20&c=kn4ez0mMVbxzjG4riqhiRRI5zhq5s3FDHA9_pZFSPFQ=');
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

    <hr />

    <div class="d-flex justify-content-center align-items-start pt-5">
        <div class="card shadow p-4" style="width: 22rem;">
            <h4 class="text-center mb-4">Agregar Paciente</h4>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txbNombre" CssClass="form-control" placeholder="Ingrese el nombre"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Nombre es requerido" ControlToValidate="txbNombre" runat="server" />
            </div>

            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox runat="server" ID="txbApellido" CssClass="form-control" placeholder="Ingrese el Apellido"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Apellido es requerido" ControlToValidate="txbApellido" runat="server" />
            </div>

            <div class="mb-3">
                <label for="txtDNI" class="form-label">DNI</label>
                <asp:TextBox runat="server" ID="txbDNI" CssClass="form-control" placeholder="Ingrese el DNI"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El DNI es requerido" ControlToValidate="txbDNI" runat="server" />
            </div>

            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txbEmail" CssClass="form-control" placeholder="Ingrese el Email"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Email es requerido" ControlToValidate="txbEmail" runat="server" />
            </div>

            <div class="mb-3">
                <label for="txtTelefono" class="form-label">Telefono</label>
                <asp:TextBox runat="server" ID="txbTelefono" CssClass="form-control" placeholder="Ingrese el Telefono"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Telefono es requerido" ControlToValidate="txbTelefono" runat="server" />
            </div>

            <div class="mb-3">
                <label for="txtFechaNacimiento" class="form-label">Fecha de Nacimiento</label>
                <asp:TextBox runat="server" TextMode="Date" ID="txtFechaNacimiento" CssClass="form-control" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El turno es requerido" ControlToValidate="txtFechaNacimiento" runat="server" InitialValue="0" />
            </div>

            <div class="mb-3">
                <label from="txtObraSocial" class="form-label">Obra Social</label>
                <asp:DropDownList ID="ddlObraSocial" CssClass="form-select" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlObraSocial_SelectedIndexChanged">
                </asp:DropDownList>
            </div>

            <div class="mb-3">
                <label from="txtCobertura" class="form-label">Cobertura</label>
                <asp:DropDownList ID="ddlCobertura" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

            <asp:Button runat="server" ID="btnInactivar" CssClass="btn btn-danger" Text="Inactivar" Visible="false" OnClick="btnInactivar_Click" />
            <asp:Button runat="server" ID="btnActivar" CssClass="btn btn-success" Text="Activar" Visible="false" OnClick="btnActivar_Click" />


            <div class="mb-3 d-grid gap-2">
                <asp:Button Text="Guardar" runat="server" ID="btnGuardar" CssClass="btn btn-primary w-100" OnClick="btnGuardar_Click" />
                <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" CssClass="btn btn-outline-secondary w-100" OnClick="btnCancelar_Click" CausesValidation="false" />
            </div>

<%--            <div class="mb-3 d-grid gap-2">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="mb-3 d-grid gap-2">
                            <asp:Button runat="server" ID="btnEliminarPaciente" OnClick="btnEliminarPaciente_Click" Text="Eliminar" CssClass="btn btn-danger" />
                        </div>
                        <%if (ConfirmaEliminacion)
                            { %>
                        <div class="mb-3">
                            <asp:CheckBox Text="Confirmar Eliminacion" ID="chkConfirmarEliminarPaciente" runat="server" />
                            <asp:Button Text="Eliminar" ID="btnConfirmaEliminarPaciente" OnClick="btnConfirmaEliminarPaciente_Click" CssClass="btn btn-outline-danger" runat="server" />
                        </div>
                        <% } %>
                    </ContentTemplate>
                </asp:UpdatePanel>--%>
            <%--</div>--%>
        </div>
    </div>

</asp:Content>

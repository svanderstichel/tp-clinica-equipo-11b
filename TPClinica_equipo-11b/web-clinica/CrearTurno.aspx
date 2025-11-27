<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearTurno.aspx.cs" Inherits="web_clinica.CrearTurno" %>

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
            background-image: url('https://cdn.pixabay.com/photo/2024/01/11/06/27/ai-generated-8500900_640.jpg');
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
    <div class="d-flex justify-content-center align-items-start pt-5">
        <div class="card shadow p-4" style="width: 50rem;">
            <fieldset>
                <legend class="text-center mb-4">Alta de turno</legend>

                <div class="row">
                    <div class="col-md-6 border-end">
                        <%-- DATOS DEL PACIENTE --%>

                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="mb-3">
                                    <label for="txtEmail" class="form-label">Email</label>
                                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
                                </div>

                                <div class="mb-3">
                                    <label for="txtApellido" class="form-label">Apellido</label>
                                    <asp:TextBox ID="txtApellido" CssClass="form-control readonly-textbox" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>

                                <div class="mb-3">
                                    <label for="txtNombre" class="form-label">Nombre</label>
                                    <asp:TextBox ID="txtNombre" CssClass="form-control readonly-textbox" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>

                                <div class="mb-3">
                                    <label for="txtDNI" class="form-label">DNI</label>
                                    <asp:TextBox ID="txtDNI" CssClass="form-control readonly-textbox" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>

                                <div class="mb-3">
                                    <label for="txtTelefono" class="form-label">Teléfono</label>
                                    <asp:TextBox ID="txtTelefono" CssClass="form-control readonly-textbox" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>

                                <div class="mb-3">
                                    <label for="txtFechaNacimiento" class="form-label">Fecha Nacimiento</label>
                                    <asp:TextBox ID="txtFechaNacimiento" CssClass="form-control readonly-textbox" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>

                                <div class="mb-3">
                                    <label for="txtObraSocial" class="form-label">Obra Social</label>
                                    <asp:TextBox ID="txtObraSocial" CssClass="form-control readonly-textbox" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                                </div>
                                <%-- TOAST PANEL --%>
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
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <%-- DATOS DEL MEDICO --%>
                        <div class="col-md-6">
                            <div class="mb-3">
                                <label for="ddlEspecialidad" class="form-label">Especialidad</label>
                                <asp:DropDownList ID="ddlEspecialidad" CssClass="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged"></asp:DropDownList>
                            </div>

                            <div class="mb-3">
                                <label for="ddlMedico" class="form-label">Médico</label>
                                <asp:DropDownList ID="ddlMedico" CssClass="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMedico_SelectedIndexChanged"></asp:DropDownList>
                            </div>

                            <div class="mb-3">
                                <label for="txtMatricula" class="form-label">Matrícula</label>
                                <asp:TextBox ID="txtMatricula" CssClass="form-control readonly-textbox" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>

                            <%-- DATOS DEL TURNO --%>
                            <div class="mb-3">
                                <label for="txtFechaTurno" class="form-label">Fecha</label>
                                <asp:TextBox ID="txtFechaTurno" runat="server" CssClass="form-control" TextMode="Date" AutoPostBack="true" OnTextChanged="txtFechaTurno_TextChanged"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <label for="ddlHora" class="form-label">Hora</label>
                                <asp:DropDownList ID="ddlHora" CssClass="form-select" runat="server" AutoPostBack="true"></asp:DropDownList>
                            </div>

                            <div class="mb-3">
                                <label for="txtObservaciones" class="form-label">Observaciones</label>
                                <asp:TextBox runat="server" ID="txtObservaciones" CssClass="form-control" TextMode="MultiLine" Rows="3" placeholder="Ingrese una descripción..."></asp:TextBox>
                            </div>

                            <div class="d-flex justify-content-end mt-4">
                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary w-100" OnClick="btnGuardar_Click" />
                            </div>
                            <div class="d-flex gap-2 mt-3">
                                <asp:Button ID="btnLimpiarSeleccion" runat="server" Text="Limpiar selección" CssClass="btn btn-secondary flex-fill" OnClick="btnLimpiarSeleccion_Click" />
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger flex-fill" OnClick="btnCancelar_Click" />
                            </div>

                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
</asp:Content>

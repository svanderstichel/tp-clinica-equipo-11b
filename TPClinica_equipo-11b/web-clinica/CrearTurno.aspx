<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearTurno.aspx.cs" Inherits="web_clinica.CrearTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center align-items-start pt-5">
        <div class="card shadow p-4" style="width: 50rem;">
            <fieldset>
                <legend class="text-center mb-4">Alta de turno</legend>

                <div class="row">
                    <div class="col-md-6 border-end">
                        <div class="mb-3">
                            <label for="ddlApellido" class="form-label">Apellido</label>
                            <asp:DropDownList ID="ddlApellido" CssClass="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlApellido_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                        <div class="mb-3">
                            <label for="ddlNombre" class="form-label">Nombre</label>
                            <asp:DropDownList ID="ddlNombre" CssClass="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNombre_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                        <div class="mb-3">
                            <label for="ddlEmail" class="form-label">Email</label>
                            <asp:DropDownList ID="ddlEmail" CssClass="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEmail_SelectedIndexChanged"></asp:DropDownList>
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

                    <div class="mb-3">
                    <label for="txtFechaTurno" class="form-label">Fecha</label>
                    <asp:TextBox ID="txtFechaTurno" runat="server" CssClass="form-control" TextMode="Date" AutoPostBack="true" OnTextChanged ="txtFechaTurno_TextChanged" ></asp:TextBox>
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
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary w-100" OnClick = "btnGuardar_Click" />
                        </div>
                        <div class="d-flex gap-2 mt-3">
                        <asp:Button ID="btnLimpiarSeleccion" runat="server" Text="Limpiar selección" CssClass="btn btn-secondary flex-fill" OnClick="btnLimpiarSeleccion_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger flex-fill" OnClick="btnCancelar_Click" />
                    </div>

                    </div>
                </div>
            </fieldset>
        </div>
    </div>
</asp:Content>

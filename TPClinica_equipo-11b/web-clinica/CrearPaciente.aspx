<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearPaciente.aspx.cs" Inherits="web_clinica.CrearPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <asp:DropDownList ID="ddlObraSocial" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3 d-grid gap-2">
                <asp:Button Text="Guardar" runat="server" ID="btnGuardar" CssClass="btn btn-primary w-100" OnClick="btnGuardar_Click" />
                <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" CssClass="btn btn-outline-secondary w-100" OnClick="btnCancelar_Click" CausesValidation="false" />
            </div>
        </div>
    </div>

</asp:Content>

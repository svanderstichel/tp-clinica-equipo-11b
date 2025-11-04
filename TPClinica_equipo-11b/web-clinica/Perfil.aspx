<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="web_clinica.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="d-flex justify-content-center align-items-center mt-5">
    <div class="card" style="width: 30rem;">
        <div class="card-body">
            <h4 class="card-title text-center mb-3">Bienvenido a su perfil</h4>
            <div class="input-group mb-3">
                <span class="input-group-text" id="basic-addon1">@</span>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" 
                    placeholder="correo@ejemplo.com" aria-label="Email" aria-describedby="basic-addon1" 
                    ReadOnly ="true" />
            </div>
            <div class="input-group mb-3">
                <span class="input-group-text">Nombre</span>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"
                    placeholder="Nombre" aria-label="Nombre" aria-describedby="inputGroup-sizing-default" />
            </div>
            <div class="input-group mb-3">
                <span class="input-group-text">Apellido</span>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"
                    placeholder="Apellido" aria-label="Apellido" aria-describedby="inputGroup-sizing-default" />
            </div>
            <div class="input-group mb-4">
                <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Seleccione rol..." Value="0" />
                    <asp:ListItem Text="Administrador" Value="1" />
                    <asp:ListItem Text="Recepcionista" Value="2" />
                    <asp:ListItem Text="Médico" Value="3" />
                    <asp:ListItem Text="Paciente" Value="4" />
                </asp:DropDownList>
            </div>
            <div class="d-flex justify-content-between">
                <asp:Button ID="btnPass" runat="server" Text="Cambiar contraseña" CssClass="btn btn-outline-danger" onclick ="btnPass_Click" />
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            </div>
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

        </div>
    </div>
    </div>

</asp:Content>

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
                <asp:TextBox ID="txtEmapil" runat="server" CssClass="form-control" 
                    placeholder="correo@ejemplo.com" aria-label="Email" aria-describedby="basic-addon1" />
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
            <div class="input-group mb-3">
                <span class="input-group-text">Email</span>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"
                    TextMode="Email" placeholder="correo@ejemplo.com" aria-label="Email" aria-describedby="inputGroup-sizing-default" />
            </div>
            <div class="input-group mb-4">
                <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Seleccione rol..." Value="" />
                    <asp:ListItem Text="Administrador" Value="Admin" />
                    <asp:ListItem Text="Recepcionista" Value="Recepcionista" />
                    <asp:ListItem Text="Médico" Value="Medico" />
                </asp:DropDownList>
            </div>
            <div class="d-flex justify-content-between">
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-outline-secondary" />
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
</div>

</asp:Content>

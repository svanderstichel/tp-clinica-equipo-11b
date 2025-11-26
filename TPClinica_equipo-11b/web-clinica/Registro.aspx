<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="web_clinica.Registro" %>

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
            background-image: url('https://media.istockphoto.com/id/2195046490/pt/foto/smiling-male-doctor-using-a-tablet-in-a-modern-office-environment.jpg?s=612x612&w=0&k=20&c=meIupnDc0qTSv7f4_7lq2PyAPc-XYmxf5Px-pEnKQfA=');
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
        <div class="card shadow p-4" style="width: 22rem;">
            <fieldset>
                <legend>Alta de usuario</legend>
                <div class="mb-3">
                    <label for="emailInput" class="form-label">Email</label>
                    <asp:TextBox ID="emailInput" CssClass="form-control" placeholder="ejemplo@gmail.com" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="nombreInput" class="form-label">Nombre</label>
                    <asp:TextBox ID="nombreInput" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="apellidoInput" class="form-label">Apellido</label>
                    <asp:TextBox ID="apellidoInput" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="disabledSelect" class="form-label">Rol</label>
                    <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Seleccione rol..." Value="0" />
                        <asp:ListItem Text="Administrador" Value="1" />
                        <asp:ListItem Text="Recepcionista" Value="2" />
                        <asp:ListItem Text="Médico" Value="3" />
                        <asp:ListItem Text="Paciente" Value="4" />
                    </asp:DropDownList>

                </div>
                <div class="mb-3">
                    <label for="passwordInput" class="form-label">Password</label>
                    <asp:TextBox runat="server" ID="inputPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div class="mb-3">
                </div>
                <asp:Button
                    ID="btnRegistrarse"
                    runat="server"
                    Text="Registrarse"
                    CssClass="btn btn-primary"
                    OnClick="btnRegistrarse_Click" />

            </fieldset>
        </div>
    </div>
</asp:Content>

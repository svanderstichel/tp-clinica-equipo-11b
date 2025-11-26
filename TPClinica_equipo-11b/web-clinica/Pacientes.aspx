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

    <div class="row">
        <div class="col">
            <div class="w-100">
                <h3 class="text-center mb-3">Lista de Pacientes</h3>
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
                        <asp:BoundField HeaderText="Fecha de Naciemiento" DataField="FechaNacimiento" />
                        <asp:BoundField HeaderText="Obra Social" DataField="ObraSocial.Nombre" />
                        <asp:BoundField HeaderText="Cobertura" DataField="ObraSocial.Cobertura" />
                        <%--<asp:CheckBoxField HeaderText ="Estado" DataField="Estado" /> La baja lógica no esta implementada--%>
                        <asp:CommandField ShowSelectButton="true" SelectText="✍️" HeaderText="Accion" />
                    </Columns>
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
                        <asp:Button runat="server" ID="btnObraSocial" Text="Administrar obras sociales" CssClass="btn btn-success" OnClick="btnObraSocial_Click"/>
                    </div>
                    <% }
                        } %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

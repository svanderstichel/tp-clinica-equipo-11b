<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="web_clinica.Pacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="web_clinica.Pacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <hr />

    <div class="row">
        <div class="col">
            <asp:GridView runat="server" ID="dgvPaciente" DataKeyNames="IdPaciente"
                OnSelectedIndexChanged="dgvPaciente_SelectedIndexChanged"
                OnPageIndexChanging="dgvPaciente_PageIndexChanging" AllowPaging="true" PageSize="5"
                CssClass="table table-dark table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField HeaderText="Email" DataField="Email" />
                    <asp:BoundField HeaderText="DNI" DataField="DNI" />
                    <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                    <asp:BoundField HeaderText="Fecha de Naciemiento" DataField="FechaNacimiento" />
                    <asp:BoundField HeaderText="Obra Social" DataField="ObraSocial.Nombre" />
                    <asp:CheckBoxField HeaderText ="Activo" DataField="Activo" />
                    <asp:CommandField ShowSelectButton="true" SelectText="✍️" HeaderText="Accion" />
                </Columns>
            </asp:GridView>
            <asp:Button runat="server" ID="btnAgregarPaciente" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregarPaciente_Click" />
            <asp:Button runat="server" ID="btnRegresar" Text="Volver" CssClass="btn btn-secondary" OnClick="btnRegresar_Click" />
        </div>
    </div>
</asp:Content>

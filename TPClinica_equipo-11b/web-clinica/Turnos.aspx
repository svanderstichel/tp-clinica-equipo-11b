<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="web_clinica.Turnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center mt-5">
            <div class="w-100">
        <h3 class="text-center mb-3">Lista de Turnos</h3>
        <asp:GridView ID="dgvTurnos" OnRowDeleting="dgvTurnos_RowDeleting" OnSelectedIndexChanged = "dgvTurnos_SelectedIndexChanged" DataKeyNames="Id" runat="server" CssClass="table table-dark table-bordered" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging ="dgvTurnos_PageIndexChanging" >
            <Columns>
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                <asp:BoundField DataField="Paciente" HeaderText="Paciente" />
                <asp:BoundField DataField="Medico" HeaderText="Médico" />
                <asp:BoundField DataField="FechaFormateada" HeaderText="Fecha" />
                <asp:BoundField DataField="HoraFormateada" HeaderText="Hora" />
                <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" />
                <asp:CommandField ShowSelectButton = "true" SelectText="✍️" ButtonType="Button" ControlStyle-CssClass="btn btn-outline-info" HeaderText="Modificar" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                <asp:CommandField ShowDeleteButton = "true" DeleteText="❌" ButtonType="Button" ControlStyle-CssClass="btn btn-outline-danger" HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
            </Columns>
        </asp:GridView>
    </div>
        </div>
    <div class="d-flex justify-content-end mt-3">
        <asp:Button ID="BtnCrearTurno" runat="server" Text="Solicitar turno" CssClass="btn btn-primary" OnClick="BtnCrearTurno_Click" />
    </div>
</asp:Content>

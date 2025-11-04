<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="web_clinica.Turnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center mt-5">
        <asp:GridView ID="dgvTurnos" runat="server" CssClass="table table-dark table-bordered" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                <asp:BoundField DataField="Paciente" HeaderText="Paciente" />
                <asp:BoundField DataField="Medico" HeaderText="Médico" />
                <asp:BoundField DataField="FechaFormateada" HeaderText="Fecha" />
                <asp:BoundField DataField="HoraFormateada" HeaderText="Hora" />
                <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearTrabajoTurno.aspx.cs" Inherits="web_clinica.CrearTrabajoTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <asp:HiddenField ID="hfIdTurnoTrabajo" runat="server" />

<hr />

<div class="d-flex justify-content-center align-items-start pt-3 mb-5">
    <div class="card shadow p-4" style="width: 22rem; max-width: 25rem; background-color: #EDEAD3">
        <h4 class="text-center mb-4, text-decoration-underline">Agregar Turno de Trabajo</h4>

        <div class="mb-3">
            <label for="txtHoraEntrada" class="form-label">Hora de Entrada</label>
            <asp:TextBox runat="server" ID="txtHoraEntrada" CssClass="form-control" TextMode="Time"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="La hora de entrada es requerida" ControlToValidate="txtHoraEntrada" runat="server" />
        </div>
        <div class="mb-3">
            <label for="txtHoraSalida" class="form-label">Hora de Salida</label>
            <asp:TextBox runat="server" ID="txtHoraSalida" CssClass="form-control" TextMode="Time"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="La hora de salida es requerida" ControlToValidate="txtHoraSalida" runat="server" />
        </div>
        
        <div class="mb-3">
            <label class="form-label">Días Laborales</label>
            <asp:CheckBoxList ID="cblDiasLaborales" runat="server" RepeatDirection="Vertical" RepeatColumns="2" CssClass="form-check-list">
                </asp:CheckBoxList>
            </div>

        <div class="mb-3 d-grid gap-2">
            <asp:Button Text="Guardar" runat="server" ID="btnGuardarTurno" CssClass="btn btn-primary w-100" OnClick="btnGuardarTurno_Click" />
            <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" CssClass="btn btn-outline-secondary w-100" onClick="btnCancelar_Click" CausesValidation="false" />
            </div>

        </div>
</div>

</asp:Content>

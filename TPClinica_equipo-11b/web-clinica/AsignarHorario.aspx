<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarHorario.aspx.cs" Inherits="web_clinica.AsignarHorario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center mt-4">
        <div class="card shadow-lg border-0" style="max-width: 550px; width: 100%;">
            <div class="card-body p-4">

                <h4 class="text-center mb-4">Modificar horario laboral</h4>

                <div class="mb-3">
                    <label class="form-label">Médico</label>
                    <asp:TextBox ID="txtMedico" runat="server" CssClass="form-control readonly-textbox" ReadOnly="true" />
                </div>

                <div class="mb-3">
                    <label class="form-label">Hora de entrada</label>
                    <asp:DropDownList ID="ddlHoraEntrada" runat="server" CssClass="form-select">
                        <asp:ListItem Text="07:00" Value="07:00" />
                        <asp:ListItem Text="08:00" Value="08:00" />
                        <asp:ListItem Text="09:00" Value="09:00" />
                        <asp:ListItem Text="10:00" Value="10:00" />
                        <asp:ListItem Text="11:00" Value="11:00" />
                        <asp:ListItem Text="12:00" Value="12:00" />
                        <asp:ListItem Text="13:00" Value="13:00" />
                        <asp:ListItem Text="14:00" Value="14:00" />
                        <asp:ListItem Text="15:00" Value="15:00" />
                        <asp:ListItem Text="16:00" Value="16:00" />
                        <asp:ListItem Text="17:00" Value="17:00" />
                        <asp:ListItem Text="18:00" Value="18:00" />
                    </asp:DropDownList>
                </div>

                <div class="mb-3">
                    <label class="form-label">Hora de salida</label>
                    <asp:DropDownList ID="ddlHoraSalida" runat="server" CssClass="form-select">
                        <asp:ListItem Text="07:00" Value="07:00" />
                        <asp:ListItem Text="08:00" Value="08:00" />
                        <asp:ListItem Text="09:00" Value="09:00" />
                        <asp:ListItem Text="10:00" Value="10:00" />
                        <asp:ListItem Text="11:00" Value="11:00" />
                        <asp:ListItem Text="12:00" Value="12:00" />
                        <asp:ListItem Text="13:00" Value="13:00" />
                        <asp:ListItem Text="14:00" Value="14:00" />
                        <asp:ListItem Text="15:00" Value="15:00" />
                        <asp:ListItem Text="16:00" Value="16:00" />
                        <asp:ListItem Text="17:00" Value="17:00" />
                        <asp:ListItem Text="18:00" Value="18:00" />
                    </asp:DropDownList>
                </div>
                <label class="form-label">Días laborales</label>

                <asp:CheckBoxList
                    ID="cboxDiasLaborales"
                    runat="server"
                    CssClass="checkbox-bootstrap d-flex flex-column gap-2 p-3 bg-light border rounded ms-2">
                    <asp:ListItem Value="1"> Lunes</asp:ListItem>
                    <asp:ListItem Value="2"> Martes</asp:ListItem>
                    <asp:ListItem Value="3"> Miércoles</asp:ListItem>
                    <asp:ListItem Value="4"> Jueves</asp:ListItem>
                    <asp:ListItem Value="5"> Viernes</asp:ListItem>
                </asp:CheckBoxList>
            </div>

            <div class="d-flex justify-content-end gap-3 mt-4 pt-3 pe-3 pb-3">
                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-outline-danger" Text="Cancelar" />
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" />
            </div>

        </div>
    </div>




</asp:Content>

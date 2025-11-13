<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="web_clinica.Medicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div class="row">
        <div class="col">
                        <div class="w-100">
        <h3 class="text-center mb-3">Lista de Médicos</h3>
            <asp:GridView runat="server" ID="dgvMedicos" CssClass="table table-dark table-bordered " AutoGenerateColumns="false"
                DataKeyNames="IdMedico" OnSelectedIndexChanged="dgvMedicos_SelectedIndexChanged1" OnPageIndexChanging="dgvMedicos_PageIndexChanging1"
                AllowPaging="true" PageSize="10">

                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField HeaderText="Matricula" DataField="Matricula" />
                    <asp:BoundField HeaderText="Email" DataField="Email" />
                    <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                    <%--<asp:BoundField HeaderText="IdTurnoTrabajo" DataField="TurnoTrabajo.IdTurnoTrabajo" />No esta implementada la logica de turnos de trabajo--%>
                    <%--<asp:CheckBoxField HeaderText="Estado Activo" DataField="Estado" />No esta implementada la lógica de reactivar--%>
                    <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✍️" />

                </Columns>


            </asp:GridView>
        </div>

           
<div class="d-flex justify-content-between mt-3">
                <div>
                    <asp:Button Text="Agregar" runat="server" ID="btnAgregarMedicos" CssClass="btn btn-primary me-2" OnClick="btnAgregarMedicos_Click" />
                    <asp:Button Text="Cancelar" runat="server" ID="btnRegresarMedicos" CssClass="btn btn-secondary" OnClick="btnRegresarMedicos_Click" />
                </div>

                <div>
                    <asp:Button Text="Administrar especialidades" runat="server" ID="btnEspecialidades"
                        CssClass="btn btn-success" OnClick ="btnEspecialidades_Click" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>

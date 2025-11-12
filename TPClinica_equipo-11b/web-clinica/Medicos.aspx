<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="web_clinica.Medicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div class="row">
        <div class="col">
            <h1>Lista de Medicos</h1>
            <asp:GridView runat="server" ID="dgvMedicos" CssClass="table table-dark table-bordered " AutoGenerateColumns="false"
                DataKeyNames="IdMedico" OnSelectedIndexChanged="dgvMedicos_SelectedIndexChanged1" OnPageIndexChanging="dgvMedicos_PageIndexChanging1"
                AllowPaging="true" PageSize="5">

                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField HeaderText="Matricula" DataField="Matricula" />
                    <asp:BoundField HeaderText="Email" DataField="Email" />
                    <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                    <asp:BoundField HeaderText="IdTurnoTrabajo" DataField="TurnoTrabajo.IdTurnoTrabajo" />
                    <asp:CheckBoxField HeaderText="Estado Activo" DataField="Estado" />
                    <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✍️" />

                </Columns>


            </asp:GridView>


           
        <asp:Button Text="Agregar" runat="server" ID="btnAgregarMedicos" CssClass="btn btn-primary" OnClick="btnAgregarMedicos_Click" />
            <asp:Button Text="Regresar" runat="server" ID="btnRegresarMedicos" CssClass="btn btn-secondary" OnClick="btnRegresarMedicos_Click" />





        </div>
    </div>




</asp:Content>

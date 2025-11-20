<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarEspecialidad.aspx.cs" Inherits="web_clinica.AsignarEspecialidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h3 class="text-center mb-4">🩺 Asignar Especialidades al Médico </h3>
    </div>
    <hr />
    <div class="row">
        <div class="col">
            <div class="w-100">

                <asp:GridView runat="server" ID="dgvEspeciliadadMedico" CssClass="table table-dark  table-bordered" AutoGenerateColumns="false" DataKeyNames="IdMedico" OnPageIndexChanging="dgvEspeciliadadMedico_PageIndexChanging" AllowPaging="true" PageSize="10" OnRowDataBound="dgvEspeciliadadMedico_RowDataBound">


                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                        <asp:BoundField HeaderText="Matricula" DataField="Matricula" />

                        <asp:TemplateField HeaderText="Especialidades Asignadas">
                            <ItemTemplate>
                                <asp:CheckBoxList runat="server"
                                    ID="cblEspecialidades"
                                    DataTextField="Nombre"
                                    DataValueField="IdEspecialidad"
                                    RepeatDirection="Vertical"
                                    CssClass="list-unstyled small">
                                </asp:CheckBoxList>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>

                <div class=" mt-3">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary w-100" OnClick="btnGuardar_Click" />
                </div>

                <div class="mt-3">

                    <asp:Button Text="Volver a Lista de Medicos" runat="server" ID="btnVolverMedico" CssClass="btn btn-secondary" OnClick="btnVolverMedico_Click" />

                </div>

            </div>
        </div>
    </div>
</asp:Content>

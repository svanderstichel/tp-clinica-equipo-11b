<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarEspecialidad.aspx.cs" Inherits="web_clinica.AsignarEspecialidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <style>
   
    body {
        position: relative; /*  posicionar el elemento */
        min-height: 100vh; /* Asegura que cubra al menos toda la ventana */
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
        background-image: url('https://www.animaker.com/hub/wp-content/uploads/2022/10/Screenshot-2022-10-19-at-3.52.30-PM-751x450.png'); 
        background-repeat: no-repeat;
        background-position: center bottom;
        background-size: cover;
        opacity: 0.50; 
    }

    /* Si la tabla oscura se ve afectada, le damos un fondo sólido */
    .table-dark {
        background-color: rgba(33, 37, 41, 0.9); 
    }
</style>
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

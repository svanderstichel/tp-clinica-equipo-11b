<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="web_clinica.Medicos" %>

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
                background-image: url('https://cdn.pixabay.com/photo/2021/10/11/17/37/doctor-6701410_640.jpg');
                background-repeat: no-repeat;
                background-position: center bottom;
                background-size: cover;
                opacity: 0.70;
            }

        /* Si la tabla oscura se ve afectada, le damos un fondo sólido */
        .table-dark {
            background-color: rgba(33, 37, 41, 0.9);
        }
    </style>
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <div class="w-100">
                                                                       <div class="container d-flex justify-content-center mt-5">
                    <div class="w-100">
                        <div class="py-4 mb-3 bg-dark text-light rounded shadow text-center">
                            <h2 class="fw-bold">Panel de médicos 👨‍⚕️👩‍⚕️</h2>
                        </div>
                    </div>
                </div>
                <div class="input-group mb-3" style="width: 25rem;">
                    <span class="input-group-text text-bg-primary">
                        <asp:Label Text="Filtro Apellido Medicos" runat="server" />
                    </span>
                    <asp:TextBox runat="server" ID="txtFiltroMedico" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltroMedico_TextChanged" />
                </div>
                <asp:GridView runat="server" ID="dgvMedicos"
                    CssClass="table table-dark table-bordered" AutoGenerateColumns="false"
                    DataKeyNames="IdMedico" OnRowCommand="dgvMedicos_RowCommand"
                    OnPageIndexChanging="dgvMedicos_PageIndexChanging1" AllowPaging="true" PageSize="8"
                    OnRowDataBound="dgvMedicos_RowDataBound">

                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                        <asp:BoundField HeaderText="Matricula" DataField="Matricula" />
                        <asp:BoundField HeaderText="Email" DataField="Email" />
                        <asp:BoundField HeaderText="Telefono" DataField="Telefono" />

                        <asp:ButtonField
                            HeaderText="Especialidades"
                            CommandName="Especialidades"
                            Text="🩺"
                            ButtonType="Button"
                            ControlStyle-CssClass="btn btn-outline-info"
                            ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center" />

                        <asp:ButtonField
                            HeaderText="Horario"
                            CommandName="Horario"
                            Text="🕒"
                            ButtonType="Button"
                            ControlStyle-CssClass="btn btn-outline-info"
                            ItemStyle-HorizontalAlign="Center"
                            HeaderStyle-HorizontalAlign="Center" />

                        

                        <asp:TemplateField HeaderText="Estado" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:Literal ID="ltEstado" runat="server"></asp:Literal>
    </ItemTemplate>
</asp:TemplateField>
                        <asp:ButtonField
    HeaderText="Modificar"
    CommandName="Datos"
    Text="✍️"
    ButtonType="Button"
    ControlStyle-CssClass="btn btn-outline-info"
    ItemStyle-HorizontalAlign="Center"
    HeaderStyle-HorizontalAlign="Center" />




                    </Columns>
                                                   <PagerTemplate>
               <nav>
                   <nav>
                       <ul class="pagination justify-content-center mb-0">
                           <!-- validar si es la primera pagina: disabled -->
                           <li class='<%# ((GridView)Container.NamingContainer).PageIndex == 0 
                   ? "page-item disabled" 
                   : "page-item" %>'>
                               <!-- boton anterior -->
                               <asp:LinkButton
                                   runat="server"
                                   CommandName="Page"
                                   CommandArgument="Prev"
                                   CssClass="page-link bg-dark text-light border-secondary"> ◀
                               </asp:LinkButton>
                           </li>

                           <!-- Indica página actual -->
                           <li class="page-item disabled">
                               <span class="page-link bg-dark text-light border-secondary">
                                   <!-- pagina actual = index+1 / paginas totales -->
                                   <%# ((GridView)Container.NamingContainer).PageIndex + 1 %> /
               <%# ((GridView)Container.NamingContainer).PageCount %>
                               </span>
                           </li>

                           <!-- validar si es la última página: disabled -->
                           <li class='<%# ((GridView)Container.NamingContainer).PageIndex 
                   == ((GridView)Container.NamingContainer).PageCount - 1
                   ? "page-item disabled" 
                   : "page-item" %>'>

                               <!-- boton siguiente -->
                               <asp:LinkButton
                                   runat="server"
                                   CommandName="Page"
                                   CommandArgument="Next"
                                   CssClass="page-link bg-dark text-light border-secondary"> ▶
                               </asp:LinkButton>
                           </li>
                       </ul>
                   </nav>
           </PagerTemplate>
                </asp:GridView>

            </div>


            <div class="d-flex justify-content-between mt-3">
                <div>
                    <asp:Button Text="Agregar" runat="server" ID="btnAgregarMedicos" CssClass="btn btn-primary me-2" OnClick="btnAgregarMedicos_Click" />
                    <asp:Button Text="Cancelar" runat="server" ID="btnRegresarMedicos" CssClass="btn btn-secondary" OnClick="btnRegresarMedicos_Click" />
                </div>

                <div>
                    <asp:Button Text="Administrar especialidades" runat="server" ID="btnEspecialidades"
                        CssClass="btn btn-success" OnClick="btnEspecialidades_Click" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>

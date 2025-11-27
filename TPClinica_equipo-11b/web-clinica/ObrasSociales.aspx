<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ObrasSociales.aspx.cs" Inherits="web_clinica.FormListaObrasSociales" %>

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
                background-image: url('https://cdn.pixabay.com/photo/2024/09/05/00/03/ai-generated-9023090_640.jpg');
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
    <%--    <style>
        .oculto{
            display: none;
        }
    </style>--%>

    <hr />
    <div class="row">
        <div class="col">
            <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <asp:Label Text="Filtrar" runat="server" />
                        <asp:TextBox runat="server" ID="txtFiltroOS" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltroOS_TextChanged" />
                    </div>
                </div>
            </div>
            <asp:GridView runat="server" ID="dgvObraSocial" DataKeyNames="IdObraSocial"
                OnSelectedIndexChanged="dgvObraSocial_SelectedIndexChanged"
                OnPageIndexChanging="dgvObraSocial_PageIndexChanging" AllowPaging="true" PageSize="5"
                CssClass="table table-dark table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <%--                    <asp:BoundField HeaderText="Id" DataField="IdObraSocial" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />--%>
                    <asp:BoundField HeaderText="Nombre de la Obra Social" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField DataField="Cobertura" HeaderText="Cobertura" />
                    <%--<asp:CheckBoxField HeaderText="Estado" DataField="Estado" />--%>
                    <asp:TemplateField HeaderText="Activo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("Estado") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="true" SelectText="✍️" HeaderText="Accion" />
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
            <asp:Button runat="server" ID="btnAgregarOS" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregarOS_Click" />
            <asp:Button runat="server" ID="btnRegresar" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnRegresar_Click" />
        </div>
    </div>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearEspecialidad.aspx.cs" Inherits="web_clinica.Especialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hfIdEspecialidad" runat="server" />

    <hr />

    <div class="d-flex justify-content-center align-items-start pt-3 mb-5">
        <div class="card shadow p-4" style="width: 22rem; max-width: 25rem; background-color: #EDEAD3">
            <h4 class="text-center mb-4">Agregar Especialidad</h4>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>

                <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" placeholder="Ingrese el nombre"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El nombre es requerido" ControlToValidate="TextBox1" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control" TextMode="MultiLine" Rows="4" placeholder="Ingrese una descripción..."></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="la descripcion es requerida" ControlToValidate="TextBox2" runat="server" />
            </div>

            <div class="mb-3 d-grid gap-2">

                <asp:Button Text="Guardar" runat="server" ID="btnGuardar2" CssClass="btn btn-primary w-100" OnClick="btnGuardar2_Click" />
                <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" CssClass="btn btn-outline-secondary w-100" OnClick="btnCancelar_Click" CausesValidation="false" />
                <asp:Button Text="Inactivar" ID="btnInactivar"  CssClass="btn btn-secondary" OnClick="btnInactivar_Click" runat="server" />
                <asp:Button Text="Activar" runat="server" ID="btnActivar" CssClass="btn btn-success" onClick="btnActivar_Click"  />
            </div>


            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <%--<ContentTemplate>

               
            <div class="mb-3 d-grid gap-2">
                
                <asp:Button Text="Eliminar" runat="server" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger w-100"/>

            </div>

            <%if (ConfirmarEliminacion)
                {   %>
                
                <div="mb-3 d-grid gap-2">   
                    <asp:CheckBox Text=" Confirma Eliminacion" runat="server" ID="chkConfirmaEliminacion" />
                    <asp:Button Text="Eliminar"  runat="server" ID="btnConfirmaEliminacion"  onClick="btnConfirmaEliminacion_Click" CssClass ="btn btn-outline-danger w-100" />
                </div>

             <%}  %>
        </ContentTemplate>  no esta implementado el borrado fisico de registros--%>          
        </asp:UpdatePanel>
        </div>





    </div>



</asp:Content>

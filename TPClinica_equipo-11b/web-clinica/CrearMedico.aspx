<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearMedico.aspx.cs" Inherits="web_clinica.CrearMedico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfIdMedico" runat="server" />

    <hr />

    <div class="d-flex justify-content-center align-items-start pt-3 mb-5">
        <div class="card shadow p-4 " style="width: 45rem; background-color: #EDEAD3;">
            <h4 class="text-center mb-4" color="blue">Agregar Medico</h4>
            <div class="row g-3">
                <div class="col-md-6">
                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <asp:TextBox runat="server" ID="textBox1" CssClass="form-control" placeholder="Ingrese el nombre"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El nombre es requerido" ControlToValidate="textBox1" runat="server" />
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="mb-3">
                        <label for="txtApellido" class="form-label">Apellido</label>
                        <asp:TextBox runat="server" ID="textBox2" CssClass="form-control" placeholder="Ingrese el Apellido"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Apellido es requerido" ControlToValidate="textBox2" runat="server" />
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="mb-3">
                        <label for="txtMatricula" class="form-label">Matricula</label>
                        <asp:TextBox runat="server" ID="textBox6" CssClass="form-control" placeholder="Ingrese la matricula"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="La matricula es requerido" ControlToValidate="textBox6" runat="server" />
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="mb-3">
                        <label for="txtEmail" class="form-label">Email</label>
                        <asp:TextBox runat="server" ID="textBox3" CssClass="form-control" placeholder="Ingrese el Email"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Email es requerido" ControlToValidate="textBox3" runat="server" />
                    </div>
                </div>
                <div class="col-md-6">

                    <div class="mb-3">
                        <label for="txtTelefono" class="form-label">Telefono</label>
                        <asp:TextBox runat="server" ID="textBox4" CssClass="form-control" placeholder="Ingrese el Telefono"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Telefono es requerido" ControlToValidate="textBox4" runat="server" />
                    </div>
                </div>
                <div class="col-md-6">
                </div>
            </div>


            <div class="mb-3 d-grid gap-2 d-md-flex justify-content-md-end">


                <div class="col-6">
                    <asp:Button Text="Guardar" runat="server" ID="btnGuardar" CssClass="btn btn-primary w-100" OnClick="btnGuardar_Click" />
                </div>

                <div class="col-6">
                    <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" CssClass="btn btn-outline-secondary w-100" OnClick="btnCancelar_Click" CausesValidation="false" />
                </div>
            </div>

            <div class="mb-3 d-grid gap-2">
                <asp:Button Text="Inactivar" ID="btnInactivar" CssClass="btn btn-danger" OnClick="btnInactivar_Click" runat="server" />
                <asp:Button Text="Activar" runat="server" ID="btnActivar" CssClass="btn btn-success" onclick="btnActivar_Click"  />
                
            </div>




            <%--             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

       
                <div class="mb-3 d-grid gap-2">
                    <asp:Button Text="Eliminar" runat="server" ID="btnEliminar" OnClick ="btnEliminar_Click" CssClass="btn btn-danger w-100" />
        
                </div>

                <%if (ConfirmarEliminacion)
                    {   %>
        
                    <div="mb-3 d-grid gap-2"> 
                        <asp:CheckBox Text= " Confirma Eliminacion" runat="server" ID="chkConfirmaEliminacion"/>
                        <asp:Button Text="Eliminar" runat="server" ID="btnConfirmarEliminacion" OnClick="btnConfirmarEliminacion_Click" CssClass="btn btn-outline-danger w-100" />
                        
                    </div>

                 <%}  %>
            </ContentTemplate>            
         </asp:UpdatePanel>No hay borrado fisico de registros --%>
        </div>
    </div>
</asp:Content>

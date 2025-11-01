<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearMedico.aspx.cs" Inherits="web_clinica.CrearMedico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <hr />

    <div class="d-flex justify-content-center align-items-start pt-5">
        <div class="card shadow p-4" style="width: 22rem;">
            <h4 class="text-center mb-4">Agregar Medico</h4>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="textBox1" cssClass="form-control" placeholder="Ingrese el nombre"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El nombre es requerido" ControlToValidate="textBox1" runat="server" />
            </div>

            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox runat="server" ID="textBox2" cssClass="form-control" placeholder="Ingrese el Apellido"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Apellido es requerido" ControlToValidate="textBox2" runat="server" />
            </div>
            
            <div class="mb-3">
                <label for="txtMatricula" class="form-label">Matricula</label>
                <asp:TextBox runat="server" ID="textBox6" cssClass="form-control" placeholder="Ingrese la matricula"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="La matricula es requerido" ControlToValidate="textBox6" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="textBox3" cssClass="form-control" placeholder="Ingrese el Email"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Email es requerido" ControlToValidate="textBox3" runat="server" />
            </div>
            
            <div class="mb-3">
                <label for="txtTelefono" class="form-label">Telefono</label>
                <asp:TextBox runat="server" ID="textBox4" cssClass="form-control" placeholder="Ingrese el Telefono"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El Telefono es requerido" ControlToValidate="textBox4" runat="server" />
            </div>
            
            <div class="mb-3">
                <label for="ddlTurnoTrabajo" class="form-label">Turno de Trabajo</label>
                <asp:DropDownList runat="server" ID="ddlTurnoTrabajo" CssClass="form-control">
                 </asp:DropDownList>
                 <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El turno es requerido" ControlToValidate="ddlTurnoTrabajo" runat="server" InitialValue="0"/>
            </div>
            
            
        </div>



        
            <div class="mb-3 d-grid gap-2">
                <asp:button text="Guardar" runat="server" ID="btnGuardar" cssClass="btn btn-primary w-100" OnClick="btnGuardar_Click" />

                <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" CssClass="btn btn-outline-secondary w-100" OnClick="btnCancelar_Click" CausesValidation="false" />
            </div>
        </div>
   



</asp:Content>

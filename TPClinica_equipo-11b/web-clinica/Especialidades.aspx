<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="web_clinica.Especialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



       <hr />

             <div class="d-flex justify-content-center align-items-start pt-5">
     <div class="card shadow p-4" style="width: 22rem;">
         <h4 class="text-center mb-4">Agregar Especialidad</h4>

         <div class="mb-3">
             <label for="txtNombre" class="form-label">Nombre</label>
            
             <asp:TextBox runat="server"  ID="TextBox1" cssClass="form-control" placeholder="Ingrese el nombre"></asp:TextBox>
             <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El nombre es requerido" ControlToValidate="TextBox1" runat="server" />
         </div>
         <div class="mb-3">
             <label for="txtDescripcion" class="form-label">Descripción</label>
             <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control" TextMode="MultiLine" Rows="4" placeholder="Ingrese una descripción..." ></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="la descripcion es requerida" ControlToValidate="TextBox2" runat="server"/>
         </div>

         <div class="mb-3 d-grid gap-2">

             <asp:Button Text="Guardar" runat="server" ID="btnGuardar2" CssClass="btn btn-primary w-100" OnClick="btnGuardar2_Click"/>
             
        
             <asp:Button Text="Cancelar" runat="server" ID="btnCancelar" CssClass="btn btn-outline-secondary w-100" OnClick="btnCancelar_Click" />
             
         </div>
     </div>
 </div>



</asp:Content>

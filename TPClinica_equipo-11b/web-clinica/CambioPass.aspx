<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambioPass.aspx.cs" Inherits="web_clinica.CambioPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlCambioPass" runat="server" DefaultButton="btnGuardar">

    <div class="d-flex justify-content-center align-items-center mt-5">
    <div class="card" style="width: 30rem;">
        <div class="card-body">
            <h4 class="card-title text-center mb-3">Cambio de contraseña</h4>
            <div class="input-group mb-3">
                <span class="input-group-text" id="basic-addon1">@</span>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" 
                    placeholder="correo@ejemplo.com" aria-label="Email" aria-describedby="basic-addon1" 
                    ReadOnly ="true" />
            </div>
            <div class="input-group mb-3">
                <span class="input-group-text">Anterior</span>
                <asp:TextBox ID="txtPassAnterior" runat="server" CssClass="form-control" aria-label="Password" aria-describedby="inputGroup-sizing-default" TextMode="Password" />
            </div>
            <div class="input-group mb-3">
                <span class="input-group-text">Nueva</span>
                <asp:TextBox ID="txtPassNueva" runat="server" CssClass="form-control" aria-label="Password" aria-describedby="inputGroup-sizing-default" TextMode="Password" />
            </div>

            <div class="d-flex justify-content-between">
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick ="btnCancelar_Click"/>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" onclick ="btnGuardar_Click"/>
            </div>
            <div class="toast-container position-fixed bottom-0 end-0 p-5 mb-5">
                <asp:Panel ID="panelToast" runat="server" role="alert" aria-live="assertive" aria-atomic="true">
                    <div class="d-flex">
                        <div class="toast-body">
                            <asp:Label ID="lblToast" runat="server"></asp:Label>
                        </div>
                        <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
                    </div>
                </asp:Panel>
            </div>

        </div>
    </div>
    </div>
        </asp:Panel>
</asp:Content>

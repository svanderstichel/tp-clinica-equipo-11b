﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearObraSocial.aspx.cs" Inherits="web_clinica.ObrasSociales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <hr />

    <div class="d-flex justify-content-center align-items-start pt-5">
        <div class="card shadow p-4" style="width: 22rem;">
            <h4 class="text-center mb-4">Agregar Obra Social</h4>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Ingrese el nombre"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control"
                    TextMode="MultiLine" Rows="4" placeholder="Ingrese una descripción..."></asp:TextBox>
            </div>

            <div class="mb-3 d-grid gap-2">
                <asp:Button runat="server" ID="btnGuardar" Text="Guardar" CssClass="btn btn-primary w-100" OnClick="btnGuardar_Click" />
                <asp:Button runat="server" ID="btnVolver" Text="Cancelar" CssClass="btn btn-outline-secondary w-100" OnClick="btnCancelar_Click" />
            </div>
        </div>
    </div>




</asp:Content>



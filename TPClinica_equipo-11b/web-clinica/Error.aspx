<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="web_clinica.Error" %>
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
            background-image: url('https://images.unsplash.com/photo-1532938911079-1b06ac7ceec7?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fE1FRElDT1N8ZW58MHx8MHx8fDA%3D');
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
    <div class="my-5">
    <div class="row justify-content-center">
        <div class="text-center">
            <asp:Label ID="lblError" style="font-size: 25px; font-weight:bold;" runat="server"></asp:Label>
        </div>
    </div>
    <div class="row justify-content-center mt-5">
        <div class="col-md-6 col-lg-4 text-center">
            <img src="/Content/error.png" alt="error" class="img-fluid" />
        </div>
    </div>
</div>
</asp:Content>
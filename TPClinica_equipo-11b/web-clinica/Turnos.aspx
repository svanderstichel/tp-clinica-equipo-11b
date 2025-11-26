<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="web_clinica.Turnos" %>

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
             background-image: url('https://plus.unsplash.com/premium_photo-1681996569472-2f9a3a7da29a?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OXx8Y3VpZGFkb3xlbnwwfHwwfHx8MA%3D%3D');
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
    <div class="container d-flex justify-content-center mt-5">
        <div class="w-100">
            <h3 class="text-center mb-3">Lista de Turnos</h3>
            <asp:GridView ID="dgvTurnos" OnRowDeleting="dgvTurnos_RowDeleting" OnSelectedIndexChanged="dgvTurnos_SelectedIndexChanged" DataKeyNames="Id" runat="server" CssClass="table table-dark table-bordered" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging="dgvTurnos_PageIndexChanging" OnRowDataBound="dgvTurnos_RowDataBound" >
                <Columns>
                    <asp:BoundField DataField="Estado" HeaderText="Estado" HtmlEncode="false" />
                    <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                    <asp:BoundField DataField="Paciente" HeaderText="Paciente" />
                    <asp:BoundField DataField="Medico" HeaderText="Médico" />
                    <asp:BoundField DataField="FechaFormateada" HeaderText="Fecha" />
                    <asp:BoundField DataField="HoraFormateada" HeaderText="Hora" />
                    <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" />
                    <asp:CommandField ShowSelectButton="true" SelectText="✍️" ButtonType="Button" ControlStyle-CssClass="btn btn-outline-info" HeaderText="Modificar" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:CommandField ShowDeleteButton="true" DeleteText="❌" ButtonType="Button" ControlStyle-CssClass="btn btn-outline-danger" HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <%  if (Session["Usuario"] != null)
        {
            dominio.Usuario usuario = (dominio.Usuario)Session["Usuario"];
            if (usuario.Tipo.ToString() == "Medico"
            || usuario.Tipo.ToString() == "Recepcionista"
            || usuario.Tipo.ToString() == "Administrador")
            { %>
<div class="d-flex justify-content-between align-items-center mt-3">

    <div class="d-flex align-items-center">

        <div class="input-group me-4" style="width: 200px;">
            <span class="input-group-text">Estado</span>
            <asp:DropDownList ID="FiltroEstado" runat="server" CssClass="form-select"
                AutoPostBack="true" OnSelectedIndexChanged="FiltroEstado_SelectedIndexChanged">
            </asp:DropDownList>
        </div>

        <div class="input-group me-4" style="width: 300px;">
            <span class="input-group-text">Paciente</span>
            <asp:TextBox ID="FiltroPaciente" runat="server" AutoPostBack="true"
                CssClass="form-control" OnTextChanged="FiltroPaciente_TextChanged"></asp:TextBox>
        </div>

    </div>

    <div class="d-flex">
        <asp:Button ID="BtnLimpiarFiltro" runat="server" Text="Limpiar filtros"
            CssClass="btn btn-secondary me-2"
             onclick="BtnLimpiarFiltro_Click" />
        <asp:Button ID="BtnCrearTurno" runat="server" Text="Solicitar turno"
            CssClass="btn btn-primary" OnClick="BtnCrearTurno_Click" />

    </div>

</div>
    <%}
        if (usuario.Tipo.ToString() == "Paciente")
        { %>
    <div class="d-flex justify-content-end mt-3">
        <asp:Button ID="Button1" runat="server" Text="Solicitar turno" CssClass="btn btn-primary" OnClick="BtnCrearTurno_Click" />
    </div>
    <%}
        }%>
</asp:Content>

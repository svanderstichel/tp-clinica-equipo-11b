<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="web_clinica.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center align-items-start pt-5">
        <div class="card shadow p-4" style="width: 22rem;">
            <fieldset>
                <legend>Alta de usuario</legend>
                <div class="mb-3">
                    <label for="emailInput" class="form-label">Email</label>
                    <asp:TextBox ID="emailInput" CssClass="form-control" placeholder="ejemplo@gmail.com" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="nombreInput" class="form-label">Nombre</label>
                    <asp:TextBox ID="nombreInput" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="apellidoInput" class="form-label">Apellido</label>
                    <asp:TextBox ID="apellidoInput" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="disabledSelect" class="form-label">Rol</label>
                    <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Seleccione rol..." Value="0" />
                        <asp:ListItem Text="Administrador" Value="1" />
                        <asp:ListItem Text="Recepcionista" Value="2" />
                        <asp:ListItem Text="Médico" Value="3" />
                        <asp:ListItem Text="Paciente" Value="4" />
                    </asp:DropDownList>

                </div>
                <div class="mb-3">
                    <label for="passwordInput" class="form-label">Password</label>
                    <asp:TextBox runat="server" ID="inputPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div class="mb-3">
                </div>
                <asp:Button
                    ID="btnRegistrarse"
                    runat="server"
                    Text="Registrarse"
                    CssClass="btn btn-primary"
                    OnClick="btnRegistrarse_Click" />

            </fieldset>
        </div>
    </div>
</asp:Content>

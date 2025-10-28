<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="web_clinica.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center align-items-start pt-5">
        <div class="card shadow p-4" style="width: 22rem;">
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email"></asp:TextBox>
                <div id="emailHelp" class="form-text">No compartas tus credenciales.</div>
            </div>
            <div class="mb-3">
                <label for="exampleInputPassword1" class="form-label">Password</label>
                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <div class="mb-3 d-grid gap-2">
                <asp:Button runat="server" ID="btnIngresar" Text="Ingresar" CssClass="btn btn-primary w-100" onclick="btnIngresar_Click"/>
                <asp:Button runat="server" ID="btnRegistro" Text="Registro" CssClass="btn btn-outline-success w-100" onclick="btnRegistro_Click"/>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormListaObrasSociales.aspx.cs" Inherits="web_clinica.FormListaObrasSociales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div class="row">
        <div class="col">
            <asp:GridView runat="server" ID="dgvObraSocial" CssClass="table table-dark table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Nombre de la Obra Social" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                </Columns>
            </asp:GridView>
            <asp:Button runat="server" ID="btnAgregarOS" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregarOS_Click" />
            <asp:Button runat="server" ID="btnRegresar" Text="Volver" CssClass="btn btn-secondary" OnClick="btnRegresar_Click" />

        </div>
    </div>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ObrasSociales.aspx.cs" Inherits="web_clinica.FormListaObrasSociales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <style>
        .oculto{
            display: none;
        }
    </style>--%>

    <hr />
    <div class="row">
        <div class="col">
            <asp:GridView runat="server" ID="dgvObraSocial" DataKeyNames="IdObraSocial"
                OnSelectedIndexChanged="dgvObraSocial_SelectedIndexChanged"
                OnPageIndexChanging="dgvObraSocial_PageIndexChanging" AllowPaging="true" PageSize="5"
                CssClass="table table-dark table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <%--                    <asp:BoundField HeaderText="Id" DataField="IdObraSocial" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />--%>
                    <asp:BoundField HeaderText="Nombre de la Obra Social" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField DataField="Cobertura" HeaderText="Cobertura" />
                    <asp:CheckBoxField HeaderText="Estado" DataField="Estado" />
                    <asp:CommandField ShowSelectButton="true" SelectText="✍️" HeaderText="Accion" />
                </Columns>
            </asp:GridView>
            <asp:Button runat="server" ID="btnAgregarOS" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregarOS_Click" />
            <asp:Button runat="server" ID="btnRegresar" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnRegresar_Click" />
        </div>
    </div>

</asp:Content>

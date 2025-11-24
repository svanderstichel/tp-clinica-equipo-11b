<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="web_clinica.ListaEspecialidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div class="row">
        <div class="col">
            <h1>Lista de especialidades</h1>
            <asp:GridView runat="server" ID="dgvEspecialidad" CssClass="table table-dark table-bordered" AutoGenerateColumns="false"
                DataKeyNames="IdEspecialidad" OnSelectedIndexChanged="dgvEspecialidad_SelectedIndexChanged"
                OnPageIndexChanging="dgvEspecialidad_PageIndexChanging" OnRowCommand="dgvEspecialidad_RowCommand"
                AllowPaging="true" PageSize="5">
                <Columns>
                    <asp:BoundField HeaderText="Nombre de la Especialidad" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:ButtonField
                        HeaderText="Accion"
                        CommandName="Accion"
                        Text="✍️"
                        ButtonType="Button"
                        ControlStyle-CssClass="btn btn-outline-info"
                        ItemStyle-HorizontalAlign="Center"
                        HeaderStyle-HorizontalAlign="Center" />

                    <asp:TemplateField HeaderText="Estado Activo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkEstado" Enabled="false" Checked='<%# Eval("Estado") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>



                </Columns>
            </asp:GridView>
            <asp:Button Text="Agregar" runat="server" ID="btnAgregarEsp" CssClass="btn btn-primary" OnClick="btnAgregarEsp_Click" />

            <asp:Button Text="Cancelar" runat="server" ID="btnRegresar" CssClass="btn btn-secondary" OnClick="btnRegresar_Click" />


        </div>
    </div>


</asp:Content>

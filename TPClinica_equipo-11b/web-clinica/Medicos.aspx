<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="web_clinica.Medicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div class="row">
        <div class="col">
                        <div class="w-100">
        <h3 class="text-center mb-3">Lista de Médicos</h3>
        <asp:GridView runat="server" ID="dgvMedicos"
            CssClass="table table-dark table-bordered" AutoGenerateColumns="false"
            DataKeyNames="IdMedico" OnRowCommand="dgvMedicos_RowCommand" 
            OnPageIndexChanging="dgvMedicos_PageIndexChanging1" AllowPaging="true" PageSize="10">

    <Columns>
        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
        <asp:BoundField HeaderText="Matricula" DataField="Matricula" />
        <asp:BoundField HeaderText="Email" DataField="Email" />
        <asp:BoundField HeaderText="Telefono" DataField="Telefono" />

        <asp:ButtonField 
            HeaderText="Especialidades"
            CommandName="Especialidades"
            Text="🩺"
            ButtonType="Button"
            ControlStyle-CssClass="btn btn-outline-info"
            ItemStyle-HorizontalAlign="Center"
            HeaderStyle-HorizontalAlign="Center" />

        <asp:ButtonField 
            HeaderText="Horario"
            CommandName="Horario"
            Text="🕒"
            ButtonType="Button"
            ControlStyle-CssClass="btn btn-outline-info"
            ItemStyle-HorizontalAlign="Center"
            HeaderStyle-HorizontalAlign="Center" />

        <asp:ButtonField 
            HeaderText="Datos"
            CommandName="Datos"
            Text="✍️"
            ButtonType="Button"
            ControlStyle-CssClass="btn btn-outline-info"
            ItemStyle-HorizontalAlign="Center"
            HeaderStyle-HorizontalAlign="Center" />

        <asp:TemplateField HeaderText="Activo" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
            <asp:CheckBox  runat="server" ID="chkEstado" Enabled="false" Checked='<%# Eval("Estado") %>' />        
        
    </ItemTemplate>
</asp:TemplateField>



    </Columns>

</asp:GridView>

        </div>

           
<div class="d-flex justify-content-between mt-3">
                <div>
                    <asp:Button Text="Agregar" runat="server" ID="btnAgregarMedicos" CssClass="btn btn-primary me-2" OnClick="btnAgregarMedicos_Click" />
                    <asp:Button Text="Cancelar" runat="server" ID="btnRegresarMedicos" CssClass="btn btn-secondary" OnClick="btnRegresarMedicos_Click" />
                </div>

                <div>
                    <asp:Button Text="Administrar especialidades" runat="server" ID="btnEspecialidades"
                        CssClass="btn btn-success" OnClick ="btnEspecialidades_Click" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="web_clinica.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
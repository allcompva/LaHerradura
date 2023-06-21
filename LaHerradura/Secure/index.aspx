<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPVecino.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LaHerradura.Secure.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-3 form-group">
            <label>Tipo Comprobante</label>
            <asp:DropDownList ID="DDLTipoComp" CssClass="form-control" runat="server">
                <asp:ListItem Text="Factura" Value="11"></asp:ListItem>
                <asp:ListItem Text="Nota de Debito" Value="12"></asp:ListItem>
                <asp:ListItem Text="Nota de Credito" Value="13"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-3 form-group">
            <label>Nro Comprobante</label>
            <asp:TextBox ID="txtNroComprobante"
                CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-6" style="padding-top:23px;">
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar"
                OnClick="btnConsultar_Click" CssClass="btn btn-primary" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-3 form-group">
            <label>Tipo Comprobante</label>
            <asp:DropDownList ID="txtNroComprobante2" CssClass="form-control" runat="server">
                <asp:ListItem Text="Factura" Value="11"></asp:ListItem>
                <asp:ListItem Text="Nota de Credito" Value="13"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-3 form-group">
            <label>Nro Comprobante</label>
            <asp:TextBox ID="txtCompDesde"
                CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-3 form-group">
            <label>Nro Comprobante</label>
            <asp:TextBox ID="txtCompHasta"
                CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-3" style="padding-top:23px;">
            <asp:Button ID="btnInsertarFacturas" runat="server" Text="Consultar"
                OnClick="btnInsertarFacturas_Click" CssClass="btn btn-primary" />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div id="divComprobante" runat="server"></div>
        </div>
    </div>
</asp:Content>

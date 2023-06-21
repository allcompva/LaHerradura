<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="apertura_caja.aspx.cs" Inherits="LaHerradura.Back.apertura_caja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hIdUsuario" runat="server" />
    <div class="alert alert-danger alert-dismissible" id="divError" runat="server" visible="false">
        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
        <h4><i class="icon fa fa-ban"></i>Error!</h4>
        <p id="lblMsj" runat="server"></p>
        <asp:Button ID="btnSalir" runat="server" Text="Volver" 
            OnClick="btnSalir_Click"
            CssClass="btn btn-default"/>
    </div>
    <div class="row" style="margin-top:50px;" id="divCaja" runat="server">
        <div class="col-md-4 col-md-offset-4">
            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">Apertura de Caja</h3>
                </div>
                <div class="box-body">
                    <div class="form-group">
                        <label>Fecha - hora</label>
                        <asp:TextBox ID="txtFechaHora" CssClass="form-control"
                            Enabled="false"
                            runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Usuario</label>
                        <asp:TextBox ID="txtUsuario" CssClass="form-control"
                            Enabled="false"
                            runat="server"></asp:TextBox>
                    </div>
<%--                    <div class="form-group">
                        <label>Fondo Fijo</label>
                        <asp:TextBox ID="txtFF" Text="0" CssClass="form-control"
                            runat="server"></asp:TextBox>
                    </div>--%>
                    <div class="form-group">
                        <label>Obsevaciones</label>
                        <asp:TextBox ID="txtObs" CssClass="form-control"
                            runat="server"></asp:TextBox>
                    </div>
                    <div style="text-align:right;">
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"
                            OnClick="btnCancelar_Click"
                            CssClass="btn btn-warning"/>
                        <asp:Button ID="btnAceptar" runat="server" 
                            OnClick="btnAceptar_Click"
                            Text="Aceptar"
                            CssClass="btn btn-primary"/>
                    </div>
                </div>
                <div class="box-footer"></div>
            </div>
        </div>
    </div>

</asp:Content>

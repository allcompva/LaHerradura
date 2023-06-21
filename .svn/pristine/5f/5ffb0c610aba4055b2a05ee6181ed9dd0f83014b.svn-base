<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="PlanesPago.aspx.cs" Inherits="LaHerradura.Secure.PlanesPago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        strong {
            font-size: 14px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-top: 20px;">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="box-header with-border"
                    style="border-bottom: 1px solid #cccccc;">
                    <div class="col-md-8">
                        <h3 class="box-title" id="lblCuenta" runat="server"></h3>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Fecha</label>
                            <asp:TextBox ID="txtFechaRecalculo" 
                                TextMode="Date"
                                CssClass="form-control"
                                runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group" style="padding-top:24px;">
                            <asp:Button ID="btnRecalculo"
                                CssClass="btn btn-primary"
                                OnClick="btnRecalculo_Click"
                                runat="server" Text="Recalcular" />
                        </div>
                    </div>
                </div>
                <div class="box-body">
                    <div class="row">
                        <div class="col-md-6" style="border-right: 1px solid #cccccc;">
                            <div>
                                <div class="box-header">
                                    <h3 class="box-title">Detalle Paln</h3>
                                </div>
                                <div class="box-body">
                                    <p>
                                        Saldo a financiar: 
                                        <strong id="lblMontoOriginal" runat="server" class="pull-right"></strong>
                                    </p>
                                    <p>
                                        Cant. cuotas: 
                                        <strong id="lblCantCuotas" runat="server" class="pull-right"></strong>
                                    </p>
                                    <p>
                                        Sistema de amortización: 
                                        <strong id="lblSistAmortizacion" runat="server"
                                            class="pull-right"></strong>
                                    </p>
                                    <p style="display: none;">
                                        TNA <small>(Tasa Nominal Anual)</small>: 
                                        <strong id="lblTNA" runat="server" class="pull-right"></strong>
                                    </p>
                                    <p>
                                        Total plan: 
                                        <strong id="lblTotal" runat="server" class="pull-right"></strong>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div>
                                <div class="box-header">
                                    <h3 class="box-title">Expensas incluidas</h3>
                                </div>
                                <div class="box-body">
                                    <asp:GridView ID="gvExpensas"
                                        CssClass="table table-hover"
                                        AutoGenerateColumns="false"
                                        GridLines="None"
                                        DataKeyNames="ID"
                                        ShowFooter="true"
                                        ShowHeader="false"
                                        runat="server">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <div><%#Eval("PERIODOMAQUILLADO")%></div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <div class="form-group">
                                        <label>Total</label>
                                        <asp:TextBox ID="txtTotalOriginal"
                                            CssClass="form-control"
                                            Style="text-align: right"
                                            Enabled="false"
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div>
                                <div class="box-header">
                                    <h3 class="box-title">Tabla de Amortización</h3>
                                </div>
                                <div class="box-body">
                                    <asp:GridView ID="gvTablaAmortizacion"
                                        CssClass="table table-bordered"
                                        AutoGenerateColumns="false"
                                        runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="NRO_CUOTA" HeaderText="CUOTA" />
                                            <asp:BoundField DataField="MONTO_CUOTA" HeaderText="MONTO" DataFormatString="{0:C}" />
                                            <asp:BoundField DataField="VENCIMIENTO" HeaderText="VENCIMIENTO" DataFormatString="{0:d}" />
                                            <asp:BoundField DataField="CAPITAL_PAGADO" HeaderText="CAPITAL" DataFormatString="{0:C}" />
                                            <asp:BoundField DataField="INTERES_PAGADO" HeaderText="INTERES" DataFormatString="{0:C}" />
                                            <asp:BoundField DataField="SALDO" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderText="SALDO" DataFormatString="{0:C}" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:GridView ID="gvTablaAmortizacion2"
                                        OnRowDataBound="gvTablaAmortizacion2_RowDataBound"
                                        CssClass="table table-bordered"
                                        AutoGenerateColumns="false"
                                        ShowFooter="true"
                                        runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="NRO_CUOTA" HeaderText="CUOTA" />
                                            <asp:BoundField DataField="MONTO_CUOTA" HeaderText="MONTO" />
                                            <asp:BoundField DataField="VENCIMIENTO" HeaderText="VENCIMIENTO" DataFormatString="{0:d}" />
                                        </Columns>
                                        <FooterStyle Font-Bold="true" Font-Size="Large" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row" id="divCrearPlan" runat="server">
        <div class="col-md-12" style="text-align: right">
            <asp:Button ID="btnCancelar" CssClass="btn btn-warning"
                runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            <button type="button" class="btn btn-primary" data-toggle="modal"
                data-target="#modal-default">
                Crear Plan
            </button>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
        </div>
    </div>
    <div class="modal fade in" id="modal-default">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span></button>
                    <h4 class="modal-title">Crear plan de pago</h4>
                </div>
                <div class="modal-body">
                    <p>¿Esta seguro de crear el plan de pagos?</p>
                </div>
                <div class="modal-footer" style="text-align: right">
                    <button type="button" class="btn btn-default pull-left"
                        data-dismiss="modal">
                        Cancelar</button>
                    <asp:Button ID="btnAceptar" CssClass="btn btn-primary"
                        runat="server" Text="Crear Plan" OnClick="btnAceptar_Click" />
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</asp:Content>

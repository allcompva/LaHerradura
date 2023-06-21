<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="LaHerradura.Back.Factura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @page {
            size: A4;
            margin: 40px;
        }


        @media print {
            html,
            body {
                width: 210mm;
                height: 297mm;
            }

            @-moz-document url-prefix() {
            }

            .col-sm-1,
            .col-sm-2,
            .col-sm-3,
            .col-sm-4,
            .col-sm-5,
            .col-sm-6,
            .col-sm-7,
            .col-sm-8,
            .col-sm-9,
            .col-sm-10,
            .col-sm-11,
            .col-sm-12,
            .col-md-1,
            .col-md-2,
            .col-md-3,
            .col-md-4,
            .col-md-5,
            .col-md-6,
            .col-md-7,
            .col-md-8,
            .col-md-9,
            .col-md-10,
            .col-md-11,
            .col-smdm-12 {
                float: left;
            }

            .col-sm-12,
            .col-md-12 {
                width: 100%;
            }

            .col-sm-11,
            .col-md-11 {
                width: 91.66666667%;
            }

            .col-sm-10,
            .col-md-10 {
                width: 83.33333333%;
            }

            .col-sm-9,
            .col-md-9 {
                width: 75%;
            }

            .col-sm-8,
            .col-md-8 {
                width: 66.66666667%;
            }

            .col-sm-7,
            .col-md-7 {
                width: 58.33333333%;
            }

            .col-sm-6,
            .col-md-6 {
                width: 50%;
            }

            .col-sm-5,
            .col-md-5 {
                width: 41.66666667%;
            }

            .col-sm-4,
            .col-md-4 {
                width: 33.33333333%;
            }

            .col-sm-3,
            .col-md-3 {
                width: 25%;
            }

            .col-sm-2,
            .col-md-2 {
                width: 16.66666667%;
            }

            .col-sm-1,
            .col-md-1 {
                width: 8.33333333%;
            }

            .col-sm-pull-12 {
                right: 100%;
            }

            .col-sm-pull-11 {
                right: 91.66666667%;
            }

            .col-sm-pull-10 {
                right: 83.33333333%;
            }

            .col-sm-pull-9 {
                right: 75%;
            }

            .col-sm-pull-8 {
                right: 66.66666667%;
            }

            .col-sm-pull-7 {
                right: 58.33333333%;
            }

            .col-sm-pull-6 {
                right: 50%;
            }

            .col-sm-pull-5 {
                right: 41.66666667%;
            }

            .col-sm-pull-4 {
                right: 33.33333333%;
            }

            .col-sm-pull-3 {
                right: 25%;
            }

            .col-sm-pull-2 {
                right: 16.66666667%;
            }

            .col-sm-pull-1 {
                right: 8.33333333%;
            }

            .col-sm-pull-0 {
                right: auto;
            }

            .col-sm-push-12 {
                left: 100%;
            }

            .col-sm-push-11 {
                left: 91.66666667%;
            }

            .col-sm-push-10 {
                left: 83.33333333%;
            }

            .col-sm-push-9 {
                left: 75%;
            }

            .col-sm-push-8 {
                left: 66.66666667%;
            }

            .col-sm-push-7 {
                left: 58.33333333%;
            }

            .col-sm-push-6 {
                left: 50%;
            }

            .col-sm-push-5 {
                left: 41.66666667%;
            }

            .col-sm-push-4 {
                left: 33.33333333%;
            }

            .col-sm-push-3 {
                left: 25%;
            }

            .col-sm-push-2 {
                left: 16.66666667%;
            }

            .col-sm-push-1 {
                left: 8.33333333%;
            }

            .col-sm-push-0 {
                left: auto;
            }

            .col-sm-offset-12 {
                margin-left: 100%;
            }

            .col-sm-offset-11 {
                margin-left: 91.66666667%;
            }

            .col-sm-offset-10 {
                margin-left: 83.33333333%;
            }

            .col-sm-offset-9 {
                margin-left: 75%;
            }

            .col-sm-offset-8 {
                margin-left: 66.66666667%;
            }

            .col-sm-offset-7 {
                margin-left: 58.33333333%;
            }

            .col-sm-offset-6 {
                margin-left: 50%;
            }

            .col-sm-offset-5 {
                margin-left: 41.66666667%;
            }

            .col-sm-offset-4 {
                margin-left: 33.33333333%;
            }

            .col-sm-offset-3 {
                margin-left: 25%;
            }

            .col-sm-offset-2 {
                margin-left: 16.66666667%;
            }

            .col-sm-offset-1 {
                margin-left: 8.33333333%;
            }

            .col-sm-offset-0 {
                margin-left: 0%;
            }

            .visible-xs {
                display: none !important;
            }

            .hidden-xs {
                display: block !important;
            }

            table.hidden-xs {
                display: table;
            }

            tr.hidden-xs {
                display: table-row !important;
            }

            th.hidden-xs,
            td.hidden-xs {
                display: table-cell !important;
            }

            .hidden-xs.hidden-print {
                display: none !important;
            }

            .hidden-sm {
                display: none !important;
            }

            .visible-sm {
                display: block !important;
            }

            table.visible-sm {
                display: table;
            }

            tr.visible-sm {
                display: table-row !important;
            }

            th.visible-sm,
            td.visible-sm {
                display: table-cell !important;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-top: 25px; background-color:white;">
        <div class="col-md-1"></div>
        <div class="col-md-10">
            <div style="margin-top:35px;">
                <div class="box-body">

                    <div class="col-md-12"
                        style="border: 1px solid; padding: 5px; text-align: center; margin-bottom: 5px;">
                        <p id="lblFact" runat="server">ORIGINAL</p>
                    </div>

                    <div class="col-md-12" style="border: 1px solid; margin-top: 10px;">
                        <div class="row">
                            <div class="col-md-5">
                                <p style="font-size: 18px; text-align: center; padding-top: 25px; font-weight: 600;"
                                    id="lblEmpresa" runat="server">
                                </p>
                            </div>
                            <div class="col-md-2" style="border: 1px solid; text-align: center; border-top: none;">
                                <p id="lblTipoComp" runat="server" style="font-size: 30px; font-weight: 700;"></p>
                                <p id="lblCodTipoComp" runat="server" style="font-size: 11px;"></p>
                            </div>
                            <div class="col-md-5">
                                <p style="font-size: 14px; font-weight: 600; padding-top: 5px;">FACTURA</p>
                                <p id="lblNroComp" runat="server" style="font-size: 12px; font-weight: 600;"></p>
                                <p id="lblFechaComp" runat="server" style="font-size: 12px; font-weight: 600;"></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6" style="border-right: 1px solid; padding-top: 25px;">
                                <p id="lblRazonSocial" runat="server"></p>
                                <p id="lblDirEmpresa" runat="server"></p>
                                <p id="lblLocalidadEmpresa" runat="server"></p>
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col-md-5" style="padding-top: 20px;">
                                <p id="lblCuitEmpresa" runat="server"></p>
                                <p id="lblIngBrutosEmpresa" runat="server"></p>
                                <p id="lblInicioAct" runat="server"></p>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12" style="border: 1px solid; margin-top: 10px;">
                        <div class="row">
                            <div class="col-md-6">
                                <p id="lblCuitCliente" runat="server"></p>
                                <p id="lblCondIvaCliente" runat="server"></p>
                            </div>
                            <div class="col-md-6">
                                <p id="lblNombreCliente" runat="server"></p>
                                <p id="lblDireccionCliente" runat="server"></p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12" style="border: 1px solid; padding: 10px; margin-top: 10px;">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView
                                    ID="gvDetalle"
                                    runat="server"
                                    AutoGenerateColumns="false"
                                    CellPadding="4"
                                    OnRowDataBound="gvDetalle_RowDataBound"
                                    ForeColor="#333333"
                                    CssClass="table table-hover"
                                    GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="CANT" HeaderText="Cant." ControlStyle-Width="10%" />
                                        <asp:BoundField DataField="DESC_CONCEPTO" HeaderText="Concepto" />
                                        <asp:BoundField DataField="OBS" HeaderText="Observaciones" />
                                        <asp:BoundField DataField="COSTO" HeaderText="Pre. Unit."
                                            DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="SUBTOTAL" HeaderText="Sub Total"
                                            DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-HorizontalAlign="Right" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12" style="border: 1px solid; padding: 10px; margin-top: 10px;">
                        <div class="row">
                            <div class="col-md-4">
                                <p style="text-align: left;">
                                    1° Vencimiento <strong id="lbl1Venc"
                                        runat="server" class="pull-right"></strong>
                                </p>
                                <p style="text-align: left;">
                                    Monto: <strong id="lblMonto1"
                                        runat="server" class="pull-right"></strong>
                                </p>
                            </div>
                            <div class="col-md-4">
                                <p style="text-align: left;">
                                    2° Vencimiento <strong id="lbl2Venc"
                                        runat="server" class="pull-right"></strong>
                                </p>
                                <p style="text-align: left;">
                                    Monto: <strong id="lblMonto2"
                                        runat="server" class="pull-right"></strong>
                                </p>
                            </div>
                            <div class="col-md-4">
                                <p style="text-align: left;">
                                    2° Vencimiento <strong id="lbl3Venc"
                                        runat="server" class="pull-right"></strong>
                                </p>
                                <p style="text-align: left;">
                                    Monto: <strong id="lblMonto3"
                                        runat="server" class="pull-right"></strong>
                                </p>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12" style="border: 1px solid; padding: 10px; margin-top: 10px;"
                        id="divAfip" runat="server">
                        <div class="row">
                            <div class="col-md-12" style="text-align: center;">
                                <img src="../App_Themes/IMG/afip-logo-nuevo.png" style="height: 30px;" />
                            </div>
                            <div class="col-md-12" style="text-align: center;">
                                <label>Comprobante Autirozado</label>
                            </div>
                            <div class="col-md-6">
                                <p id="lblCAE" runat="server"></p>
                                <p id="lblVencCAE" runat="server"></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12" style="text-align: center;">
                                <hr style="border-top: 1px solid #bfbfbf;" />
                                <p style="font-family: Interleaved2of5; font-size: 24px;"
                                    id="lblCodBarra" runat="server">
                                </p>
                                <p style="font-size: 12px;"
                                    id="lblDescCodBarra" runat="server">
                                </p>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="box-footer">
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-10" style="text-align: right;">
                            <input id="btnPrint" type="button" value="Imprimir" onclick="window.print();" class="btn btn-primary" />
                            <a class="btn btn-success" href="#">Salir</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

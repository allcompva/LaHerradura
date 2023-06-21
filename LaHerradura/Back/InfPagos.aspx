﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MP/MPBack.Master" AutoEventWireup="true" 
    CodeBehind="InfPagos.aspx.cs" 
    Culture="es-AR" UICulture="es-AR"
    Inherits="LaHerradura.Back.InfPagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.6.1/css/buttons.dataTables.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-md-12">
                <!-- Widget: user widget style 1 -->
                <div class="box box-widget widget-user-2">
                    <!-- Add the bg color to the header using any of the bg-* classes -->
                    <div class="widget-user-header bg-aqua-active">
                        <div class="widget-user-image">
                            <img class="img-circle" src="../App_Themes/img/expensas.png" />
                        </div>
                        <!-- /.widget-user-image -->
                        <h2 class="widget-user-username"
                            style="margin-top: 15px; margin-bottom: 15px;">Informe Pagos</h2>
                    </div>
                    <div class="box-body" style="padding: 20px;">
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Año</label>
                                    <asp:DropDownList ID="DDLAnio"
                                        CssClass="form-control"
                                        OnSelectedIndexChanged="DDLAnio_SelectedIndexChanged"
                                        AutoPostBack="true"
                                        runat="server">
                                        <asp:ListItem Value="2020" Text="2020"></asp:ListItem>
                                        <asp:ListItem Value="2021" Text="2021"></asp:ListItem>
                                        <asp:ListItem Value="2022" Text="2022"></asp:ListItem>
                                        <asp:ListItem Value="2023" Text="2023"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Mes</label>
                                    <asp:DropDownList ID="DDLMes"
                                        CssClass="form-control"
                                        OnSelectedIndexChanged="DDLMes_SelectedIndexChanged"
                                        AutoPostBack="true"
                                        runat="server">
                                        <asp:ListItem Value="1" Text="Enero"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Febrero"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Marzo"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Abril"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="Mayo"></asp:ListItem>
                                        <asp:ListItem Value="6" Text="Junio"></asp:ListItem>
                                        <asp:ListItem Value="7" Text="Julio"></asp:ListItem>
                                        <asp:ListItem Value="8" Text="Agosto"></asp:ListItem>
                                        <asp:ListItem Value="9" Text="Septiembre"></asp:ListItem>
                                        <asp:ListItem Value="10" Text="Octubre"></asp:ListItem>
                                        <asp:ListItem Value="11" Text="Noviembre"></asp:ListItem>
                                        <asp:ListItem Value="12" Text="Diciembre"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="Todos"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="nav-tabs-custom">
                            <ul class="nav nav-tabs">
                                <li class="active">
                                    <a href="#tab_6" data-toggle="tab">Detalle Pagos
                                    </a>
                                </li>
                                <li>
                                    <a href="#tab_4" data-toggle="tab">Detalle por Medio de Pagos
                                    </a>
                                </li>
                                <%--                                <li><a href="#tab_5" data-toggle="tab">Resumen Pagos</a></li>--%>
                                <li>
                                    <a href="#tab_1" data-toggle="tab">Pagos por cuenta
                                    </a>
                                </li>
                                <li><a href="#tab_2" data-toggle="tab">Pagos por Medios de Pago</a></li>
                                <li><a href="#tab_3" data-toggle="tab">Pagos por Periodo</a></li>
                            </ul>
                            <div class="tab-content">
                                <div class="tab-pane active" id="tab_6">
                                    <div class="box">
                                        <div class="box-header with-border">
                                            <h3 class="box-title">Total Cobrado:
                                                        <strong id="lblTotDetalleGeneral" runat="server"></strong>
                                                <strong>-</strong>
                                            </h3>
                                        </div>
                                        <!-- /.box-header -->
                                        <div class="box-body">
                                            <asp:GridView
                                                ID="gvTotDetalleGral"
                                                runat="server"
                                                AutoGenerateColumns="false"
                                                CellPadding="4"
                                                CssClass="table  table-hover"
                                                ForeColor="#333333"
                                                GridLines="None">
                                                <Columns>
                                                    <asp:BoundField DataField="FECHA" ItemStyle-Wrap="false" HeaderText="Fecha" DataFormatString="{0:d}"/>
                                                    <asp:BoundField DataField="NRO_CTA" ItemStyle-Wrap="false" HeaderText="Nro. Cta." />
                                                    <asp:BoundField DataField="NRO_RECIBO_PAGO" ItemStyle-Wrap="false" HeaderText="Nro. Recido" />
                                                    <asp:BoundField DataField="CAPITAL_PAGADO" ItemStyle-Wrap="false" HeaderText="Capital Pagado" DataFormatString="{0:c}"/>
                                                    <asp:BoundField DataField="INTERES_PAGADO" ItemStyle-Wrap="false" HeaderText="Interes Pagado" DataFormatString="{0:c}"/>
                                                    <asp:BoundField DataField="HABER" ItemStyle-Wrap="false" HeaderText="Sub. Total" DataFormatString="{0:c}"/>
                                                    <asp:BoundField DataField="EFECTIVO_EDMINISTRACION" ItemStyle-Wrap="false" HeaderText="Efectivo" DataFormatString="{0:c}"/>
                                                    <asp:BoundField DataField="CHEQUE" ItemStyle-Wrap="false" HeaderText="Cheque" DataFormatString="{0:c}"/>
                                                    <asp:BoundField DataField="BANELCO" ItemStyle-Wrap="false" HeaderText="Banelco" DataFormatString="{0:c}"/>
                                                    <asp:BoundField DataField="RAPI_PAGO" ItemStyle-Wrap="false" HeaderText="Rapi Pago" DataFormatString="{0:c}"/>
                                                    <asp:BoundField DataField="TRANSFERENCIA_BANCARIA" ItemStyle-Wrap="false" HeaderText="Transferencia" DataFormatString="{0:c}"/>
                                                    <asp:BoundField DataField="DEBITO_AUTOMATICO" ItemStyle-Wrap="false" HeaderText="Débito" DataFormatString="{0:c}"/>
                                                    <asp:BoundField DataField="PAYPERTIC" ItemStyle-Wrap="false" HeaderText="Pago en Línea" DataFormatString="{0:c}"/>
                                                    <asp:BoundField DataField="DE_BILLETERA" ItemStyle-Wrap="false" HeaderText="De Billetera" DataFormatString="{0:c}"/>
                                                    <asp:BoundField DataField="A_BILLETERA" ItemStyle-Wrap="false" HeaderText="A Billetera" DataFormatString="{0:c}"/>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <!-- /.box-body -->
                                        <div class="box-footer clearfix">
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane" id="tab_1">
                                    <div class="box">
                                        <div class="box-header with-border">
                                            <h3 class="box-title">Total Cobrado:
                                                        <strong id="lblDeuda" runat="server"></strong>
                                                <strong>-</strong>
                                                Cuentas Cobradas: <strong id="lblCantCta" runat="server"></strong>
                                            </h3>
                                        </div>
                                        <!-- /.box-header -->
                                        <div class="box-body">
                                            <asp:GridView
                                                ID="gvCtas"
                                                runat="server"
                                                AutoGenerateColumns="false"
                                                CellPadding="4"
                                                CssClass="table  table-hover"
                                                OnRowDataBound="gvCtas_RowDataBound"
                                                ForeColor="#333333"
                                                GridLines="None">
                                                <Columns>
                                                    <asp:BoundField DataField="NRO_CTA" HeaderText="Cuenta" />
                                                    <asp:TemplateField HeaderText="Responsables" ItemStyle-Wrap="false">
                                                        <ItemTemplate>
                                                            <ul class="nav nav-stacked" id="ulResponsables" runat="server">
                                                            </ul>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="PERIODO_MAQUILLADO" HeaderText="Periodo" />
                                                    <asp:BoundField DataField="FECHA" HeaderText="Fecha" DataFormatString="{0:d}" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div id="divMedioPago" runat="server">
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="TOTAL" ItemStyle-Wrap="false" DataFormatString="{0:c}"
                                                        ItemStyle-HorizontalAlign="Right" HeaderText="Total" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div id="divRecibo" runat="server"></div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <!-- /.box-body -->
                                        <div class="box-footer clearfix">
                                        </div>
                                    </div>
                                </div>
                                <!-- /.tab-pane -->
                                <div class="tab-pane" id="tab_2">
                                    <div class="box">
                                        <div class="box-header with-border">
                                            <h3 class="box-title">Total Cobrado: 
                                            <strong id="lblDeudaPeriodo" runat="server"></strong>
                                                <strong>-</strong>
                                                Cuentas cobradas: <strong id="lblCantCtaPeriodo" runat="server"></strong>
                                            </h3>
                                        </div>
                                        <!-- /.box-header -->
                                        <div class="box-body">
                                            <asp:GridView
                                                ID="gvPeriodos"
                                                runat="server"
                                                AutoGenerateColumns="false"
                                                CellPadding="4"
                                                CssClass="table"
                                                ForeColor="#333333"
                                                GridLines="None">
                                                <Columns>
                                                    <asp:BoundField DataField="DESCRIPCION" ItemStyle-Wrap="false"
                                                        HeaderText="Medio de Pago" />
                                                    <asp:BoundField DataField="CANT_CUENTAS" ItemStyle-Wrap="false"
                                                        ItemStyle-HorizontalAlign="Right" HeaderText="Cant. Cuentas"
                                                        HeaderStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField DataField="TOTAL" ItemStyle-Wrap="false" DataFormatString="{0:c}"
                                                        ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                        HeaderText="Total" />
                                                </Columns>

                                            </asp:GridView>
                                        </div>
                                        <!-- /.box-body -->
                                        <div class="box-footer clearfix">
                                        </div>
                                    </div>
                                </div>
                                <!-- /.tab-pane -->
                                <div class="tab-pane" id="tab_3">
                                    <div class="box">
                                        <div class="box-header with-border">
                                            <h3 class="box-title">Total Cobrado: 
                                            <strong id="lblTotPeriodo" runat="server"></strong>
                                                <strong>-</strong>
                                                Cuentas cobradas: <strong id="lblCantPeriodo" runat="server"></strong>
                                            </h3>
                                        </div>
                                        <!-- /.box-header -->
                                        <div class="box-body">
                                            <asp:GridView
                                                ID="gvPeriodos2"
                                                runat="server"
                                                AutoGenerateColumns="false"
                                                CellPadding="4"
                                                CssClass="table"
                                                ForeColor="#333333"
                                                GridLines="None">
                                                <Columns>
                                                    <asp:BoundField DataField="PERIODO" ItemStyle-Wrap="false"
                                                        HeaderText="Periodo" ItemStyle-CssClass="hidden" />
                                                    <asp:BoundField DataField="PERIODO_MAQUILLADO" ItemStyle-Wrap="false"
                                                        HeaderText="Periodo" />
                                                    <asp:BoundField DataField="CANT_CUENTAS" ItemStyle-Wrap="false"
                                                        ItemStyle-HorizontalAlign="Right" HeaderText="Cant. Cuentas"
                                                        HeaderStyle-HorizontalAlign="Right" />
                                                    <asp:BoundField DataField="TOTAL" ItemStyle-Wrap="false" DataFormatString="{0:c}"
                                                        ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                        HeaderText="Total" />
                                                </Columns>

                                            </asp:GridView>
                                        </div>
                                        <!-- /.box-body -->
                                        <div class="box-footer clearfix">
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane" id="tab_4">
                                    <div class="box">
                                        <div class="box-header with-border">
                                            <h3 class="box-title">Total Cobrado: 
                                            <strong id="lblTotTransaccion" runat="server"></strong>
                                                <strong>-</strong>
                                                Cuentas cobradas: <strong id="lblCantTransaccion" runat="server"></strong>
                                            </h3>
                                        </div>
                                        <!-- /.box-header -->
                                        <div class="box-body">
                                            <asp:GridView
                                                ID="gvTransaccion"
                                                runat="server"
                                                AutoGenerateColumns="false"
                                                CellPadding="4"
                                                OnRowDataBound="gvTransaccion_RowDataBound"
                                                CssClass="table"
                                                ForeColor="#333333"
                                                GridLines="None">
                                                <Columns>
                                                    <asp:BoundField DataField="FECHA" ItemStyle-Wrap="false"
                                                        HeaderText="FECHA" DataFormatString="{0:d}" />
                                                    <asp:BoundField DataField="NRO_RECIBO_PAGO" ItemStyle-Wrap="false"
                                                        HeaderText="NRO. RECIBO" />
                                                    <asp:BoundField DataField="NRO_CTA" ItemStyle-Wrap="false"
                                                        HeaderText="NRO. CUENTA" />
                                                    <asp:BoundField DataField="MEDIO_PAGO" ItemStyle-Wrap="false"
                                                        HeaderText="MEDIO DE PAGO" />
                                                    <asp:BoundField DataField="BANCO" ItemStyle-Wrap="false"
                                                        HeaderText="BANCO" />
                                                    <asp:BoundField DataField="NRO_CHEQUE" ItemStyle-Wrap="false"
                                                        HeaderText="NRO CHEQUE" />
                                                    <asp:BoundField DataField="MONTO" ItemStyle-Wrap="false" DataFormatString="{0:c}"
                                                        ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                        HeaderText="MONTO" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div id="divRecibo" runat="server"></div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>

                                            </asp:GridView>
                                        </div>
                                        <!-- /.box-body -->
                                        <div class="box-footer clearfix">
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane active" id="tab_5">
                                    <div class="box">
                                        <div class="box-header with-border">
                                            <h3 class="box-title">Total Cobrado: 
                                            <strong id="lblTotResumen" runat="server"></strong>
                                                <strong>-</strong>
                                                Cuentas cobradas: <strong id="lblCantResumen" runat="server"></strong>
                                            </h3>
                                        </div>
                                        <!-- /.box-header -->
                                        <div class="box-body">
                                            <asp:GridView
                                                ID="gvResumen"
                                                runat="server"
                                                AutoGenerateColumns="false"
                                                CellPadding="4"
                                                OnRowDataBound="gvResumen_RowDataBound"
                                                CssClass="table"
                                                ForeColor="#333333"
                                                GridLines="None">
                                                <Columns>
                                                    <asp:BoundField DataField="NRO_CTA" ItemStyle-Wrap="false"
                                                        HeaderText="NRO. CUENTA" />
                                                    <asp:BoundField DataField="CANT_MOV" ItemStyle-Wrap="false"
                                                        HeaderText='CANT. RECIBOS' />
                                                    <asp:BoundField DataField="MONTO" ItemStyle-Wrap="false" DataFormatString="{0:c}"
                                                        ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"
                                                        HeaderText="MONTO" />
                                                </Columns>

                                            </asp:GridView>
                                        </div>
                                        <!-- /.box-body -->
                                        <div class="box-footer clearfix">
                                        </div>
                                    </div>
                                </div>
                                <!-- /.tab-pane -->
                            </div>
                            <!-- /.tab-content -->
                        </div>
                    </div>
                    <div class="box-footer">
                    </div>
                </div>
                <!-- /.widget-user -->
            </div>
        </div>
        <!-- /.box -->
    </section>
    <!-- /.content -->
    <script src="../App_Themes/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../App_Themes/bower_components/bootstrap/js/modal.js"></script>

    <script src="../App_Themes/bower_components/datatables.net/js/jquery.dataTables.js?v=1"></script>
    <script src="https://cdn.datatables.net/buttons/1.6.1/js/dataTables.buttons.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.6.1/js/buttons.flash.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.6.1/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.6.1/js/buttons.print.min.js"></script>
    <script>
        function verExport() {
            $("#ContentPlaceHolder1_gvTotExport").show("slow");
            $("#ContentPlaceHolder1_gvT").hide("slow");
            $("#aVerExport").hide("slow");
            $("#aVerPantalla").show("slow");
        }
        function verPantalla() {
            $("#ContentPlaceHolder1_gvTotExport").hide("slow");
            $("#ContentPlaceHolder1_gvT").show("slow");
            $("#aVerExport").show("slow");
            $("#aVerPantalla").hide("slow");
        }
    </script>
    <script>
        $.noConflict();
        jQuery(document).ready(function ($) {
            $('#' + '<%=gvCtas.ClientID %>').DataTable(
                {
                    initComplete: function () {
                        $(this.api().table().container()).find('input').parent().wrap('<form>').parent().attr('autocomplete', 'off');
                    },
                    "language": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json"

                    },
                    dom: 'Bfrtip',
                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todos"]],
                    "iDisplayLength": -1,
                    buttons: [
                        'excel', 'print'
                    ],
                    "order": [[0, "asc"]]
                }
            );
            $('#' + '<%=gvTotDetalleGral.ClientID %>').DataTable(
                {
                    initComplete: function () {
                        $(this.api().table().container()).find('input').parent().wrap('<form>').parent().attr('autocomplete', 'off');
                    },
                    "language": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json"

                    },
                    dom: 'Bfrtip',
                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todos"]],
                    "iDisplayLength": 10,
                    buttons: [
                        'excel', 'print'
                    ],
                    "order": [[0, "asc"]]
                }
            );
            $('#' + '<%=gvPeriodos.ClientID %>').DataTable(
                {
                    initComplete: function () {
                        $(this.api().table().container()).find('input').parent().wrap('<form>').parent().attr('autocomplete', 'off');
                    },
                    "language": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json"

                    },
                    dom: 'Bfrtip',
                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todos"]],
                    "iDisplayLength": -1,
                    buttons: [
                        'excel', 'print'
                    ],
                    "order": [[0, "desc"]]
                }
            );
            $('#' + '<%=gvPeriodos2.ClientID %>').DataTable(
                {
                    initComplete: function () {
                        $(this.api().table().container()).find('input').parent().wrap('<form>').parent().attr('autocomplete', 'off');
                    },
                    "language": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json"

                    },
                    dom: 'Bfrtip',
                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todos"]],
                    "iDisplayLength": -1,
                    buttons: [
                        'excel', 'print'
                    ],
                    "order": [[0, "desc"]]
                }
            );
            $('#' + '<%=gvTransaccion.ClientID %>').DataTable(
                {
                    initComplete: function () {
                        $(this.api().table().container()).find('input').parent().wrap('<form>').parent().attr('autocomplete', 'off');
                    },
                    "language": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json"

                    },
                    dom: 'Bfrtip',
                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todos"]],
                    "iDisplayLength": -1,
                    buttons: [
                        'excel', 'print'
                    ],
                    "order": [[0, "desc"]]
                }
            );
            $('#' + '<%=gvResumen.ClientID %>').DataTable(
                {
                    initComplete: function () {
                        $(this.api().table().container()).find('input').parent().wrap('<form>').parent().attr('autocomplete', 'off');
                    },
                    "language": {
                        "url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json"

                    },
                    dom: 'Bfrtip',
                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "Todos"]],
                    "iDisplayLength": -1,
                    buttons: [
                        'excel', 'print'
                    ],
                    "order": [[0, "asc"]]
                }
            );

        });
        // Code that uses other library's $ can follow here.
    </script>
</asp:Content>
